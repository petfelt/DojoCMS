using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DojoCMS.Controllers
{
    public class HomeController : Controller
    {
        private BloggingContext _context;

        public HomeController()
        {
            DBManager dbManger = new DBManager();
            _context =  dbManger.GetUserDBContext("AppNameDb") as BloggingContext;
        }
        
        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
