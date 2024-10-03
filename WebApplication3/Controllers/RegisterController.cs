using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Entitywork;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class RegisterController : Controller
    {
        private readonly MVCDbcontext Mydbcontext;

        public RegisterController(MVCDbcontext mydbcontext)
        {
            Mydbcontext = mydbcontext;
        }

        [HttpGet]
        public IActionResult Regpage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Regpage(Regclass obj, IFormFile myfile)
        {
            ViewBag.UploadStatus = string.Empty;

            var table = new RegisterTable
            {
                Id = Guid.NewGuid(),
                Name = obj.Name,
                Age = obj.Age,
                Country = obj.Country,
                State = obj.State,
                City = obj.City,
                PhoneNumber = obj.PhoneNumber,
                Email = obj.Email,
                ConPassword = obj.ConPassword,
            };

            await Mydbcontext.RegisterTable.AddAsync(table);
            await Mydbcontext.SaveChangesAsync();

            try
            {
                string file_name = myfile.FileName;
                file_name = $"{obj.Email}{Path.GetExtension(file_name)}";
                string upload_folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

                if (!Directory.Exists(upload_folder))
                {
                    Directory.CreateDirectory(upload_folder);
                }

                string upload_path = Path.Combine(upload_folder, file_name);

                if (System.IO.File.Exists(upload_path))
                {
                    ViewBag.UploadStatus += $"{file_name} - Already Exists";
                }
                else
                {
                    ViewBag.UploadStatus += $"{myfile.FileName} Uploaded successfully\n";

                    using (var uploadStream = new FileStream(upload_path, FileMode.Create))
                    {
                        await myfile.CopyToAsync(uploadStream);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.UploadStatus += $"Unable to upload files: {ex.Message}";
            }

            return View();
        }
    }
}
