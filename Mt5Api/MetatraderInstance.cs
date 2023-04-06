using Mt4Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mt5Api
{
	public class MetatraderInstance
	{
		private static ISvpMt svpMt5Instance = new SvpMT5();
		private static ISvpMt svpMt4Instance = new SvpMT4();		

		public static ISvpMt Instance { get; set; }

		public static bool Connect()
		{
			if (svpMt5Instance.Connect())
			{
				Instance = svpMt5Instance;
				return true;
			}
			if (svpMt4Instance.Connect())
			{
				Instance = svpMt4Instance;
				return true;
			}
			return false;
		}

		public static bool IsConnected()
		{
			if (svpMt5Instance.isConnected())
			{
				Instance = svpMt5Instance;
				return true;
			}
			if (svpMt4Instance.isConnected())
			{
				Instance = svpMt4Instance;
				return true;
			}
			svpMt5Instance.Disconnect();
			svpMt5Instance.Connect();
			svpMt4Instance.Disconnect();
			svpMt4Instance.Connect();

			return false;
		}
	}
}
