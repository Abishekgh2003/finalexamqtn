
﻿using Microsoft.AspNetCore.Mvc;

using WebApplication3.Entitywork;
using WebApplication3.Models;



namespace WebApplication3.Controllers
{
    public class LoginController : Controller
    {
        private readonly MVCDbcontext MVCDbcontext;
        public LoginController(MVCDbcontext mydbcontext)
        {
            MVCDbcontext = mydbcontext;


        }
        [HttpGet]
        public IActionResult logpage()

        {
            if (HttpContext.Request.Cookies["cook"] != null)
            {
                string email = HttpContext.Request.Cookies["cook"];

                return RedirectToAction("Dashboard", "Dashboard", new { data = email });
            }
            return View();
        }
        [HttpPost]
        public IActionResult logpage(Logclass login)
        {
            var obj1 = MVCDbcontext.RegisterTable.FirstOrDefault(x => x.Email == login.Email);
            var obj2 = MVCDbcontext.RegisterTable.FirstOrDefault(x => x.ConPassword == login.Password);
            if (obj1 != null && obj2 != null)
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTimeOffset.Now.AddHours(1);
                HttpContext.Response.Cookies.Append("cook", obj1.Email, options);
                return RedirectToAction("Dashboard", "Dashboard", new { data = login.Email });
            }
            else
            {
                ViewBag.errormsg = "Email and Password doest match";
                return View();
            }

        }
    }
}