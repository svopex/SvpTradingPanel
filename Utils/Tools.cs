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
        public static int Port => 8228;
        //public static string StrategyName => "SvpTradingPanel";
        public static ulong StrategyNumber => 6877;
        public static ErrorMessageToEnum ErrorMessageDestination => ErrorMessageToEnum.none;
    }
}
