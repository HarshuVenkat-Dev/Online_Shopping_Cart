using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Shopping_Cart.Models
{
    public partial class OrderDetail
    {
        public int Orderdetailsid { get; set; }
        public int Orderid { get; set; }
        public int? Productid { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
