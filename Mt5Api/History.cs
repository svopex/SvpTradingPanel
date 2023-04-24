using System;
using System.Collections.Generic;
using System.Text;

namespace Mt5Api
{
	public class History
	{
		public DateTime dt { get; set; }
		public double profit { get; set; }
	}

	public class Histories : List<History>
	{

	}
}
