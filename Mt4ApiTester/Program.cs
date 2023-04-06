using Mt4Api;
using Mt5Api;
using System;
using System.Collections.Generic;
using System.Linq;
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

			var xxx = MetatraderInstance.Instance.DailyClose(1);

			var yyy = MetatraderInstance.Instance.GetMarketOrders();
		}
	}
}
