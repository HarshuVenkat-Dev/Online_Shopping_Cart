using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shopping_Cart.Models
{
    public class CustomHistoryResponse
    {
        public int Id { get; set; }
        public string ShoppingId { get; set; }
        public string ProductId { get; set; }
        public string UserId { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public int? Totalprice { get; set; }
        public int? Cartproductid { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
