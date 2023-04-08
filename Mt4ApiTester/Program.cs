using Mt4Api;
using Mt5Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mt4ApiTester
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool connected = MetatraderInstance.Connect();

			while (!MetatraderInstance.IsConnectedConsole())
			{
				Task.Delay(100);
			}

			//var xxx = MetatraderInstance.Instance.DailyClose(1);

			//var yyy = MetatraderInstance.Instance.GetMarketOrders();

			var wtrsHigh = MetatraderInstance.Instance.WtrsHigh();
			var wtrsLow = MetatraderInstance.Instance.WtrsLow();
			var actualBidPrice = MetatraderInstance.Instance.GetActualBidPrice();
			var actualAskPrice = MetatraderInstance.Instance.GetActualAskPrice();
			var WtrsAtr5 = MetatraderInstance.Instance.WtrsAtr(5);
			var WtrsAtr10 = MetatraderInstance.Instance.WtrsAtr(10);
			var spread = actualAskPrice - actualBidPrice;
			var symbolPoint = MetatraderInstance.Instance.SymbolPoint();
			var symbolTradeTickValue = MetatraderInstance.Instance.SymbolTradeTickValue();

			// Short calculation
			var shortDifferenceBetweenSLAndActualPrice = wtrsHigh + spread - actualBidPrice; // Bid price, protoze na ni jsem nakupoval a na ni bude ztrata
			var shortPositionSize = MetatraderInstance.Instance.AccountEquity() * 0.01 / (shortDifferenceBetweenSLAndActualPrice / symbolPoint * symbolTradeTickValue);
			var shortSlPrice = wtrsHigh + spread; //(wtrsHigh - actualBidPrice) + spread + actualBidPrice;
			var shortTpPrice = actualAskPrice - WtrsAtr5; // ASK price, protoze na ni prodavam pri shortu
			var shortTpPrice2 = actualAskPrice - WtrsAtr10; // ASK price, protoze na ni prodavam pri shortu

			// Long calculation
			var longDifferenceBetweenSLAndActualPrice = actualAskPrice - (wtrsLow - spread) ; // Ask price, protoze na ni jsem nakupoval a na ni bude ztrata
			var longPositionSize = MetatraderInstance.Instance.AccountEquity() * 0.01 / (longDifferenceBetweenSLAndActualPrice / symbolPoint * symbolTradeTickValue);
			var longSlPrice = wtrsLow - spread;
			var longTpPrice = actualBidPrice + WtrsAtr5; // ASK price, protoze na ni prodavampri shortu
			var longTpPrice2 = actualBidPrice + WtrsAtr10; // ASK price, protoze na ni prodavampri shortu

			//using (var client = new HttpClient())
			//{
			//	var url = "http://localhost/hueSl";
			//	var body = "This is the body of the request.";
			//	var content = new StringContent(body);
			//	var response = client.PostAsync(url, content).GetAwaiter().GetResult();
			//}
		}
	}
}
