using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Shopping_Cart.Models
{
    public partial class CartTbl
    {
        public string ShoppingId { get; set; }
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
    }
}
