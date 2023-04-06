using Mt4Api;
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
			bool connected = Mt4Api.Mt4Api.Instance.Connect();

			while (!Mt4Api.Mt4Api.Instance.isConnected())
			{
                Task.Delay(100);
			}

			var orders = Mt4Api.Mt4Api.Instance.GetMarketOrders();
		}
	}
}
