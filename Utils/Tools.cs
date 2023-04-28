﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
				if (args.Length > 4)
				{
					return Double.Parse(args[3]);
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
				if (args.Length > 4)
				{
					return Int32.Parse(args[4]);
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
				if (args.Length > 4)
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
				if (args.Length > 4)
				{
					return Int32.Parse(args[1]);
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
				if (args.Length > 4)
				{
					return args[2];
				}
				else
				{
					return "Default";
				}
			}
		}
		public static ulong StrategyNumber => 6877;
        public static ErrorMessageToEnum ErrorMessageDestination => ErrorMessageToEnum.none;
    }
}
