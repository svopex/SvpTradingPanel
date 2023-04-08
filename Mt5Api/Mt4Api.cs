using Mt5Api;
using MtApi;
using MtApi5;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Mt4Api
{
	public class Mt4Api : ISvpMt
	{
		private int slippage = 10;

		private readonly MtApiClient apiClient = new MtApiClient();

		public static ISvpMt Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Mt4Api();
				}
				return instance;
			}
		}
		private static ISvpMt instance;

		private bool Connected { get; set; }

		private void ApiClient_ConnectionStateChanged(object sender, MtConnectionEventArgs e)
		{
			Connected = e.Status == MtConnectionState.Connected;
		}

		public bool IsConnectedConsole()
		{
			return apiClient.ConnectionState == MtConnectionState.Connected;
		}

		public bool IsConnected()
		{
			return Connected;
		}

		public void Disconnect()
		{
			apiClient.BeginDisconnect();
		}

		public bool Connect()
		{
			//int counter = 10;

			apiClient.BeginConnect("localhost", 8222);

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

		public double SymbolMinLot()
		{
			return apiClient.MarketInfo(Symbol, MarketInfoModeType.MODE_MINLOT);
		}

		public double SymbolLotStep()
		{
			return apiClient.MarketInfo(Symbol, MarketInfoModeType.MODE_LOTSTEP);
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
			return (int)apiClient.SymbolInfoInteger(Symbol, EnumSymbolInfoInteger.SYMBOL_DIGITS);
		}

		public double GetActualPrice()
		{
			var tick = apiClient.SymbolInfoTick(Symbol);
			return tick.Ask;
		}

		public bool CloseMarketOrder(long orderId)
		{
			return apiClient.OrderClose((int)orderId, slippage);
		}

		public bool ClosePendingOrder(long orderId)
		{
			return apiClient.OrderDelete((int)orderId);
		}

		public double GetMarketOrderPrice(long marketOrderId)
		{
			MtOrder order = apiClient.GetOrder((int)marketOrderId, OrderSelectMode.SELECT_BY_TICKET, OrderSelectSource.MODE_TRADES);
			return order.OpenPrice;
		}

		public void SetOrderSlAndPt(Order order)
		{
			apiClient.OrderModify((int)order.Id, order.OpenPrice, order.SL, order.PT, DateTime.Now.AddDays(1));
		}

		public void SetPendingOrderSlAndPtPercent(Order order, double slPercent, double ptPercent)
		{
			double ptOld = order.PT;
			double slOld = order.SL;
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
			if (ptOld != order.PT || slOld != order.SL)
			{
				SetOrderSlAndPt(order);
			}
		}

		public void SetPendingOrderSlAndPtRelative(Order order, double slRelative, double ptRelative)
		{
			double ptOld = order.PT;
			double slOld = order.SL;
			FillSlPt(order, slRelative, ptRelative);
			if (ptOld != order.PT || slOld != order.SL)
			{
				SetOrderSlAndPt(order);
			}
		}

		public void SetPositionSlAndPtPercent(Order order, double slPercent, double ptPercent)
		{
			double oldSl = order.SL;
			double oldPT = order.PT;
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
			if (oldSl != order.SL || oldPT != order.PT)
			{
				SetPositionSlAndPt(order);
			}
		}

		public void SetPositionSlAndPtRelative(Order order, double slRelative, double ptRelative)
		{
			double oldSl = order.SL;
			double oldPT = order.PT;
			FillSlPt(order, slRelative, ptRelative);
			if (oldSl != order.SL || oldPT != order.PT)
			{
				SetPositionSlAndPt(order);
			}
		}

		public void SetPositionSlAndPt(Order order)
		{
			apiClient.OrderModify((int)order.Id, order.OpenPrice, order.SL, order.PT, DateTime.Now.AddDays(1));
		}

		public void ModifyPendingOrder(Order order)
		{
			apiClient.OrderModify((int)order.Id, order.OpenPrice, order.SL, order.PT, DateTime.Now.AddDays(1));
		}

		private int Digits(string instrument)
		{
			return (int)apiClient.SymbolInfoInteger(instrument, EnumSymbolInfoInteger.SYMBOL_DIGITS);
		}

		private double NormalizeDouble(double p, int digits)
		{
			return Math.Round(p, digits);
		}

		private double NormalizeDouble(string instrument, double p)
		{
			return NormalizeDouble(p, Digits(instrument));
		}

		public string AccountCurrency()
		{
			return apiClient.AccountCurrency();
		}

		public double AccountEquity()
		{
			return apiClient.AccountEquity();
		}

		public double SymbolTradeTickValue()
		{
			return apiClient.SymbolInfoDouble(Symbol, EnumSymbolInfoDouble.SYMBOL_TRADE_TICK_VALUE);
		}

		public double SymbolPoint()
		{
			return apiClient.SymbolInfoDouble(Symbol, EnumSymbolInfoDouble.SYMBOL_POINT);
		}

		public ulong CreatePendingOrderSlPtRelative(double price, double units, double slRelative, double ptRelative)
		{
			return CreatePendingOrderSlPtRelative(Symbol, price, units, Utilities.StrategyNumber, null, slRelative, ptRelative);
		}

		public ulong CreatePendingOrderSlPtRelative(string instrument, double price, double units, ulong magic, string comment, double slRelative, double ptRelative)
		{
			ulong ticket = (ulong)CreatePendingOrder(instrument, price, units, null, (int)Utilities.StrategyNumber);
			Order order = GetPendingOrder(ticket);
			double ptOld = order.PT;
			double slOld = order.SL;
			FillSlPt(order, slRelative, ptRelative);
			if (order.PT != ptOld || order.SL != slOld)
			{
				SetOrderSlAndPt(order);
			}
			return ticket;
		}

		public ulong CreatePendingOrderSlPtPercent(double price, double units, double slPercent, double ptPercent)
		{
			return CreatePendingOrderSlPtPercent(Symbol, price, units, 0, null, slPercent, ptPercent);
		}
		public ulong CreatePendingOrderSlPtPercent(string instrument, double price, double units, ulong magic, string comment, double slPercent, double ptPercent)
		{
			ulong ticket = (ulong)CreatePendingOrder(instrument, price, units, null, (int)Utilities.StrategyNumber);
			Order order = GetPendingOrder(ticket);
			double ptOld = order.PT;
			double slOld = order.SL;
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
			if (order.PT != ptOld || order.SL != slOld)
			{
				SetOrderSlAndPt(order);
			}

			return ticket;
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

		public ulong CreateMarketOrderSlPtPercent(double units, double slPercent, double ptPercent)
		{
			ulong ticket = (ulong)CreateMarketOrder(Symbol, units, null, (int)Utilities.StrategyNumber);
			Order order = GetMarketOrder(ticket);
			double oldSl = order.SL;
			double oldPt = order.PT;
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
			if (order.SL != oldSl || order.PT != oldPt)
			{
				SetOrderSlAndPt(order);
			}

			return ticket;
		}

		public ulong CreateMarketOrderSlPtRelative(double units, double slRelative, double ptRelative)
		{
			ulong ticket = (ulong)CreateMarketOrder(Symbol, units, null, (int)Utilities.StrategyNumber);
			Order order = GetMarketOrder(ticket);
			double oldSl = order.SL;
			double oldPt = order.PT;
			FillSlPt(order, slRelative, ptRelative);
			if (order.SL != oldSl || order.PT != oldPt)
			{
				SetOrderSlAndPt(order);
			}

			return ticket;
		}

		public long CreatePendingOrder(string instrument, double price, double units, string comment, int magic)
		{
			int orderId = apiClient.OrderSend(instrument, units > 0 ? TradeOperation.OP_BUYLIMIT : TradeOperation.OP_SELLLIMIT, Math.Abs(units), NormalizeDouble(Symbol, price), slippage, 0, 0, comment, magic);
			return orderId;
		}

		public long CreateMarketOrder(string instrument, double units, string comment, int magic)
		{
			int orderId = apiClient.OrderSend(instrument, units > 0 ? TradeOperation.OP_BUY : TradeOperation.OP_SELL, Math.Abs(units), 0, slippage, 0, 0, comment, magic);
			return orderId;
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

		public Order GetMarketOrder(ulong ticket)
		{
			return GetMarketOrders().FirstOrDefault(x => x.Id == (int)ticket);
		}

		public Order GetPendingOrder(ulong ticket)
		{
			return GetPendingOrders().FirstOrDefault(x => x.Id == (int)ticket);
		}

		public Orders GetMarketOrders()
		{
			Orders orders = new Orders();
			List<MtOrder> mtOrders = apiClient.GetOrders(OrderSelectSource.MODE_TRADES);
			foreach (MtOrder mtOrder in mtOrders)
			{
				if (mtOrder.Operation == TradeOperation.OP_BUY || mtOrder.Operation == TradeOperation.OP_SELL)
				{
					Order order = new Order();
					order.Id = mtOrder.Ticket;
					order.OpenPrice = mtOrder.OpenPrice;
					order.CurrentPrice = mtOrder.ClosePrice;
					order.OpenTime = mtOrder.OpenTime;
					order.Units = mtOrder.Operation == TradeOperation.OP_BUY ? mtOrder.Lots : -mtOrder.Lots;
					order.Instrument = mtOrder.Symbol;
					order.PT = mtOrder.TakeProfit;
					order.SL = mtOrder.StopLoss;
					order.Magic = (ulong)mtOrder.MagicNumber;
					order.Comment = mtOrder.Comment;
					if (Utilities.StrategyNumber == order.Magic && order.Instrument == Symbol)
					{
						orders.Add(order);
					}
				}
			}
			return orders;
		}

		public Orders GetPendingOrders()
		{
			Orders orders = new Orders();
			List<MtOrder> mtOrders = apiClient.GetOrders(OrderSelectSource.MODE_TRADES);
			foreach (MtOrder mtOrder in mtOrders)
			{
				if (mtOrder.Operation == TradeOperation.OP_BUYLIMIT || mtOrder.Operation == TradeOperation.OP_SELLLIMIT)
				{
					Order order = new Order();
					order.Id = mtOrder.Ticket;
					order.OpenPrice = mtOrder.OpenPrice;
					order.CurrentPrice = mtOrder.ClosePrice;
					order.OpenTime = mtOrder.OpenTime;
					order.Units = mtOrder.Operation == TradeOperation.OP_BUYLIMIT ? mtOrder.Lots : -mtOrder.Lots;
					order.Instrument = mtOrder.Symbol;
					order.PT = mtOrder.TakeProfit;
					order.SL = mtOrder.StopLoss;
					order.Magic = (ulong)mtOrder.MagicNumber;
					order.Comment = mtOrder.Comment;
					if (Utilities.StrategyNumber == order.Magic && order.Instrument == Symbol)
					{
						orders.Add(order);
					}
				}
			}
			return orders;
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
			return apiClient.iClose(Symbol, ChartPeriod.PERIOD_D1, Shift);
		}

		public double WtrsAtr(int period)
		{
			if (period == 5)
			{
				return apiClient.iATR(Symbol, (int)MtApi.ENUM_TIMEFRAMES.PERIOD_M5, 60 / 5, 0); // prumer za posledni hodinu
			}
			else if (period == 10)
			{
				return apiClient.iATR(Symbol, (int)MtApi.ENUM_TIMEFRAMES.PERIOD_M10, 60 / 10, 0); // prumer za posledni hodinu
			}
			throw new Exception();
		}

		public double WtrsHigh()
		{
			var result = apiClient.CopyRates(Symbol, MtApi.ENUM_TIMEFRAMES.PERIOD_M1, 0, 5);
			double high = 0;
			for (int i = 0; i < result.Count(); i++)
			{
				if (result[i].High >= high)
				{
					high = result[i].High;
				}
				else
				{
					break;
				}
			}
			return high;
		}

		public double WtrsLow()
		{
			var result = apiClient.CopyRates(Symbol, MtApi.ENUM_TIMEFRAMES.PERIOD_M1, 0, 5);
			double low = double.MaxValue;
			for (int i = 0; i < result.Count(); i++)
			{
				if (result[i].Low <= low)
				{
					low = result[i].Low;
				}
				else
				{
					break;
				}
			}
			return low;
		}
	}
}
