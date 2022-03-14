using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Shopping_Cart.Models
{
    public partial class Login
    {
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
