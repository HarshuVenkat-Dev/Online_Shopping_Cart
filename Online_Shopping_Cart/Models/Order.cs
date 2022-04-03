using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Online_Shopping_Cart.Models
{
    public partial class Order
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Orderid { get; set; }
        public int Userid { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
