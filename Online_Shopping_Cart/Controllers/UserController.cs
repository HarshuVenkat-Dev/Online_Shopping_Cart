using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Shopping_Cart.Models;
using Online_Shopping_Cart.Service;
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
                var loginstr = context.Logins.Where(b => b.EmailId == value.EmailId).FirstOrDefault();
                if (loginstr != null)
                {
                    PasswordHasherManager phm = new PasswordHasherManager();
                    loginstr.Password = phm.HashPassword(value.NewPassword);
                    context.Entry(loginstr).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok("Success");
                }
            }
            return Ok("Failed");
        }


        [HttpPut]
        public IActionResult userprofileupdate([FromBody] Login value)
        {
            using (var context = new Shopping_cartContext())
            {
                var loginstr = context.Logins.Where(b => b.EmailId == value.EmailId).FirstOrDefault();
                if (loginstr != null)
                {
                    loginstr.FirstName = value.FirstName;
                    loginstr.LastName = value.LastName;
                    loginstr.Address = value.Address;
                    context.Entry(loginstr).State = EntityState.Modified;   
                    context.SaveChanges();
                    return Ok("Success");
                }
            }
            return Ok("Failed");
        }
    }
}