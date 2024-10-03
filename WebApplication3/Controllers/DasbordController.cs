
﻿using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using WebApplication3.Entitywork;

namespace WebApplication3.Controllers
{
    public class DasbordController : Controller
    {
        private readonly MVCDbcontext _Mydbcontext;
        public DasbordController(MVCDbcontext mydbcontext)
        {
            _Mydbcontext = mydbcontext;


        }

        public IActionResult Dasbord(string data)
        {
            var obj = _Mydbcontext.RegisterTable.FirstOrDefault(x => x.Email == data);
            if (obj != null)
            {
                ViewBag.Name = obj.Name;
                ViewBag.Email = obj.Email;
                ViewBag.Age = obj.Age;
                ViewBag.Country = obj.Country;
                ViewBag.State = obj.State;
                ViewBag.City = obj.City;
                ViewBag.PhoneNumber = obj.PhoneNumber;



                string imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");


                var imageFiles = Directory.GetFiles(imageDirectory, data + ".*");


                if (imageFiles.Length > 0)
                {
                    string imageName = Path.GetFileName(imageFiles[0]);
                    ViewBag.imagename = imageName;
                }


                return View();





            }
            return View();

        }
    }
}