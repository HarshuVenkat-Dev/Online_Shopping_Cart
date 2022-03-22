using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Shopping_Cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shopping_Cart.Controllers
{
    [ApiController]
    [Route("{controller}/{action}")]
    public class UserController : ControllerBase
    {
        [HttpPut]
        public IActionResult userprofile([FromBody] ChangePassword value)
        {
            using (var context = new Shopping_cartContext())
            {
                var loginstr = context.Logins.Where(b => b.EmailId == value.EmailId && b.Password == value.CurrentPassword.Trim()).FirstOrDefault();
                if (loginstr != null)
                {
                    loginstr.Password = value.NewPassword.Trim();
                    context.Entry(loginstr).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok("Success");
                }
            }
            return Ok("Failed");
        }
    }
}
