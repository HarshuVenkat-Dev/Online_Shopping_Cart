using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Shopping_Cart.Models
{
    public partial class AddressTbl
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Pincode { get; set; }
    }
}
