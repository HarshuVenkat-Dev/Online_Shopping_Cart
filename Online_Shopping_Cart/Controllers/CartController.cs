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
        public IActionResult Addtocart([FromBody] OrderDetail orderDetail)
        {
            using (var context = new Shopping_cartContext())
            {
                try
                {
                    if (ModelState.IsValid)
                    {

                        /*var match = Regex.Match(context.CartTbls.Max(x => x.ShoppingId), @"^([^0-9]+)([0-9]+)$");
                        var num = int.Parse(match.Groups[2].Value);
                        match.Groups[1].Value + (num + 1);*/
                        context.OrderDetails.Add(orderDetail);
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


        [HttpPost()]
        public IActionResult order([FromBody] Order value)
        {
            using (var context = new Shopping_cartContext())
            {
                var data=0;
                if (ModelState.IsValid)
                {
                    value.CreatedDate =  DateTime.Now;
                    data = context.Orders.Max(x => x.Orderid)+1; 
                    context.Orders.Add(value);
                    context.SaveChanges();
                }
                return Ok(data);
            }
        }



        [HttpPost()]
        public IActionResult PostOrderdetails([FromBody] OrderDetail od)
        {
            using (var context = new Shopping_cartContext())
            {
                if (ModelState.IsValid)
                {                  
                    context.OrderDetails.Add(od);
                    context.SaveChanges();
                }
                return Ok("Success");
            }
        }


        [HttpGet("{UserId}")]
        public IEnumerable<Order> orderhistory(int Userid)
        {
            using (var context = new Shopping_cartContext())
            {
                var result = (from order in context.Orders where order.Userid == Userid select order).ToList();
                return result;
            }
            
        }


        [HttpGet("{orderid}")]
        public IEnumerable<OrderDetail> orderinvoice(int orderid)
        {
            using (var context = new Shopping_cartContext())
            {
                var result = (from orderd in context.OrderDetails where orderd.Orderid == orderid select orderd).ToList();
                return result;
            }

        }




        [HttpGet("{UserId}")]
        public IEnumerable<CustomHistoryResponse> Get(string UserId)
        {
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

                /*List<CustomHistoryResponse> lstmain = new List<CustomHistoryResponse>();*/
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
            }
        }
    }
}