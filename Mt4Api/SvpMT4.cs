using MtApi;
using System;
using System.Collections.Generic;
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
                    instance.apiClient.BeginConnect("127.0.0.1", 8222);
                }
                return instance;
            }
        }
        private static SvpMT4 instance;

        public void CloseOrder(long orderId)
        {
            apiClient.OrderClose((int)orderId, 0);
        }

        public double GetMarketOrderPrice(long marketOrderId)
        {
            MtOrder order = apiClient.GetOrder((int)marketOrderId, OrderSelectMode.SELECT_BY_TICKET, OrderSelectSource.MODE_TRADES);
            return order.OpenPrice;
        }

        public void ModifyMarketOrder(Order newOAMarketOrder)
        {
            apiClient.OrderModify((int)newOAMarketOrder.Id, 0, newOAMarketOrder.SL, newOAMarketOrder.PT, DateTime.Now.AddDays(1));
        }

        public long CreateMarketOrder(string instrument, long units)
        {
            int orderId = apiClient.OrderSend(instrument, units > 0 ? TradeOperation.OP_BUY : TradeOperation.OP_SELL, Math.Abs(units), 0, 0, 0, 0);
            return orderId;
        }

		public string Symbol => apiClient.ChartSymbol(0);

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
