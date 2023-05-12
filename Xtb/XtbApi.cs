using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using xAPI.Codes;
using xAPI.Commands;
using xAPI.Responses;
using xAPI.Sync;

namespace Xtb
{
	public class XtbApi
	{
		private Server serverData = Servers.DEMO;
		private string userId = "14734282";
		private string password = "HarryPotter6951!";
		private double riskInPercent = 0.01;

		private string symbol = "USDJPY";
		private double slDistance = 185;

		private double risk;
		private SyncAPIConnector? connector = null;
		private SymbolResponse? symbolsResponse = null;
		private int precision;

		public XtbApi(string symbol, double slDistance)
		{
			this.symbol = symbol;
			this.slDistance = slDistance;
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

		private void Init()
		{
			connector = new SyncAPIConnector(serverData);
			Credentials credentials = new Credentials(userId, password, "1", "XTB set orders");
			LoginResponse loginResponse = APICommandFactory.ExecuteLoginCommand(connector, credentials, true);

			var margin = APICommandFactory.ExecuteMarginLevelCommand(connector);
			risk = margin.Equity!.Value * riskInPercent;

			symbolsResponse = APICommandFactory.ExecuteSymbolCommand(connector, symbol);
			precision = (int)Math.Round((double)symbolsResponse.Symbol.Precision!.Value, 0);

			for (int i = 0; i < precision; i++)
			{
				slDistance = slDistance / 10;
			}
		}

		public void SellLimit(double price, double p1, double p2, double p3)
		{
			Init();

			var position = CalcPosition(false, 0.01, 0.1);
			position = CalcPosition(false, position, 0.01);

			CreateOrderLimit(false, price, 0.997, 1.005, precision, position * p1);
			CreateOrderLimit(false, price, 0.995, 1.005, precision, position * p2);
			CreateOrderLimit(false, price, 0.993, 1.005, precision, position * p3);
		}

		public void BuyLimit(double price, double p1, double p2, double p3)
		{
			Init();

			var position = CalcPosition(true, 0.01, 0.1);
			position = CalcPosition(true, position, 0.01);

			CreateOrderLimit(true, price, 1.003, 0.995, precision, position * p1);
			CreateOrderLimit(true, price, 1.005, 0.995, precision, position * p2);
			CreateOrderLimit(true, price, 1.007, 0.995, precision, position * p3);
		}

		public void Buy(double p1, double p2, double p3)
		{
			Init();

			var position = CalcPosition(true, 0.01, 0.1);
			position = CalcPosition(true, position, 0.01);

			CreateOrder(true, 1.003, 0.995, precision, position * p1);
			CreateOrder(true, 1.005, 0.995, precision, position * p2);
			CreateOrder(true, 1.007, 0.995, precision, position * p3);
		}

		public void Sell(double p1, double p2, double p3)
		{
			Init();

			var position = CalcPosition(false, 0.01, 0.1);
			position = CalcPosition(false, position, 0.01);

			CreateOrder(false, 0.997, 1.005, precision, position * p1);
			CreateOrder(false, 0.995, 1.005, precision, position * p2);
			CreateOrder(false, 0.993, 1.005, precision, position * p3);
		}

		public (double, double) CalculateProfit()
		{
			Init();
			TradesResponse tradesResponse = APICommandFactory.ExecuteTradesCommand(connector, false);
			double profit = 0;
			double loss = 0;
			foreach (var tradeRecord in tradesResponse.TradeRecords)
			{
				var result = APICommandFactory.ExecuteProfitCalculationCommand(connector, symbol, tradeRecord.Volume, tradeRecord.Open_price > tradeRecord.Tp ? TRADE_OPERATION_CODE.SELL : TRADE_OPERATION_CODE.BUY, tradeRecord.Open_price, tradeRecord.Tp);
				profit += result.Profit!.Value;
				result = APICommandFactory.ExecuteProfitCalculationCommand(connector, symbol, tradeRecord.Volume, tradeRecord.Open_price > tradeRecord.Sl ? TRADE_OPERATION_CODE.SELL : TRADE_OPERATION_CODE.BUY, tradeRecord.Open_price, tradeRecord.Sl);
				loss += result.Profit!.Value;
			}
			return (profit, loss);
		}

		public string GetAccountCurrency()
		{
			Init();
			var result = APICommandFactory.ExecuteCurrentUserDataCommand(connector);
			return result.Currency;
		}
	}
}
