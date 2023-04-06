using Mt4Api;
using MtApi;
using MtApi5;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Utils;

namespace Mt5Api
{
	public class Mt5Api : ISvpMt
	{
		private readonly MtApi5Client apiClient = new MtApi5Client();

		public static ISvpMt Instance { get; set; }

		private bool Connected { get; set; }

		private void ApiClient_ConnectionStateChanged(object sender, Mt5ConnectionEventArgs e)
		{
			Connected = e.Status == Mt5ConnectionState.Connected;
		}

		public bool IsConnected()
		{
			//return instance.apiClient.ConnectionState == Mt5ConnectionState.Connected;
			return Connected;
		}

		public bool IsConnectedConsole()
		{
			return apiClient.ConnectionState == Mt5ConnectionState.Connected;
		}

		public void Disconnect()
		{
			apiClient.BeginDisconnect();
		}

		public bool Connect()
		{
			//int counter = 10;

			apiClient.BeginConnect(Utilities.Host, Utilities.Port);

			//while (instance.apiClient.ConnectionState != Mt5ConnectionState.Connected)
			//{
			//	Thread.Sleep(100);
			//	if (counter-- == 0)
			//	{
			//		Messager messager = new Messager(Utilities.ErrorMessageDestination);
			//		messager.SendMessage("Trade computer: MT5 maybe is not running", "MT5 maybe is not running.", Utilities.StrategyName);
			//		Logger.WriteLineError("MT5 maybe is not running for strategy " + Utilities.StrategyName + ".");
			//		return false;
			//	}
			//}
			//Logger.WriteLine("SvpTradingPanel not connected to MT5.");

			apiClient.ConnectionStateChanged += ApiClient_ConnectionStateChanged;

			Connected = false;

			return false;
		}

		private string TransformInstrument(string symbol)
		{
			if (symbol.ToLower() == "eurusd")
			{
				return symbol;
			}
			if (symbol.ToLower() == "bf-b")
			{
				symbol = "BFB";
			}
			if (symbol.ToLower() == "brk-b")
			{
				symbol = "BRKB";
			}
			return symbol;
		}

		private string DeTransformInstrument(string symbol)
		{
			if (symbol.ToLower() == "eurusd")
			{
				return symbol;
			}
			if (symbol.ToLower() == "bfb")
			{
				symbol = "BF-B";
			}
			if (symbol.ToLower() == "brkb")
			{
				symbol = "BRK-B";
			}
			return symbol;
		}

		public double SymbolMinLot()
		{
			return apiClient.SymbolInfoDouble(Symbol, ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_VOLUME_MIN);
		}

		public double SymbolLotStep()
		{
			return apiClient.SymbolInfoDouble(Symbol, ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_VOLUME_STEP);
		}

		public int SymbolLotStepDigits()
		{
			double lotStep = SymbolLotStep();
			int digits = 0;
			if (lotStep <= 0.001)
				digits = 3;
			if (lotStep <= 0.01)
				digits = 2;
			else if (lotStep <= 0.1)
				digits = 1;
			else
				digits = 0;
			return digits;
		}

		public int SymbolDigits()
		{
			return (int)apiClient.SymbolInfoInteger(Symbol, ENUM_SYMBOL_INFO_INTEGER.SYMBOL_DIGITS);
		}

		public double GetActualPrice()
		{
			apiClient.SymbolInfoTick(Symbol, out MtApi5.MqlTick tick);
			return tick.ask;
		}

		public bool SymbolSelect(string instrument, bool selected)
		{
			return apiClient.SymbolSelect(TransformInstrument(instrument), selected);
		}

		public bool CloseMarketOrder(long orderId)
		{
			return apiClient.PositionClose((ulong)orderId);
		}

		public double GetMarketOrderPrice(long marketOrderId)
		{
			if (apiClient.PositionSelectByTicket((ulong)marketOrderId))
			{
				return apiClient.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PRICE_OPEN);
			}
			return 0;
		}

