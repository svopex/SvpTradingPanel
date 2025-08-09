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
		private const int Parameters = 8;

		/*
		MT5 8228 SvpTradingPanel 0 0.01 1 100 0

		MT5/MT4 - verze Metatraderu
		8228 - port pluginu
		SvpTradingPanel - strategy name
		0 - account equity, pokud je 0, tak se bere equity value od brokera
		0.01 - risk to trade, pokud je 0, tak se bere 1% equity, 0.01 = 1%
		1 - broker margin equity coefficient, pokud je 1, tak se bere realna hodnota equity, jinak se vynasobi s hodnotou equity, pouziva se, pokud chi velkou paku a u brokera mit mene penez
		100 - track bar position using, kolik beru z pozice, 100 = 100%, 50 = 50%, 2000 = 200%
		0 - tick value compensation, pokud je 1, pozice se nasobi kurzem USDCZK, protoze vypocet pak napriklad u PurpleTrading chodi spatne
			Doporucene hodnoty:
				PurpleTrading = 1
				FTMO = 0
		*/

		public static bool TickValueCompensation
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > Parameters)
				{
					return Int32.Parse(args[8]) == 1;
				}
				else
				{
					return false;
				}
			}
		}

		public static int TrackBarPositionUsing
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > Parameters)
				{
					return Int32.Parse(args[7]);
				}
				else
				{
					return 100;
				}
			}
		}

		public static double AccountEquity
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > Parameters)
				{
					return Double.Parse(args[4]);
				}
				else
				{
					return 0;
				}
			}
		}

		// Chci 1% risk na obchod.
		public static double RiskToTrade
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > Parameters)
				{
					return Double.Parse(args[5]);
				}
				else
				{
					return 0.01;
				}
			}
		}

		// Na uctu mam realne 1/4 hodnoty uctu (kvuli nebezpeci krachu brokera).
		public static double BrokerMarginEquityCoefficient
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > Parameters)
				{
					return Double.Parse(args[6]);
				}
				else
				{
					return 1;
				}
			}
		}

		public static string Host => "localhost";
		public static int PortMt4
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > Parameters)
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
				if (args.Length > Parameters)
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
				if (args.Length > Parameters)
				{
					return (args[3].ToLower() == "-") ? null : args[3];
				}
				else
				{
					return null;
				}
			}
		}

		public static MetatraderType MetatraderType
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > Parameters)
				{
					return (args[1].ToLower() == "mt4") ? MetatraderType.Mt4 : MetatraderType.Mt5;
				}
				else
				{
					return MetatraderType.All;
				}
			}
		}

		private const int XtbParameters = 7;

		public static string XtbUserId
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > XtbParameters)
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
				if (args.Length > XtbParameters)
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
				if (args.Length > XtbParameters)
				{
					return args[3] == "DEMO" ? Servers.DEMO : Servers.REAL;
				}
				else
				{
					return null;
				}
			}
		}

		public static string XtbComment
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > XtbParameters)
				{
					return args[4];
				}
				else
				{
					return null;
				}
			}
		}

		public static double XtbAccountEquity
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > XtbParameters)
				{
					return Double.Parse(args[5]);
				}
				else
				{
					return 0;
				}
			}
		}

		public static double XtbRiskInPercent
		{
			get
			{
				string[] args = Environment.GetCommandLineArgs();
				if (args.Length > XtbParameters)
				{
					return Double.Parse(args[6]);
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
				if (args.Length > XtbParameters)
				{
					return Double.Parse(args[7]);
				}
				else
				{
					return 1;
				}
			}
		}

		public static ulong StrategyNumber => 0;
        public static ErrorMessageToEnum ErrorMessageDestination => ErrorMessageToEnum.none;
    }
}
