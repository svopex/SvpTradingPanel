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
			//bool connected = MetatraderInstance.Connect();

			//while (!MetatraderInstance.IsConnectedConsole())
			//{
			//	Task.Delay(100);
			//}

			//var xxx = MetatraderInstance.Instance.DailyClose(1);

			//var yyy = MetatraderInstance.Instance.GetMarketOrders();

			using (var client = new HttpClient())
			{
				var url = "http://localhost/hueSl";
				var body = "This is the body of the request.";
				var content = new StringContent(body);
				var response = client.PostAsync(url, content).GetAwaiter().GetResult();
			}
		}
	}
}
