using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using School_Management_System_Practicum.Models;

namespace School_Management_System__Practicum_.Controllers
{
    public class StudentController : Controller
    {
        private OurDbContext _context;
        public StudentController(OurDbContext context)
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
        public IActionResult Result()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
               
                    var id = HttpContext.Session.GetString("UserName");
                    return View(_context.Result.Where(x => x.UserName == id).FirstOrDefault());
               
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public IActionResult Monthly()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                var id = HttpContext.Session.GetString("UserName");
                return View(_context.Sfees.Where(x => x.UserName == id).FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public IActionResult Routine(Registration registration)
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                var id = HttpContext.Session.GetString("UserName");


                var one = _context.registration.Where( s=>s.Class=="1" && s.UserName==id).FirstOrDefault();
                var two = _context.registration.Where(s => s.Class == "2" && s.UserName == id).FirstOrDefault();
                var three = _context.registration.Where(s => s.Class == "3" && s.UserName == id).FirstOrDefault();
                var four = _context.registration.Where(s => s.Class == "4" && s.UserName == id).FirstOrDefault();
                var five = _context.registration.Where(s => s.Class == "5" && s.UserName == id).FirstOrDefault();
                var six = _context.registration.Where(s => s.Class == "6" && s.UserName == id).FirstOrDefault();
                var seven = _context.registration.Where(s => s.Class == "7" && s.UserName == id).FirstOrDefault();
                var eight = _context.registration.Where(s => s.Class == "8" && s.UserName == id).FirstOrDefault();
                var nine = _context.registration.Where(s => s.Class == "9" && s.UserName == id).FirstOrDefault();
                var ten = _context.registration.Where(s => s.Class == "10" && s.UserName == id).FirstOrDefault();
                var cls1 = _context.Class.Where(s => s.CName == "One" ).FirstOrDefault();
                var cls2 = _context.Class.Where(s => s.CName == "Two" ).FirstOrDefault();
                var cls3 = _context.Class.Where(s => s.CName == "Three" ).FirstOrDefault();
                var cls4 = _context.Class.Where(s => s.CName == "Four").FirstOrDefault();
                var cls5 = _context.Class.Where(s => s.CName == "Five").FirstOrDefault();
                var cls6 = _context.Class.Where(s => s.CName == "Six").FirstOrDefault();
                var cls7 = _context.Class.Where(s => s.CName == "Seven").FirstOrDefault();
                var cls8 = _context.Class.Where(s => s.CName == "Eight").FirstOrDefault();
                var cls9 = _context.Class.Where(s => s.CName == "Nine").FirstOrDefault();
                var cls10 = _context.Class.Where(s => s.CName == "Ten").FirstOrDefault();
                try
                {
                    if (one != null)
                    {
                        var list1 = _context.Selectcourse.Include(t => t.Class).Include(t => t.Subject).Include(t => t.Time).Where(s => s.ClassId == cls1.ClassId).ToList();

                        return View(list1);
                    }
                    else if (two != null)
                    {
                        var list1 = _context.Selectcourse.Include(t => t.Class).Include(t => t.Subject).Include(t => t.Time).Where(s => s.ClassId == cls2.ClassId).ToList();

                        return View(list1);
                    }
                    else if (three != null)
                    {
                        var list1 = _context.Selectcourse.Include(t => t.Class).Include(t => t.Subject).Include(t => t.Time).Where(s => s.ClassId == cls3.ClassId).ToList();

                        return View(list1);
                    }
                    else if (four != null)
                    {
                        var list1 = _context.Selectcourse.Include(t => t.Class).Include(t => t.Subject).Include(t => t.Time).Where(s => s.ClassId == cls4.ClassId).ToList();

                        return View(list1);
                    }
                    else if (five != null)
                    {
                        var list1 = _context.Selectcourse.Include(t => t.Class).Include(t => t.Subject).Include(t => t.Time).Where(s => s.ClassId == cls5.ClassId).ToList();

                        return View(list1);
                    }
                    else if (six != null)
                    {
                        var list1 = _context.Selectcourse.Include(t => t.Class).Include(t => t.Subject).Include(t => t.Time).Where(s => s.ClassId == cls6.ClassId).ToList();

                        return View(list1);
                    }
                    else if (seven != null)
                    {
                        var list1 = _context.Selectcourse.Include(t => t.Class).Include(t => t.Subject).Include(t => t.Time).Where(s => s.ClassId == cls7.ClassId).ToList();

                        return View(list1);
                    }
                    else if (eight != null)
                    {
                        var list1 = _context.Selectcourse.Include(t => t.Class).Include(t => t.Subject).Include(t => t.Time).Where(s => s.ClassId == cls8.ClassId).ToList();

                        return View(list1);
                    }
                    else if (nine != null)
                    {
                        var list1 = _context.Selectcourse.Include(t => t.Class).Include(t => t.Subject).Include(t => t.Time).Where(s => s.ClassId == cls9.ClassId).ToList();

                        return View(list1);
                    }
                    else
                    {
                        var list1 = _context.Selectcourse.Include(t => t.Class).Include(t => t.Subject).Include(t => t.Time).Where(s => s.ClassId == cls10.ClassId).ToList();

                        return View(list1);
                    }
                }
                catch
                {
                    
                    return View(_context.Selectcourse.Include(t => t.Class).Include(t => t.Subject).Include(t => t.Time).Where(s => s.Courseid == 10).ToList());
                }
               
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public IActionResult Resultpdf(string id="")
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                return new ViewAsPdf(_context.Result.Where(x => x.UserName == id).FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
    }
}