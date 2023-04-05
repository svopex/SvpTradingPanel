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
			bool connected = SvpMT4.Instance.Connect();

			while (!SvpMT4.Instance.isConnected())
			{
				Task.Delay(100);
			}

			var orders = SvpMT4.Instance.GetMarketOrders();
		}
	}
}