		public void SetOrderSlAndPt(Order order)
		{
			MqlTradeRequest mqlTradeRequest = new MqlTradeRequest();
			mqlTradeRequest.Action = ENUM_TRADE_REQUEST_ACTIONS.TRADE_ACTION_MODIFY;
			mqlTradeRequest.Order = (ulong)order.Id;
			mqlTradeRequest.Deviation = 5;
			//mqlTradeRequest.Position = (ulong)order.Id;
			mqlTradeRequest.Symbol = TransformInstrument(order.Instrument);
			mqlTradeRequest.Magic = order.Magic;
			mqlTradeRequest.Sl = order.SL;
			mqlTradeRequest.Tp = order.PT;
			mqlTradeRequest.Price = order.OpenPrice;
			//mqlTradeRequest.Type_filling = ENUM_ORDER_TYPE_FILLING.ORDER_FILLING_IOC;
			MqlTradeResult mqlTradeResult;
			bool result = apiClient.OrderSend(mqlTradeRequest, out mqlTradeResult);
			//apiClient.PositionModify((ulong)order.Id, order.SL, order.PT);
		}

		public void SetPendingOrderSlAndPtPercent(Order order, double slPercent, double ptPercent)
		{
			double slRelative = 0;
			double ptRelative = 0;
			if (slPercent != 0)
			{
				slRelative = order.OpenPrice * slPercent / 100;
			}
			if (ptPercent != 0)
			{
				ptRelative = order.OpenPrice * ptPercent / 100;
			}
			FillSlPt(order, slRelative, ptRelative);
			SetOrderSlAndPt(order);
		}

		public void SetPositionSlAndPtPercent(Order order, double slPercent, double ptPercent)
		{
			double slRelative = 0;
			double ptRelative = 0;
			if (slPercent != 0)
			{
				slRelative = order.OpenPrice * slPercent / 100;
			}
			if (ptPercent != 0)
			{
				ptRelative = order.OpenPrice * ptPercent / 100;
			}
			FillSlPt(order, slRelative, ptRelative);
			SetPositionSlAndPt(order);
		}

		public void SetPositionSlAndPt(Order order)
		{
			MqlTradeRequest mqlTradeRequest = new MqlTradeRequest();
			mqlTradeRequest.Action = ENUM_TRADE_REQUEST_ACTIONS.TRADE_ACTION_SLTP;
			mqlTradeRequest.Position = (ulong)order.Id;
			mqlTradeRequest.Symbol = TransformInstrument(order.Instrument);
			mqlTradeRequest.Magic = order.Magic;
			mqlTradeRequest.Sl = order.SL;
			mqlTradeRequest.Tp = order.PT;
			//mqlTradeRequest.Type_filling = ENUM_ORDER_TYPE_FILLING.ORDER_FILLING_IOC;
			MqlTradeResult mqlTradeResult;
			bool result = apiClient.OrderSend(mqlTradeRequest, out mqlTradeResult);
			//apiClient.PositionModify((ulong)order.Id, order.SL, order.PT);
		}

		private int Digits(string instrument)
		{
			return (int)apiClient.SymbolInfoInteger(instrument, ENUM_SYMBOL_INFO_INTEGER.SYMBOL_DIGITS);
		}

		private double NormalizeDouble(double p, int digits)
		{
			return Math.Round(p, digits);
		}

		private double NormalizeDouble(string instrument, double p)
		{
			return NormalizeDouble(p, Digits(instrument));
		}

