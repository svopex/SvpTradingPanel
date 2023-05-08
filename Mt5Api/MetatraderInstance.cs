using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace Mt5Api
{
	public class MetatraderInstance
	{
		private static ISvpMt svpMt5Instance = new Mt5Api();
		private static ISvpMt svpMt4Instance = new Mt4Api.Mt4Api();		

		public static ISvpMt Instance { get; set; }

		public static bool Connect()
		{			
			if ((Utilities.MetatraderType == MetatraderType.All || Utilities.MetatraderType == MetatraderType.Mt5) && svpMt5Instance.Connect())
			{
				Instance = svpMt5Instance;
				return true;
			}
			if ((Utilities.MetatraderType == MetatraderType.All || Utilities.MetatraderType == MetatraderType.Mt4) && svpMt4Instance.Connect())
			{
				Instance = svpMt4Instance;
				return true;
			}
			return false;
		}

		public static bool IsConnectedConsole()
		{
			if ((Utilities.MetatraderType == MetatraderType.All || Utilities.MetatraderType == MetatraderType.Mt5) && svpMt5Instance.IsConnectedConsole())
			{
				Instance = svpMt5Instance;
				return true;
			}
			if ((Utilities.MetatraderType == MetatraderType.All || Utilities.MetatraderType == MetatraderType.Mt4) && svpMt4Instance.IsConnectedConsole())
			{
				Instance = svpMt4Instance;
				return true;
			}			
			return false;
		}

		public static bool IsConnected()
		{
			if ((Utilities.MetatraderType == MetatraderType.All || Utilities.MetatraderType == MetatraderType.Mt5) && svpMt5Instance.IsConnected())
			{
				Instance = svpMt5Instance;
				return true;
			}
			if ((Utilities.MetatraderType == MetatraderType.All || Utilities.MetatraderType == MetatraderType.Mt4) && svpMt4Instance.IsConnected())
			{
				Instance = svpMt4Instance;
				return true;
			}

			if (Utilities.MetatraderType == MetatraderType.All || Utilities.MetatraderType == MetatraderType.Mt5)
			{
				svpMt5Instance.Disconnect();
				svpMt5Instance.Connect();
			}
			if (Utilities.MetatraderType == MetatraderType.All || Utilities.MetatraderType == MetatraderType.Mt4)
			{
				svpMt4Instance.Disconnect();
				svpMt4Instance.Connect();
			}

			return false;
		}
	}
}
