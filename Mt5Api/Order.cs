using System;
using System.Collections.Generic;

namespace Mt5Api
{
    public class Order
    {
        public long Id { get; set; }
        public double OpenPrice { get; set; }
		public double CurrentPrice { get; set; }
		public DateTime OpenTime { get; set; }
		public double SL { get; set; }
        public double PT { get; set; }
        public string Instrument { get; set; }
        public double Units { get; set; }
        public ulong Magic { get; set; }
        public string Comment { get; set; }
    }

    public class Orders : List<Order>
    {
    }
}
