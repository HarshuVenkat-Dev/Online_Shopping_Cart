﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet()]
        public IActionResult CartProducts()
        {
            return Ok();
        }



        [HttpPost()]
        public IActionResult CartHistory()
        {
            return Ok();
        }
    }
}
