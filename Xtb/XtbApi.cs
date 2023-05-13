using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using xAPI.Codes;
using xAPI.Commands;
using xAPI.Records;
using xAPI.Responses;
using xAPI.Sync;

namespace Xtb
{
	public class XtbApi
	{
		private Server serverData = Servers.DEMO;
		private string userId = "14734282";
		private string password = "Xtb2013!";
		private double riskInPercent = 0.005;
		private double BrokerMarginEquityCoefficient = 1;

		private string symbol = "USDJPY";
		private double slDistance = 185;

		private double risk;
		private SyncAPIConnector? connector = null;
		private SymbolResponse? symbolsResponse = null;
		private int precision;

		public XtbApi(string symbol, double slDistance, bool fullInit = false)
		{
			this.symbol = symbol;
			this.slDistance = slDistance;
			Init();
			if (fullInit)
			{
				FullInit();
			}
		}

		private double CalcPosition(bool buy, double position, double step)
		{
			if (buy)
			{
				ProfitCalculationResponse profitPrev = APICommandFactory.ExecuteProfitCalculationCommand(connector, symbol, position, TRADE_OPERATION_CODE.BUY, symbolsResponse!.Symbol.Ask, symbolsResponse.Symbol.Bid + slDistance);
				position += step;
				while (true)
				{
					var profit = APICommandFactory.ExecuteProfitCalculationCommand(connector, symbol, position, TRADE_OPERATION_CODE.BUY, symbolsResponse.Symbol.Ask, symbolsResponse.Symbol.Bid + slDistance);
					if ((risk - profitPrev.Profit!.Value > 0) && (risk - profit.Profit!.Value < 0))
					{
						position -= step;
						break;
					}
					position += step;
					if (position > 10)
					{
						throw new Exception();
					}
					profitPrev = profit;

				}
				return position;
			}
			else
			{
				ProfitCalculationResponse profitPrev = APICommandFactory.ExecuteProfitCalculationCommand(connector, symbol, position, TRADE_OPERATION_CODE.SELL, symbolsResponse!.Symbol.Bid, symbolsResponse.Symbol.Ask - slDistance);
				position += step;
				while (true)
				{
					var profit = APICommandFactory.ExecuteProfitCalculationCommand(connector, symbol, position, TRADE_OPERATION_CODE.SELL, symbolsResponse.Symbol.Bid, symbolsResponse.Symbol.Ask - slDistance);
					if ((risk - profitPrev.Profit!.Value > 0) && (risk - profit.Profit!.Value < 0))
					{
						position -= step;
						break;
					}
					position += step;
					if (position > 10)
					{
						throw new Exception();
					}
					profitPrev = profit;

				}
				return position;
			}
		}

		private void CreateOrderLimit(bool buy, double price, double ptDistance, double slDistance, int precision, double position)
		{
			if (buy)
			{
				APICommandFactory.ExecuteTradeTransactionCommand(
					connector,
					TRADE_OPERATION_CODE.BUY_LIMIT,
					TRADE_TRANSACTION_TYPE.ORDER_OPEN,
					price,
					Math.Round(price * slDistance, precision),
					Math.Round(price * ptDistance, precision),
					symbol,
					Math.Round(position, 2),
					null,
					null,
					null);
			}
			else
			{
				APICommandFactory.ExecuteTradeTransactionCommand(
					connector,
					TRADE_OPERATION_CODE.SELL_LIMIT,
					TRADE_TRANSACTION_TYPE.ORDER_OPEN,
					price,
					Math.Round(price * slDistance, precision),
					Math.Round(price * ptDistance, precision),
					symbol,
					Math.Round(position, 2),
					null,
					null,
					null);
			}
		}

		private void CreateOrder(bool buy, double ptDistance, double slDistance, int precision, double position)
		{
			if (buy)
			{
				APICommandFactory.ExecuteTradeTransactionCommand(
					connector,
					TRADE_OPERATION_CODE.BUY,
					TRADE_TRANSACTION_TYPE.ORDER_OPEN,
					symbolsResponse!.Symbol.Ask,
					Math.Round(symbolsResponse.Symbol.Bid!.Value * slDistance, precision),
					Math.Round(symbolsResponse.Symbol.Bid!.Value * ptDistance, precision),
					symbol,
					Math.Round(position, 2),
					null,
					null,
					null);
			}
			else
			{
				APICommandFactory.ExecuteTradeTransactionCommand(
					connector,
					TRADE_OPERATION_CODE.SELL,
					TRADE_TRANSACTION_TYPE.ORDER_OPEN,
					symbolsResponse!.Symbol.Bid,
					Math.Round(symbolsResponse.Symbol.Ask!.Value * slDistance, precision),
					Math.Round(symbolsResponse.Symbol.Ask!.Value * ptDistance, precision),
					symbol,
					Math.Round(position, 2),
					null,
					null,
					null);
			}
		}

