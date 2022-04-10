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
    public class AddressController : ControllerBase
    {
        [HttpPost()]
        public IActionResult address([FromBody] AddressTbl addressTbl)
        {
            using (var context = new Shopping_cartContext())
            {
                /*var id = 0;*/
                if (ModelState.IsValid)
                {
                    context.AddressTbls.Add(addressTbl);
                    context.SaveChanges();
                }
                return Ok("Success");
            }
        }
    }
}
