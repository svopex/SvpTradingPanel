using Mt5Api;
using MtApi;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mt4Api
{
    public class SvpMT4
    {
		private readonly MtApiClient apiClient = new MtApiClient();

		public static SvpMT4 Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new SvpMT4();
				}
				return instance;
			}
		}
		private static SvpMT4 instance;

		private bool Connected { get; set; }

		private void ApiClient_ConnectionStateChanged(object sender, MtConnectionEventArgs e)
		{
			Connected = e.Status == MtConnectionState.Connected;
		}

		public bool isConnected()
		{
			return Connected;
		}

		public void Disconnect()
		{
			instance.apiClient.BeginDisconnect();
		}

		public bool Connect()
		{
			//int counter = 10;

			instance.apiClient.BeginConnect("localhost", 8222);

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

			instance.apiClient.ConnectionStateChanged += ApiClient_ConnectionStateChanged;

			Connected = false;

			return false;
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

		public void CloseMarketOrder(long orderId)
        {
            apiClient.OrderClose((int)orderId, 0);
        }

        public double GetMarketOrderPrice(long marketOrderId)
        {
            MtOrder order = apiClient.GetOrder((int)marketOrderId, OrderSelectMode.SELECT_BY_TICKET, OrderSelectSource.MODE_TRADES);
            return order.OpenPrice;
        }

		public void SetOrderSlAndPt(Order order)
		{
			apiClient.OrderModify((int)order.Id, 0, order.SL, order.PT, DateTime.Now.AddDays(1));
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
			apiClient.OrderModify((int)order.Id, 0, order.SL, order.PT, DateTime.Now.AddDays(1));
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

		public double SymbolTradeTickValue()
		{
			return apiClient.SymbolInfoDouble(Symbol, EnumSymbolInfoDouble.SYMBOL_TRADE_TICK_VALUE);
		}

		public double SymbolPoint()
		{
			return apiClient.SymbolInfoDouble(Symbol, EnumSymbolInfoDouble.SYMBOL_POINT);
		}

		public ulong CreatePendingOrderSlPtPercent(double price, double units, double slPercent, double ptPercent)
		{
			return CreatePendingOrderSlPtPercent(Symbol, price, units, 0, null, slPercent, ptPercent);
		}
		public ulong CreatePendingOrderSlPtPercent(string instrument, double price, double units, ulong magic, string comment, double slPercent, double ptPercent)
		{
			ulong ticket = (ulong)CreatePendingOrder(instrument, price, units);
			Order order = GetPendingOrder(ticket);
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
			ulong ticket = (ulong)CreateMarketOrder(Symbol, units);
			Order order = GetPendingOrder(ticket);
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

			return ticket;
		}

		public void ModifyMarketOrder(Order newOAMarketOrder)
        {
            apiClient.OrderModify((int)newOAMarketOrder.Id, 0, newOAMarketOrder.SL, newOAMarketOrder.PT, DateTime.Now.AddDays(1));
        }

		public long CreatePendingOrder(string instrument, double price, double units)
		{
			int orderId = apiClient.OrderSend(instrument, units > 0 ? TradeOperation.OP_BUYLIMIT: TradeOperation.OP_SELLLIMIT, Math.Abs(units), price, 0, 0, 0);
			return orderId;
		}

		public long CreateMarketOrder(string instrument, double units)
        {
            int orderId = apiClient.OrderSend(instrument, units > 0 ? TradeOperation.OP_BUY : TradeOperation.OP_SELL, Math.Abs(units), 0, 0, 0, 0);
            return orderId;
        }

		public string Symbol => apiClient.ChartSymbol(0);

		public Order GetPendingOrder(ulong ticket)
		{
			return GetMarketOrders().FirstOrDefault(x => x.Id == (int)ticket);
		}

		public Orders GetMarketOrders()
        {
            Orders orders = new Orders();
            List<MtOrder> mtOrders = apiClient.GetOrders(OrderSelectSource.MODE_TRADES);
            foreach(MtOrder mtOrder in mtOrders)
            {
                if (mtOrder.Operation == TradeOperation.OP_BUY || mtOrder.Operation == TradeOperation.OP_SELL)
                {
                    Order order = new Order();
                    order.Id = mtOrder.Ticket;
                    order.OpenPrice = mtOrder.OpenPrice;
                    order.CurrentPrice = mtOrder.ClosePrice;
                    order.Units = mtOrder.Operation == TradeOperation.OP_BUY ? mtOrder.Lots : -mtOrder.Lots;
                    order.Instrument = mtOrder.Symbol;
                    order.PT = mtOrder.TakeProfit;
                    order.SL = mtOrder.StopLoss;
                    if (order.Instrument == Symbol)
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
                    order.Units = mtOrder.Operation == TradeOperation.OP_BUYLIMIT ? mtOrder.Lots : -mtOrder.Lots;
                    order.Instrument = mtOrder.Symbol;
                    order.PT = mtOrder.TakeProfit;
                    order.SL = mtOrder.StopLoss;
                    if (order.Instrument == Symbol)
                    {
                        orders.Add(order);
                    }
                }
			}
			return orders;
		}
	}
}
