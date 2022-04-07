using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Shopping_Cart.Models
{
    public partial class Order
    {
        public int Orderid { get; set; }
        public int Userid { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