		private void FillSlPt(MqlTradeRequest mqlTradeRequest, double SlRelative, double PtRelative)
		{
			if (SlRelative != 0)
			{
				if (mqlTradeRequest.Type == ENUM_ORDER_TYPE.ORDER_TYPE_BUY_STOP_LIMIT)
				{
					mqlTradeRequest.Sl = NormalizeDouble(mqlTradeRequest.Symbol, mqlTradeRequest.Stoplimit - SlRelative);
				}
				else if (mqlTradeRequest.Type == ENUM_ORDER_TYPE.ORDER_TYPE_SELL_STOP_LIMIT)
				{
					mqlTradeRequest.Sl = NormalizeDouble(mqlTradeRequest.Symbol, mqlTradeRequest.Stoplimit + SlRelative);
				}
				else if (mqlTradeRequest.Type == ENUM_ORDER_TYPE.ORDER_TYPE_BUY_LIMIT
					|| mqlTradeRequest.Type == ENUM_ORDER_TYPE.ORDER_TYPE_BUY_STOP)
				{
					mqlTradeRequest.Sl = NormalizeDouble(mqlTradeRequest.Symbol, mqlTradeRequest.Price - SlRelative);
				}
				else
				{
					mqlTradeRequest.Sl = NormalizeDouble(mqlTradeRequest.Symbol, mqlTradeRequest.Price + SlRelative);
				}
			}
			if (PtRelative != 0)
			{
				if (mqlTradeRequest.Type == ENUM_ORDER_TYPE.ORDER_TYPE_BUY_STOP_LIMIT)
				{
					mqlTradeRequest.Tp = NormalizeDouble(mqlTradeRequest.Symbol, mqlTradeRequest.Stoplimit + PtRelative);
				}
				else if (mqlTradeRequest.Type == ENUM_ORDER_TYPE.ORDER_TYPE_SELL_STOP_LIMIT)
				{
					mqlTradeRequest.Tp = NormalizeDouble(mqlTradeRequest.Symbol, mqlTradeRequest.Stoplimit - PtRelative);
				}
				else if (mqlTradeRequest.Type == ENUM_ORDER_TYPE.ORDER_TYPE_BUY_LIMIT
					|| mqlTradeRequest.Type == ENUM_ORDER_TYPE.ORDER_TYPE_BUY_STOP)
				{
					mqlTradeRequest.Tp = NormalizeDouble(mqlTradeRequest.Symbol, mqlTradeRequest.Price + PtRelative);
				}
				else
				{
					mqlTradeRequest.Tp = NormalizeDouble(mqlTradeRequest.Symbol, mqlTradeRequest.Price - PtRelative);
				}
			}
		}

		public void ModifyPendingOrder(Order order)
		{
			MqlTradeRequest mqlTradeRequest = new MqlTradeRequest();
			mqlTradeRequest.Symbol = Symbol;
			mqlTradeRequest.Action = ENUM_TRADE_REQUEST_ACTIONS.TRADE_ACTION_MODIFY;
			mqlTradeRequest.Magic = order.Magic;
			mqlTradeRequest.Order = (ulong)order.Id;
			mqlTradeRequest.Price = NormalizeDouble(Symbol, order.OpenPrice);
			mqlTradeRequest.Stoplimit = NormalizeDouble(Symbol, order.OpenPrice);
			mqlTradeRequest.Sl = order.SL;
			mqlTradeRequest.Tp = order.PT;
			MqlTradeResult mqlTradeResult;
			bool result = apiClient.OrderSend(mqlTradeRequest, out mqlTradeResult);
		}

		public string AccountCurrency()
		{
			return apiClient.AccountInfoString(ENUM_ACCOUNT_INFO_STRING.ACCOUNT_CURRENCY);
		}

		public double SymbolTradeTickValue()
		{
			return apiClient.SymbolInfoDouble(Symbol, ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_TRADE_TICK_VALUE);
		}

		public double SymbolPoint()
		{
			return apiClient.SymbolInfoDouble(Symbol, ENUM_SYMBOL_INFO_DOUBLE.SYMBOL_POINT);
		}

		public ulong CreatePendingOrderSlPtPercent(double price, double units, double slPercent, double ptPercent)
		{
			return CreatePendingOrderSlPtPercent(Symbol, price, units, Utilities.StrategyNumber, null, slPercent, ptPercent).ticket;
		}

		public (bool result, ulong ticket, uint retCode, string comment) CreatePendingOrderSlPtPercent(string instrument, double price, double units, ulong magic, string comment, double slPercent, double ptPercent)
		{
			(bool result, ulong ticket, uint retCode, string comment) result = CreatePendingOrder(instrument, price, units, OrderType.Limit, magic, comment, price);
			if (result.result)
			{
				Order order = GetPendingOrder(result.ticket);
				double slRelative = 0;
				double ptRelative = 0;
				if (slPercent != 0)
				{
					slRelative = order.OpenPrice * slPercent / 100;
				}
				if (ptPercent != 0)
				{
					ptRelative = order.OpenPrice * ptPercent / 100;
				}
				FillSlPt(order, slRelative, ptRelative);
				SetOrderSlAndPt(order);
			}
			return result;
		}

