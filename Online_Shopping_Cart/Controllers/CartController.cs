using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Shopping_Cart.Models;
using Online_Shopping_Cart.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
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
                        
                        var match = Regex.Match(context.CartTbls.Max(x => x.ShoppingId), @"^([^0-9]+)([0-9]+)$");
                        var num = int.Parse(match.Groups[2].Value);
                        cartt.ShoppingId = match.Groups[1].Value + (num + 1);
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
        public IEnumerable<CustomHistoryResponse> Get(string UserId)
        {
            /*List<CustomHistoryResponse> lstmain = new List<CustomHistoryResponse>();*/
            using (var context = new Shopping_cartContext())
            {

                var result = (from row in context.CartTbls
                              join p in context.ProductTables on row.ProductId equals p.Id 
                              where row.UserId == UserId
                              select new CustomHistoryResponse()
                              {
                                  ShoppingId = row.ShoppingId,
                                  ProductId=row.ProductId.ToString(),
                                  UserId=row.UserId,
                                  Quantity= row.Quantity,
                                  Price= row.Price,
                                  Totalprice=row.Totalprice,
                                  Cartproductid=row.Cartproductid,
                                  Title=p.Title ,
                                  Description= p.Description,
                                  Category=p.Category,
                                  Image=p.Image

                              }).ToList();

                /*var result = select c.*, p.* from context.CartTbl as c join context.ProductTable as p on p.ID = c.ProductId where c.UserId = 1003;*/



                /*using (SqlConnection con = new SqlConnection("data source=ATMECSINLT-684\\MSSQLSERVERNEW; database=Shopping_cart; Integrated security=true"))
                    {
                        string query = "select c.*, p.* from Cart_tbl as c join ProductTable as p on p.ID = c.ProductId where c.UserId ='" + UserId + "'";
                        SqlCommand cmd = new SqlCommand(query, con);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                         DataTable dt = new DataTable();
                        da.Fill(dt);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CustomHistoryResponse obj = new CustomHistoryResponse();
                        obj.ShoppingId = dt.Rows[i]["ShoppingId"].ToString();
                        obj.ProductId= dt.Rows[i]["ProductId"].ToString();
                        obj.Title = dt.Rows[i]["Title"].ToString();
                        obj.Image = dt.Rows[i]["Image"].ToString();
                        obj.Description = dt.Rows[i]["Description"].ToString();
                        obj.Price = Convert.ToInt32( dt.Rows[i]["Price"]);
                        obj.Quantity = Convert.ToInt32(dt.Rows[i]["Quantity"].ToString());
                        obj.Totalprice = Convert.ToInt32(dt.Rows[i]["Totalprice"].ToString());
                        lstmain.Add(obj);
                    }
                    }
                return lstmain;*/

                // select sd;
                return (IEnumerable<CustomHistoryResponse>)result;
                /*}*/
            }
        }


        [HttpGet("{userId}")]
        public IActionResult CartHistory(string userId)
        {

            return Ok();
        }
    }
}