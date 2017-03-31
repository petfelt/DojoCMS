using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DojoCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DojoCMS.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: /Home/
         private CmsContext  _context;

         public HomeController(CmsContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
            ViewBag.Errors = new List<string>();
            ViewBag.LoginErrors = new List<string>();
            return View("Index");
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel model)
        {

            ViewBag.Errors = new List<string>();
            ViewBag.LoginErrors = new List<string>();
             User CheckEmail = _context.Users.SingleOrDefault(user => user.email == model.email);

             if(CheckEmail == null){
                if(ModelState.IsValid){

                    User newUser = new User{
                        name = model.name,
                        email = model.email,
                        password = model.Password,
                        username = model.username
                  };
                    _context.Users.Add(newUser);
                    _context.SaveChanges();
                     HttpContext.Session.SetInt32("CurrUserId", newUser.ID);
                    //left route empty to fill later
                    return RedirectToAction("Admin", "Admin");

                }//end of IsValid 
                else{
                    ViewBag.Errors = ModelState.Values;
                     //fill out route incase the validation is not vaid. return user to registration page
                    return View("Register", "Home");

                 }//end of else

             }//end of checkUser If

            // //fill out route if CheckEmail is already stored in database
             return View("Index", "Home");
        }//end of Register method

        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {   
            ViewBag.Errors = new List<string>();
            ViewBag.LoginErrors = new List<string>();
            return View("Register", "Home");
        }


        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {   
            ViewBag.Errors = new List<string>();
            ViewBag.LoginErrors = new List<string>();
            return View("Login", "Home");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string email, string password)
        {
            ViewBag.Errors = new List<string>();
            ViewBag.LoginErrors = new List<string>();
            User CheckUser = _context.Users.SingleOrDefault(user => user.email == email);
            if(CheckUser != null && CheckUser.password == password)
            {
                    HttpContext.Session.SetInt32("CurrUserId", CheckUser.ID);

                    //fill out the route for display User Page.
                    return RedirectToAction("Admin", "Admin");

            }else{
                ViewBag.LoginErrors = new List<string>{"Invalid Email or Password"};
                return View("Login","Home");
            }
  
        }

       

    }
}
