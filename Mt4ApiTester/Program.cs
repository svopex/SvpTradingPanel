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
			var orders = SvpMT4.Instance.GetMarketOrders();
		}
	}
}