		public void Init()
		{
			connector = new SyncAPIConnector(serverData);
			Credentials credentials = new Credentials(userId, password, "1", "XTB set orders");
			LoginResponse loginResponse = APICommandFactory.ExecuteLoginCommand(connector, credentials, true);
		}

		public double GetRisk()
		{
			return risk;
		}

		private void FullInit()
		{
			var margin = APICommandFactory.ExecuteMarginLevelCommand(connector);
			risk = margin.Equity!.Value * riskInPercent * BrokerMarginEquityCoefficient;

			//var rrr = APICommandFactory.ExecuteAllSymbolsCommand(connector);

			symbolsResponse = APICommandFactory.ExecuteSymbolCommand(connector, symbol);
			precision = (int)Math.Round((double)symbolsResponse.Symbol.Precision!.Value, 0);

			for (int i = 0; i < precision; i++)
			{
				slDistance = slDistance / 10;
			}
		}

		public void SellLimit(double price, double p1, double p2, double p3)
		{
			FullInit();

			var position = CalcPosition(false, 0.01, 0.1);
			position = CalcPosition(false, position, 0.01);

			CreateOrderLimit(false, price, 0.997, 1.005, precision, position * p1);
			if (p2 > 0)
			{
				CreateOrderLimit(false, price, 0.995, 1.005, precision, position * p2);
			}
			if (p3 > 0)
			{
				CreateOrderLimit(false, price, 0.993, 1.005, precision, position * p3);
			}
		}

		public void BuyLimit(double price, double p1, double p2, double p3)
		{
			FullInit();

			var position = CalcPosition(true, 0.01, 0.1);
			position = CalcPosition(true, position, 0.01);

			CreateOrderLimit(true, price, 1.003, 0.995, precision, position * p1);
			if (p2 > 0)
			{
				CreateOrderLimit(true, price, 1.005, 0.995, precision, position * p2);
			}
			if (p3 > 0)
			{
				CreateOrderLimit(true, price, 1.007, 0.995, precision, position * p3);
			}
		}

		public void Buy(double p1, double p2, double p3)
		{
			FullInit();

			var position = CalcPosition(true, 0.01, 0.1);
			position = CalcPosition(true, position, 0.01);

			CreateOrder(true, 1.003, 0.995, precision, position * p1);
			if (p2 > 0)
			{
				CreateOrder(true, 1.005, 0.995, precision, position * p2);
			}
			if (p3 > 0)
			{
				CreateOrder(true, 1.007, 0.995, precision, position * p3);
			}
		}

		public void Sell(double p1, double p2, double p3)
		{
			FullInit();

			var position = CalcPosition(false, 0.01, 0.1);
			position = CalcPosition(false, position, 0.01);

			CreateOrder(false, 0.997, 1.005, precision, position * p1);
			if (p2 > 0)
			{
				CreateOrder(false, 0.995, 1.005, precision, position * p2);
			}
			if (p3 > 0)
			{
				CreateOrder(false, 0.993, 1.005, precision, position * p3);
			}
		}

		public (double, double) CalculateProfit()
		{
			TradesResponse tradesResponse = APICommandFactory.ExecuteTradesCommand(connector, false);
			double profit = 0;
			double loss = 0;
			foreach (var tradeRecord in tradesResponse.TradeRecords)
			{
				if (tradeRecord.Symbol == symbol)
				{
					var result = APICommandFactory.ExecuteProfitCalculationCommand(connector, symbol, tradeRecord.Volume, tradeRecord.Open_price > tradeRecord.Tp ? TRADE_OPERATION_CODE.SELL : TRADE_OPERATION_CODE.BUY, tradeRecord.Open_price, tradeRecord.Tp);
					profit += result.Profit!.Value;
					result = APICommandFactory.ExecuteProfitCalculationCommand(connector, symbol, tradeRecord.Volume, tradeRecord.Open_price > tradeRecord.Sl ? TRADE_OPERATION_CODE.SELL : TRADE_OPERATION_CODE.BUY, tradeRecord.Open_price, tradeRecord.Sl);
					loss += result.Profit!.Value;
				}
			}
			return (profit, loss);
		}

		public string GetAccountCurrency()
		{
			var result = APICommandFactory.ExecuteCurrentUserDataCommand(connector);
			return result.Currency;
		}

		public List<Order> GetMarketOrders(bool allSymbols)
		{
			List<Order> orders = new List<Order>();

			TradesResponse tradesResponse = APICommandFactory.ExecuteTradesCommand(connector, true);

			foreach (var tradeRecord in tradesResponse.TradeRecords)
			{
				Order order = new Order();
				order.Id = tradeRecord.Order!.Value;
				order.SL = tradeRecord.Sl!.Value;
				order.PT = tradeRecord.Tp!.Value;
				order.OpenPrice = tradeRecord.Open_price!.Value;
				order.Instrument = tradeRecord.Symbol;
				order.Units = tradeRecord.Volume!.Value;
				order.Buy = tradeRecord.Cmd == TRADE_OPERATION_CODE.BUY.Code;
				if ((tradeRecord.Cmd!.Value == TRADE_OPERATION_CODE.BUY.Code) || (tradeRecord.Cmd!.Value == TRADE_OPERATION_CODE.SELL.Code))
				{
					if (allSymbols || (order.Instrument == symbol))
					{
						orders.Add(order);
					}
				}
			}
			return orders;
		}

