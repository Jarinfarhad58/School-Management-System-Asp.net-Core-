using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Management_System_Practicum.Models;

namespace School_Management_System__Practicum_.Controllers
{
    public class FacultyController : Controller

    {
        private OurDbContext _context;
        public FacultyController(OurDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                var id = HttpContext.Session.GetString("UserName");
                return View(_context.registration.Where(x => x.UserName == id).FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpGet]
        public IActionResult Result()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {

                return View();
               
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public IActionResult Result(Resultclass model)
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                var list1 = _context.registration.Where(s => s.Class == model.Class).ToList();

                return View("ResultList",list1);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public IActionResult UpgradeResult()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public IActionResult UpgradeResult(Result resultModel, Registration registration)
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                try
                {
                    var check = _context.registration.Where(s => s.UserName == registration.UserName && s.Country == "3").FirstOrDefault();

                    if (check != null)
                    {
                       
                            _context.Entry(resultModel).State = EntityState.Modified;
                            _context.SaveChanges();
                            ModelState.Clear();
                            ViewBag.Message = "Successfully Uploaded";

                        
                        return View("UpgradeResult", resultModel);
                    }
                    else
                    {
                        ViewBag.Message = "Invalid user name";
                        return View("UpgradeResult", resultModel);
                    }
                }
                catch
                {
                    if (ModelState.IsValid)
                    {
                        _context.Result.Add(resultModel);

                        _context.SaveChanges();
                        ModelState.Clear();
                        ViewBag.Message = "Successfully Uploaded";

                      
                    }
                    return View("UpgradeResult", resultModel);
                }
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public IActionResult Attendence()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public IActionResult Attendence(Attendence model)
        {
            var atnd = _context.attendence.Where(s => s.UserName == model.UserName && s.date==model.date).FirstOrDefault();
            if (atnd == null)
            {
                _context.attendence.Add(model);
                _context.SaveChanges();
                ModelState.Clear();
                var list1 = _context.attendence.Where(s => s.UserName == model.UserName).ToList();
                return View("List", list1);
            }
            else
            {
                ViewBag.Message = "Your todays Attendence has alrady taken";
                return View("Attendence", model);
            }
        }
        public IActionResult List()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                var id = HttpContext.Session.GetString("UserName");
                return View( _context.attendence.Where(s => s.UserName == id).ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public IActionResult Routine()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                var id = HttpContext.Session.GetString("UserName");
                var list1 = _context.Selectcourse.Include(t => t.Class).Include(t => t.Subject).Include(t => t.Time).Where(s=> s.UserName==id).ToList();
                return View(list1);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
    }
}