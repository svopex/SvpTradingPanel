using System.Collections.Generic;

namespace Mt5Api
{
    public class Order
    {
        public long Id { get; set; }
        public double Price { get; set; }
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