		public List<Order> GetPendingOrders(bool allSymbols)
		{
			List<Order> orders = new List<Order>();

			TradesResponse tradesResponse = APICommandFactory.ExecuteTradesCommand(connector, true);

			foreach (var tradeRecord in tradesResponse.TradeRecords)
			{
				Order order = new Order();
				order.Id = tradeRecord.Order!.Value;
				order.SL = tradeRecord.Sl!.Value;
				order.PT = tradeRecord.Tp!.Value;
				order.OpenPrice = tradeRecord.Open_price!.Value;
				order.Instrument = tradeRecord.Symbol;
				order.Units = tradeRecord.Volume!.Value;
				order.Buy = tradeRecord.Cmd == TRADE_OPERATION_CODE.BUY_LIMIT.Code;
				if ((tradeRecord.Cmd!.Value == TRADE_OPERATION_CODE.BUY_LIMIT.Code) || (tradeRecord.Cmd!.Value == TRADE_OPERATION_CODE.SELL_LIMIT.Code))
				{
					if (allSymbols || (order.Instrument == symbol))
					{
						orders.Add(order);
					}
				}
			}
			return orders;
		}

		public void ClosePendingOrder(Order order)
		{
			APICommandFactory.ExecuteTradeTransactionCommand(
			connector,
				order.Buy ? TRADE_OPERATION_CODE.BUY : TRADE_OPERATION_CODE.SELL,
				TRADE_TRANSACTION_TYPE.ORDER_DELETE,
				NormalizeDouble(order.OpenPrice),
				NormalizeDouble(order.SL),
				NormalizeDouble(order.PT),
				order.Instrument,
				order.Units,
				order.Id,
				null,
				null);
		}

		public void CloseMarketOrder(Order order)
		{
			APICommandFactory.ExecuteTradeTransactionCommand(
			connector,
				order.Buy ? TRADE_OPERATION_CODE.BUY : TRADE_OPERATION_CODE.SELL,
				TRADE_TRANSACTION_TYPE.ORDER_CLOSE,
				NormalizeDouble(order.OpenPrice),
				NormalizeDouble(order.SL),
				NormalizeDouble(order.PT),
				order.Instrument,
				order.Units,
				order.Id,
				null,
				null);
		}

		public void ModifyPendingOrder(Order order)
		{
			APICommandFactory.ExecuteTradeTransactionCommand(
			connector,
				order.Buy ? TRADE_OPERATION_CODE.BUY_LIMIT : TRADE_OPERATION_CODE.SELL_LIMIT,
				TRADE_TRANSACTION_TYPE.ORDER_MODIFY,
				NormalizeDouble(order.OpenPrice),
				NormalizeDouble(order.SL),
				NormalizeDouble(order.PT),
				order.Instrument,
				order.Units,
				order.Id,
				null,
				null);
		}

		public void SetPositionSlAndPt(Order order)
		{
			APICommandFactory.ExecuteTradeTransactionCommand(
			connector,
				order.Buy ? TRADE_OPERATION_CODE.BUY : TRADE_OPERATION_CODE.SELL,
				TRADE_TRANSACTION_TYPE.ORDER_MODIFY,
				NormalizeDouble(order.OpenPrice),
				NormalizeDouble(order.SL),
				NormalizeDouble(order.PT),
				order.Instrument,
				order.Units,
				order.Id,
				null,
				null);
		}

		private double NormalizeDouble(double p)
		{
			return Math.Round(p, precision);
		}

		private void FillSlPt(Order order, double SlRelative, double PtRelative)
		{
			if (SlRelative != 0)
			{
				if (order.Units > 0)
				{
					order.SL = NormalizeDouble(order.OpenPrice - SlRelative);
				}
				else
				{
					order.SL = NormalizeDouble(order.OpenPrice + SlRelative);
				}
			}
			if (PtRelative != 0)
			{
				if (order.Units > 0)
				{
					order.PT = NormalizeDouble(order.OpenPrice + PtRelative);
				}
				else
				{
					order.PT = NormalizeDouble(order.OpenPrice - PtRelative);
				}
			}
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
			ModifyPendingOrder(order);
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

		public (string, double) GetLatestProfit(string instrument)
		{
			TradesResponse tradesResponse = APICommandFactory.ExecuteTradesCommand(connector, false);
			var tradeRecords =
				tradesResponse.TradeRecords
				.Where(x => x.Closed!.Value && instrument == x.Symbol)
				.OrderByDescending(x => x.Close_time)
				.ToList();
		
			if (tradeRecords.Any())
			{
				return (instrument, tradeRecords[0].Profit!.Value);
			}
			else
			{
				return (instrument, 0);
			}
		}
	}
}
