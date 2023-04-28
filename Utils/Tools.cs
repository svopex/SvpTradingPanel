using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Utils
{
    public class Utilities
    {
        public static string Host => "localhost";
        public static int PortMt4
        {
            get
            {
				string[] args = Environment.GetCommandLineArgs();
                if (args.Length > 1)
                {
                    return Int32.Parse(args[1]);
                }
                else
                {
                    return 8222;
                }
			}
        }
		public static int PortMt5
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > 1)
				{
					return Int32.Parse(args[1]);
				}
				else
				{
					return 8228;
				}
			}
		}
		//public static string StrategyName => "SvpTradingPanel";
		public static ulong StrategyNumber => 6877;
        public static ErrorMessageToEnum ErrorMessageDestination => ErrorMessageToEnum.none;
    }
}
