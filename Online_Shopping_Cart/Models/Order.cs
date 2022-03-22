using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Shopping_Cart.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public string Price { get; set; }
        public int? Quantity { get; set; }
        public int? UserId { get; set; }
    }
}
