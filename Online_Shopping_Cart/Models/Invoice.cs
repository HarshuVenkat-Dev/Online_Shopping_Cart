using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shopping_Cart.Models
{
    public class Invoice
    {
        public int Orderid { get; set; }
        public int? Productid { get; set; }
        public int? Price { get; set; }
        public int? Quantity { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
