using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using xAPI.Sync;

namespace Utils
{
	public class Utilities
	{
		// Chci 1% risk na obchod.
		public static double RiskToTrade
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > 5)
				{
					return Double.Parse(args[4]);
				}
				else
				{
					return 0.01;
				}
			}
		}

		// Na uctu mam realne 1/4 hodnoty uctu (kvuli nebezpeci krachu brokera).
		public static int BrokerMarginEquityCoefficient
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > 5)
				{
					return Int32.Parse(args[5]);
				}
				else
				{
					return 4;
				}
			}
		}

		public static string Host => "localhost";
		public static int PortMt4
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > 5)
				{
					return Int32.Parse(args[2]);
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
				if (args.Length > 5)
				{
					return Int32.Parse(args[2]);
				}
				else
				{
					return 8228;
				}
			}
		}
		public static string StrategyName
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > 5)
				{
					return args[3];
				}
				else
				{
					return "Default";
				}
			}
		}

		public static MetatraderType MetatraderType
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > 5)
				{
					return (args[1].ToLower() == "mt4") ? MetatraderType.Mt4 : MetatraderType.Mt5;
				}
				else
				{
					return MetatraderType.All;
				}
			}
		}

		public static string XtbUserId
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > 5)
				{
					return args[1];
				}
				else
				{
					return null;
				}
			}
		}

		public static string XtbPassword
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > 5)
				{
					return args[2];
				}
				else
				{
					return null;
				}
			}
		}

		public static Server XtbServerType
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > 5)
				{
					return args[3] == "DEMO" ? Servers.DEMO : Servers.REAL;
				}
				else
				{
					return null;
				}
			}
		}

		public static double XtbRiskInPercent
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > 5)
				{
					return Double.Parse(args[4]);
				}
				else
				{
					return 0.01;
				}
			}
		}

		public static double XtbBrokerMarginEquityCoefficient
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > 5)
				{
					return Double.Parse(args[5]);
				}
				else
				{
					return 0.01;
				}
			}
		}

		public static ulong StrategyNumber => 6877;
        public static ErrorMessageToEnum ErrorMessageDestination => ErrorMessageToEnum.none;
    }
}
