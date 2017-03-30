using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DojoCMS.Controllers
{
    public class WireframeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("blog")]
        public IActionResult blog()
        {
            return View("blog");
            
        }
        [HttpGet]
        [Route("portfolio")]
        public IActionResult portfolio()
        {
            return View("portfolio");
            
        }
        [HttpGet]
        [Route("/Navbar")]
        public IActionResult NavbarPool(){
            return View("NavbarPool");
        }
        [HttpGet]
        [Route("/NavToAdd/{navName}")]
        public IActionResult SelectedNav(string navName){
            return RedirectToAction("NavbarPool"); 
        }
        [HttpGet]
        [Route("/HeaderPool")]
        public IActionResult HeaderPool(){
            return View("HeaderPool");
        }
    }
}
