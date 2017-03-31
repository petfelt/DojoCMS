using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        [Route("/SelectedNav/{navId}")]
        public IActionResult SelectedNav(int navId){
            HttpContext.Session.SetInt32("NavId",navId);
            return RedirectToAction("NavbarPool");
        }
        [HttpGet]
        [Route("/SidebarPool")]
        public IActionResult SidebarPool(){
            return View("SidebarPool");
        }
        [HttpGet]
        [Route("/SelectedSidebar/{sidebarId}")]
        public IActionResult SelectedSidebar(int sidebarId){
            HttpContext.Session.SetInt32("SidebarId",sidebarId);
            return RedirectToAction("SidebarPool");
        }
        [HttpGet]
        [Route("/HeaderPool")]
        public IActionResult HeaderPool(){
            return View("HeaderPool");
        }
        [HttpGet]
        [Route("/SelectedHeader/{headerId}")]
        public IActionResult SelectedHeader(int headerId){
            HttpContext.Session.SetInt32("HeaderId",headerId);
            return RedirectToAction("HeaderPool");
        }
        [HttpGet]
        [Route("/BodyPool")]
        public IActionResult BodyPool(){
            return View("BodyPool");
        }
        [HttpGet]
        [Route("/SelectedBody/{bodyId}")]
        public IActionResult SelectedBody(int bodyId){
            HttpContext.Session.SetInt32("BodyId",bodyId);
            return RedirectToAction("BodyPool");
        }
        [HttpGet]
        [Route("/FinalBuild")]
        public IActionResult FinalBuild(){
            int? navId= HttpContext.Session.GetInt32("NavId");
            int? sidebarId= HttpContext.Session.GetInt32("SidebarId");
            int? headerId= HttpContext.Session.GetInt32("HeaderId");
            int? bodyId= HttpContext.Session.GetInt32("BodyId");
            ViewBag.navId=(int)navId;
            ViewBag.sidebarId=(int)sidebarId;
            ViewBag.headerId=(int)headerId;
            ViewBag.bodyId=(int)bodyId;
            return View("FinalBuild");
        }
        [HttpPost]
        [Route("CreateFile")]
        public IActionResult CreateFile(string HTMLString){
            string PassedString = "/@{&#9ViewData["+"Title"+"]  = "+"New Page"+";&#9}"+HTMLString+".cshtml";
            FileManager.MakeUserDirectory("UserPages");
            FileManager.MakeUserViewsDirectory("UserPages", "NewPageViews");
            FileManager.MakePageFile("UserPages","NewPageViews", PassedString);
            return View("UserPages/NewPageViews/");
        }
    }
}