		public (bool result, ulong ticket, uint retCode, string comment)
			CreatePendingOrderSlPtRelative(string instrument, double price, double units, OrderType orderType, ulong magic, string comment, double SlRelative, double PtRelative, double stopLimitPrice)
		{
			MqlTradeRequest mqlTradeRequest = new MqlTradeRequest();
			mqlTradeRequest.Action = ENUM_TRADE_REQUEST_ACTIONS.TRADE_ACTION_PENDING;
			mqlTradeRequest.Symbol = TransformInstrument(instrument);
			mqlTradeRequest.Volume = (double)Math.Abs(units);
			mqlTradeRequest.Stoplimit = NormalizeDouble(instrument, stopLimitPrice);
			switch (orderType)
			{
				case OrderType.Limit:
					mqlTradeRequest.Type = units > 0 ? ENUM_ORDER_TYPE.ORDER_TYPE_BUY_LIMIT : ENUM_ORDER_TYPE.ORDER_TYPE_SELL_LIMIT;
					break;
				case OrderType.Stop:
					mqlTradeRequest.Type = units > 0 ? ENUM_ORDER_TYPE.ORDER_TYPE_BUY_STOP : ENUM_ORDER_TYPE.ORDER_TYPE_SELL_STOP;
					break;
				case OrderType.StopLimit:
					mqlTradeRequest.Type = units > 0 ? ENUM_ORDER_TYPE.ORDER_TYPE_BUY_STOP_LIMIT : ENUM_ORDER_TYPE.ORDER_TYPE_SELL_STOP_LIMIT;
					break;
			}
			mqlTradeRequest.Price = NormalizeDouble(instrument, price);
			mqlTradeRequest.Magic = magic;
			//mqlTradeRequest.Comment = comment;
			FillSlPt(mqlTradeRequest, SlRelative, PtRelative);
			MqlTradeResult mqlTradeResult;
			bool result = apiClient.OrderSend(mqlTradeRequest, out mqlTradeResult);
			return (result, mqlTradeResult.Order, mqlTradeResult.Retcode, mqlTradeResult.Comment);
		}

		public (bool result, ulong ticket, uint retCode, string comment)
			CreatePendingOrder(string instrument, double price, double units, OrderType orderType, ulong magic, string comment, double stopLimitPrice)
		{
			return CreatePendingOrderSlPtRelative(instrument, price, units, orderType, magic, comment, 0, 0, stopLimitPrice);
		}

		public Order GetPendingOrder(ulong ticket)
		{
			apiClient.OrderSelect(ticket);

			Order Order = new Order();

			Order.Id = (long)ticket;
			Order.OpenPrice = apiClient.OrderGetDouble(ENUM_ORDER_PROPERTY_DOUBLE.ORDER_PRICE_OPEN);
			Order.CurrentPrice = apiClient.OrderGetDouble(ENUM_ORDER_PROPERTY_DOUBLE.ORDER_PRICE_CURRENT);
			Order.OpenTime = ConvertMscTimeToDateTime(apiClient.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME_MSC));
			Order.SL = apiClient.OrderGetDouble(ENUM_ORDER_PROPERTY_DOUBLE.ORDER_SL);
			Order.PT = apiClient.OrderGetDouble(ENUM_ORDER_PROPERTY_DOUBLE.ORDER_TP);
			Order.Units = apiClient.OrderGetDouble(ENUM_ORDER_PROPERTY_DOUBLE.ORDER_VOLUME_CURRENT);
			ENUM_ORDER_TYPE Type = (ENUM_ORDER_TYPE)apiClient.OrderGetInteger(ENUM_ORDER_PROPERTY_INTEGER.ORDER_TYPE);
			if (Type == ENUM_ORDER_TYPE.ORDER_TYPE_SELL_LIMIT || Type == ENUM_ORDER_TYPE.ORDER_TYPE_SELL_STOP || Type == ENUM_ORDER_TYPE.ORDER_TYPE_SELL_STOP_LIMIT)
			{
				Order.Units = -Order.Units;
			}
			Order.Instrument = apiClient.OrderGetString(ENUM_ORDER_PROPERTY_STRING.ORDER_SYMBOL);
			Order.Magic = (ulong)apiClient.OrderGetInteger(ENUM_ORDER_PROPERTY_INTEGER.ORDER_MAGIC);
			Order.Comment = apiClient.OrderGetString(ENUM_ORDER_PROPERTY_STRING.ORDER_COMMENT);

