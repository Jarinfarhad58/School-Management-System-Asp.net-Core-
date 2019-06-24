using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using School_Management_System__Practicum_;
using School_Management_System_Practicum.Models;
using Microsoft.AspNetCore.Hosting;

namespace School_Management_System__Practicum_.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment he;
        private OurDbContext _context;
        public HomeController(OurDbContext context, IHostingEnvironment e)
        {
            _context = context;
            he = e;
        }
        public IActionResult Index()
        {
            return  View();
        }

        public IActionResult PGallary(string ImageTitle,IFormFile pic)
        {
            var list2 = _context.image.ToList();
            return View(list2);

        }
          
        public IActionResult Notice(string NoticeTitle, IFormFile pic)
        {
            var list2 = _context.Notice.ToList();
            return View(list2);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User userModel, Registration registration)
        {
            try
            {
                var account = _context.user.Where(u => u.UserName == userModel.UserName && u.Password == userModel.Password).FirstOrDefault();
                if (account != null)
                {
                    HttpContext.Session.SetString("UserId", account.UserID.ToString());
                    HttpContext.Session.SetString("UserName", account.UserName);
                    return RedirectToAction("AdminDetail", "Admin");
                }
                try
                {

                    var type = _context.registration.Where(u => u.UserName == registration.UserName && u.Password == registration.Password).FirstOrDefault();
                    var uid = type.Country;


                    if (type != null && uid == "2")
                    {

                        HttpContext.Session.SetString("UserName", type.UserName);
                        return RedirectToAction("Index", "Faculty");
                    }

                    else if (type != null && uid == "3")
                    {

                        HttpContext.Session.SetString("UserName", type.UserName);
                        return RedirectToAction("Index", "Student");
                    }
                    else if (type != null && uid == "1")
                    {

                        HttpContext.Session.SetString("UserName", type.UserName);
                        return RedirectToAction("AdminDetail", "Admin");
                    }
                    else
                    {
                        return View("Login", userModel);
                    }

                }
                catch (NullReferenceException)
                {
                    ModelState.AddModelError("", "User Name Or Password is Wrong");
                    return View("Login", userModel);
                }

            }
            catch (NullReferenceException)
            {
                ModelState.AddModelError("", "User Name Or Password is Wrong");
                return View("Login", userModel);
            }
        }

        [HttpGet]
        public IActionResult Admission()
        {
            var test = _context.Addinfo.FirstOrDefault();
            return View(test);
        }

        public IActionResult Signup()
        {

            var model = new Registration();
            model.Country = "";
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(Registration model)
        {          
                try
                {
                    if (ModelState.IsValid )
                    { 
                        _context.registration.Add(model);
                        _context.SaveChanges();
                        ModelState.Clear();
                        ViewBag.Message = model.FirstName + " " + model.LastName + " " + "Is Successfully registered";
                    
                   }
                     return View("Signup",model);
                  
                }
                catch 
                {
                    ViewBag.Message = "This User Name Is Alrady Taken Use Another One";
                    return View("Signup",model);
                }
            }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

        public IActionResult AdmissionForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdmissionForm(Form form)
        {
            if (ModelState.IsValid)
            {
                _context.form.Add(form);
                _context.SaveChanges();
                ModelState.Clear();
                ViewBag.Message = form.StudentName + " Form ID " + form.FormId + " " + "Is Successfully registered for addmission.Remember this form ID and Keep eye on the notice panel for farther admission process.";

            }
            return View("AdmissionForm", form);
            
        }
    }   
}
