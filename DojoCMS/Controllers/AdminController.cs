using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DojoCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DojoCMS.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        [Route("Admin")]
        public IActionResult Admin()
        {   
            ViewBag.Errors = new List<string>();
            ViewBag.LoginErrors = new List<string>();
            return View("AdminIndex");
        }
    }
}