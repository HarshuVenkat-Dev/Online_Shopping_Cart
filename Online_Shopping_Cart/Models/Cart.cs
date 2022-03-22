using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Shopping_Cart.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string Price { get; set; }
        public int? Quantity { get; set; }
        public int? UserId { get; set; }
    }
}
