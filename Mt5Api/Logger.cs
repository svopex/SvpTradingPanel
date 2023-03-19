using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mt5Api
{
    public class Logger
    {
        private static object o = new object();

        public static void WriteLine(string s)
        {
            Console.WriteLine(s);

            lock (o)
            {
                File.AppendAllText("SvpTradingPanel.log", s + "\n");
            }
        }

        public static void WriteLineError(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();

            lock (o)
            {
                File.AppendAllText("SvpTradingPanel.log", "!!! " + s + "\n");
            }
        }
    }
}
