using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Shopping_Cart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Online_Shopping_Cart.Service;
using Microsoft.AspNet.Identity;

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
                    PasswordHasherManager phm = new PasswordHasherManager();
                    value.Password = phm.HashPassword(value.Password);
                    if (ModelState.IsValid)
                    {
                        context.Logins.Add(value);
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


        [HttpGet("{email}")]
        public Login GetByemail(string email)
        {
            using (var context = new Shopping_cartContext())
            {
                var loginData = context.Logins.Find(email);

                return loginData;
            }
        }


        [HttpPost()]
        public Login GetByEmailPassword([FromBody] Login value)
        {
            using (var context = new Shopping_cartContext())
            {
                var loginData = context.Logins.Find(value.EmailId);
                if (loginData != null)
                {
                    PasswordHasherManager phm2 = new PasswordHasherManager();
                    string newPwd = phm2.VerifyHashedPassword(loginData.Password, value.Password.Trim());
                    if (newPwd == "Success")
                    {
                        loginData.Token = "loggedin";
                        return loginData;
                    }
                }
                return loginData;
            }
        }


        [Produces("application/json")]
        [HttpGet("{emailId}")]
        public IActionResult ForgetPassword(string emailId)
        {
            using (var context = new Shopping_cartContext())
            {
                var loginData1 = context.Logins.Find(emailId);
                string token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                if (loginData1 != null)
                {
                    try
                    {
                        loginData1.Token = token;
                        context.Entry(loginData1).State = EntityState.Modified;
                        context.SaveChanges();
                        MailMessage mail = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                        mail.From = new MailAddress("harshini.venkatesan@atmecs.com");
                        mail.To.Add(loginData1.EmailId);
                        mail.Subject = "Forget Password";
                        mail.Body = token;

                        SmtpServer.Port = 587;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("harshini.venkatesan@atmecs.com", "Haha@1426vesa");
                        SmtpServer.EnableSsl = true;
                        SmtpServer.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    return Ok("Success");
                }
            }
            return Ok("failed");
        }


        [HttpPost()]
        public IActionResult SetPassword([FromBody] Login value)
        {
            using (var context = new Shopping_cartContext())
            {
                //var loginData2 = context.Logins.Find(token);
                var loginstr = context.Logins.Where(b => b.Token == value.Token && b.EmailId == value.EmailId).FirstOrDefault();
                if (loginstr != null)
                {
                    PasswordHasherManager phm = new PasswordHasherManager();
                    loginstr.Password = phm.HashPassword(value.Password);
                    loginstr.Password = value.Password;
                    loginstr.Token = null;
                    context.Entry(loginstr).State = EntityState.Modified;
                    context.SaveChanges();
                    return Ok("Success");
                }
            }
            return Ok("Failed");
        }
    }
}