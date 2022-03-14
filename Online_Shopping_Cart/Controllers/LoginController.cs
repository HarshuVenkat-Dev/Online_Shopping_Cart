using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Shopping_Cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shopping_Cart.Controllers
{
    [ApiController]
    [Route("{controller}/{action}")]
    public class LoginController : ControllerBase
    {

        public IActionResult PostRegister([FromBody] Login value)
        {
            using (var context = new Shopping_cartContext())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        context.Logins.Add(value);
                        context.SaveChanges();
                        return Ok("New Employee Created Status Code: 201");
                    }
                    else
                    {
                        return BadRequest("Bad Request Status Code: 404");
                    }
                }
                catch (Exception ex)
                {
                    return NotFound("Bad Request Status Code: 404" + ex);
                }
            }
        }

        [HttpGet("{email}")]
        public Login GetByemail(string email)
        {
            using (var context = new Shopping_cartContext())
            {
                var loginData = context.Logins.Find(email);

                return loginData;
            }
        }
    }
}
