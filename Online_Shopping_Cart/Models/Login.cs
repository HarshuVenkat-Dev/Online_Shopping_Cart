using System;
using System.Collections.Generic;

#nullable disable

namespace Online_Shopping_Cart.Models
{
    public partial class Login
    {
        public string UserId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
