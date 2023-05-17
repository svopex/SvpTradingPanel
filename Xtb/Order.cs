using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xtb
{
	public class Order
	{
		public long Id { get; set; }
		public double OpenPrice { get; set; }
		public double SL { get; set; }
		public double PT { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public string Instrument { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public double Units { get; set; }
		public bool Buy { get; set; }
		public string? Comment{ get; set; }
	}
}
