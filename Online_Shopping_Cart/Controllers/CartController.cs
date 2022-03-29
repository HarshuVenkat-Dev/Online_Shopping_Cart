using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class CartController : ControllerBase
    {
        [HttpPost()]
        public IActionResult Addtocart([FromBody] CartTbl cartt)
        {
            using (var context = new Shopping_cartContext())
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        context.CartTbls.Add(cartt);
                        context.SaveChanges();
                        return Ok("Success");
                    }
                    else
                    {
                        return BadRequest("Failed");
                    }
                }
                catch (Exception ex)
                {
                    return NotFound("Failed" + ex);
                }
            }
        }

        [HttpGet("{UserId}")]
        public IEnumerable<CartTbl> Get(string UserId)
        {
            using (var context = new Shopping_cartContext())
            {
                
                var result = (from row in context.CartTbls
                             join p in context.ProductTables on row.ProductId equals p.Id into g
                             from rowp in g.DefaultIfEmpty()
                             where row.UserId == UserId
                             select new { rowp}).ToList();
                // select sd;
                return (IEnumerable<CartTbl>)result;
            }
        }


        [HttpGet("{userId}")]
        public IActionResult CartHistory(string userId)
        {

            return Ok();
        }
    }
}