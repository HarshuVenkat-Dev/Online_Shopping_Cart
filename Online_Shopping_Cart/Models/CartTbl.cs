using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Shopping_Cart.Models
{
    public partial class CartTbl
    {
        public int Id { get; set; }
        public string ShoppingId { get; set; }
        public int? ProductId { get; set; }
        public string UserId { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public int? Totalprice { get; set; }
        public int? Cartproductid { get; set; }
    }
}