			return Order;
		}

		public Orders GetPendingOrders()
		{
			Orders Orders = new Orders();

			int total = apiClient.OrdersTotal();
			for (int i = 0; i < total; i++)
			{
				ulong ticket = apiClient.OrderGetTicket(i);

				Order Order = GetPendingOrder(ticket);

				if (/*Utilities.StrategyNumber == Order.Magic && */ Order.Instrument == TransformInstrument(Symbol))
				{
					Order.Instrument = DeTransformInstrument(Order.Instrument);
					Orders.Add(Order);
				}
			}
			return Orders;
		}

		private void FillSlPt(Order order, double SlRelative, double PtRelative)
		{
			if (SlRelative != 0)
			{
				if (order.Units > 0)
				{
					order.SL = NormalizeDouble(order.Instrument, order.OpenPrice - SlRelative);
				}
				else
				{
					order.SL = NormalizeDouble(order.Instrument, order.OpenPrice + SlRelative);
				}
			}
			if (PtRelative != 0)
			{
				if (order.Units > 0)
				{
					order.PT = NormalizeDouble(order.Instrument, order.OpenPrice + PtRelative);
				}
				else
				{
					order.PT = NormalizeDouble(order.Instrument, order.OpenPrice - PtRelative);
				}
			}
		}

		public string Symbol
		{
			get
			{
				if (String.IsNullOrWhiteSpace(symbol))
				{
					return apiClient.ChartSymbol(0);
				}
				return symbol;
			}
			set
			{
				symbol = value;
			}
		}
		private string symbol;

		public ulong CreateMarketOrderSlPtPercent(double units, double slPercent, double ptPercent)
		{
			return CreateMarketOrderSlPtPercent(Symbol, units, Utilities.StrategyNumber, null, slPercent, ptPercent).ticket;
		}

		public (bool result, ulong ticket, uint retCode, string comment) CreateMarketOrderSlPtPercent(string instrument, double units, ulong magic, string comment, double slPercent, double ptPercent)
		{
			(bool result, ulong ticket, uint retCode, string comment) result = CreateMarketOrder(instrument, units, magic, comment);
			if (result.result)
			{
				Order order = GetMarketOrder(result.ticket);
				double slRelative = 0;
				double ptRelative = 0;
				if (slPercent != 0)
				{
					slRelative = order.OpenPrice * slPercent / 100;
				}
				if (ptPercent != 0)
				{
					ptRelative = order.OpenPrice * ptPercent / 100;
				}
				FillSlPt(order, slRelative, ptRelative);
				SetPositionSlAndPt(order);
			}
			return result;
		}

		public (bool result, ulong ticket, uint retCode, string comment)
			CreateMarketOrderSlPtRelative(string instrument, long units, ulong magic, string comment, double SlRelative, double PtRelative)
		{
			(bool result, ulong ticket, uint retCode, string comment) result = CreateMarketOrder(instrument, units, magic, comment);
			if (result.result)
			{
				Order order = GetMarketOrder(result.ticket);
				FillSlPt(order, SlRelative, PtRelative);
				SetPositionSlAndPt(order);
			}
			return result;
		}

		public (bool result, ulong ticket, uint retCode, string comment) CreateMarketOrder(string instrument, double units, ulong magic, string comment)
		{
			MqlTradeRequest mqlTradeRequest = new MqlTradeRequest();
			mqlTradeRequest.Action = ENUM_TRADE_REQUEST_ACTIONS.TRADE_ACTION_DEAL;
			mqlTradeRequest.Symbol = TransformInstrument(instrument);
			mqlTradeRequest.Volume = Math.Abs(units);
			mqlTradeRequest.Type = units > 0 ? ENUM_ORDER_TYPE.ORDER_TYPE_BUY : ENUM_ORDER_TYPE.ORDER_TYPE_SELL;
			mqlTradeRequest.Magic = magic;
			// Todle zde musi byt kvuli ICMARKETS, jinak objednavky nechodi
			mqlTradeRequest.Type_filling = ENUM_ORDER_TYPE_FILLING.ORDER_FILLING_IOC;
			//mqlTradeRequest.Comment = comment;
			MqlTradeResult mqlTradeResult;
			bool result = apiClient.OrderSend(mqlTradeRequest, out mqlTradeResult);
			return (result, mqlTradeResult.Order, mqlTradeResult.Retcode, mqlTradeResult.Comment);
		}

		private DateTime ConvertMscTimeToDateTime(long time)
		{
			return new DateTime(time * 10000).AddYears(1969);
		}

		public Order GetMarketOrder(ulong ticket)
		{
			apiClient.PositionSelectByTicket(ticket);

			Order Order = new Order();

			Order.Id = (long)ticket;
			Order.OpenPrice = apiClient.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PRICE_OPEN);
			Order.CurrentPrice = apiClient.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_PRICE_CURRENT);
			//Order.OpenTime = new DateTime(apiClient.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME_MSC) * 10000).AddYears(1969);
			Order.OpenTime = ConvertMscTimeToDateTime(apiClient.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TIME_MSC));
			Order.SL = apiClient.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_SL);
			Order.PT = apiClient.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_TP);
			Order.Units = apiClient.PositionGetDouble(ENUM_POSITION_PROPERTY_DOUBLE.POSITION_VOLUME);
			ENUM_ORDER_TYPE Type = (ENUM_ORDER_TYPE)apiClient.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_TYPE);
			if (Type == ENUM_ORDER_TYPE.ORDER_TYPE_SELL)
			{
				Order.Units = -Order.Units;
			}
			Order.Instrument = apiClient.PositionGetString(ENUM_POSITION_PROPERTY_STRING.POSITION_SYMBOL);
			Order.Magic = (ulong)apiClient.PositionGetInteger(ENUM_POSITION_PROPERTY_INTEGER.POSITION_MAGIC);
			Order.Comment = apiClient.PositionGetString(ENUM_POSITION_PROPERTY_STRING.POSITION_COMMENT);

			return Order;
		}

		public Orders GetMarketOrders()
		{
			Orders Orders = new Orders();

			int total = apiClient.PositionsTotal();
			for (int i = 0; i < total; i++)
			{
				ulong ticket = apiClient.PositionGetTicket(i);

				Order Order = GetMarketOrder(ticket);

				if (/*Utilities.StrategyNumber == Order.Magic && */ Order.Instrument == TransformInstrument(Symbol))
				{
					Order.Instrument = DeTransformInstrument(Order.Instrument);
					Orders.Add(Order);
				}
			}
			return Orders;
		}

		public bool ClosePendingOrder(long orderId)
		{
			return apiClient.OrderClose((ulong)orderId);
		}

		public void CloseAllPendingOrders()
		{
#pragma warning disable CS0618 // Type or member is obsolete
			apiClient.OrderCloseAll();
#pragma warning restore CS0618 // Type or member is obsolete
		}

		public int SymbolsTotal(bool symbolsInMarketWatch)
		{
			return apiClient.SymbolsTotal(symbolsInMarketWatch);
		}

		public string SymbolName(int pos, bool fromMarketWatch)
		{
			return apiClient.SymbolName(pos, fromMarketWatch);
		}

		public double DailyClose(int Shift)
		{
			if (apiClient.CopyClose(Symbol, MtApi5.ENUM_TIMEFRAMES.PERIOD_D1, Shift, 1, out double[] result) == 1)
			{
				return result[0];
			}
			return 0;
		}
	}
}
