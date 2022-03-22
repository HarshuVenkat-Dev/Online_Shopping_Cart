using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shopping_Cart.Service
{
    public class PasswordHasherManager
    {
        public string HashPassword(string password)
        {
            return EncryptPwd.GetMDSHash(password);
        }

        public string VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (hashedPassword == HashPassword(providedPassword))
            {
                return "Success";
            }
            return "Failed";
        }
    }
}
