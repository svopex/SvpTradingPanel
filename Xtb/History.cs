using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtb
{
	public class History
	{
		public DateTime dt { get; set; }
		public double profit { get; set; }
		public double swap { get; set; }
		public double commission { get; set; }
		public string? comment { get; set; }
	}
}
