using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DojoCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DojoCMS.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Route("UserPage")]
        public IActionResult UserPage()
        {
            return View("User");
        }
    }
}