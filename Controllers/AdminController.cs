using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Rotativa.AspNetCore;
using School_Management_System_Practicum.Models;
namespace School_Management_System__Practicum_.Controllers
{
    public class AdminController : Controller
    {

        private readonly IHostingEnvironment he;
        private OurDbContext _context;
        public AdminController(OurDbContext context, IHostingEnvironment e)
        {
            _context = context;
            he = e;

        }
        public IActionResult AddmissionList()
        {
            if (HttpContext.Session.GetString("UserId")!= null|| HttpContext.Session.GetString("UserName") != null)
            {
                return View(_context.form.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public IActionResult AddmissionDelete(int id=0)
        {
            var delete = _context.form.Where(x => x.FormId == id).FirstOrDefault();
            _context.form.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("AddmissionList");

        }
            public IActionResult AtndList()
        {
            if (HttpContext.Session.GetString("UserId") != null || HttpContext.Session.GetString("UserName") != null)
            {
                return View(_context.attendence.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public IActionResult Addadmissioninfo()
        {
            if (HttpContext.Session.GetString("UserId") != null|| HttpContext.Session.GetString("UserName") != null)
            {

                return View(_context.Addinfo.FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        [HttpPost]
        public IActionResult Addadmissioninfo(Addinfo resultModel)
        {
           
                try
                {
                    if (ModelState.IsValid)
                    {
                        var deletedstudent = _context.Addinfo.Where(x => x.msgno == "1").FirstOrDefault();
                        _context.Addinfo.Remove(deletedstudent);

                        _context.Add(resultModel);
                        _context.SaveChanges();
                        ModelState.Clear();
                        ViewBag.Message = "Successfully Uploaded";
                    }
                    return View("Addadmissioninfo", resultModel);
                }
                catch
                {
                    ViewBag.Message = "Must Enter the Information No as 1";
                    return View("Addadmissioninfo", resultModel);
                }

            }
          

        
        public IActionResult Admissionpdf(int id = 0)
        {
            if (HttpContext.Session.GetString("UserId") != null|| HttpContext.Session.GetString("UserName") != null)
            {
                return new ViewAsPdf(_context.form.Where(x => x.FormId == id).FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public IActionResult Fpayment()
        {
            if (HttpContext.Session.GetString("UserId") != null || HttpContext.Session.GetString("UserName") != null)
            {
                return View();
            }

            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public IActionResult Fpayment(Fpayment payment, Registration registration)

        {
            var check = _context.registration.Where(s => s.UserName == registration.UserName && s.Country=="2").FirstOrDefault();
            
            if (check != null)
            {
                var atnd = _context.Fpayment.Where(s => s.UserName == payment.UserName).FirstOrDefault();
                if (atnd == null )
                {
                    
                        _context.Fpayment.Add(payment);
                        _context.SaveChanges();
                        ModelState.Clear();
                        ViewBag.Message = payment.UserName + " " + "Is Successfully Payed";

                    
                    return View("Fpayment", payment);

                }
                else
                {
                    ViewBag.Message = "This payment is alrady Given";
                    return View("Fpayment", payment);
                }
            }
            else
            {
                ViewBag.Message = "Invalid user name";
                return View("Fpayment", payment);
            }
        }
        

        public IActionResult Paymentpdf(int id = 0)
        {
            if (HttpContext.Session.GetString("UserId") != null || HttpContext.Session.GetString("UserName") != null)
            {
                return new ViewAsPdf(_context.Fpayment.Where(x => x.PaymentId == id).FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public IActionResult FpaymentDelete(int id = 0)
        {
            var delete = _context.Fpayment.Where(x => x.PaymentId == id).FirstOrDefault();
            _context.Fpayment.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("Stfpayment");

        }

        public IActionResult Stfpayment()
        {
            if (HttpContext.Session.GetString("UserId") != null|| HttpContext.Session.GetString("UserName") != null)
            {
                return View(_context.Fpayment.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public IActionResult Splist()
        {
            if (HttpContext.Session.GetString("UserId") != null || HttpContext.Session.GetString("UserName") != null)
            {
                return View(_context.Sfees.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public IActionResult Stupaymentpdf(int id = 0)
        {
            if (HttpContext.Session.GetString("UserId") != null || HttpContext.Session.GetString("UserName") != null)
            {
                return new ViewAsPdf(_context.Sfees.Where(x => x.PaymentId == id).FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public IActionResult StupaymentDelete(int id = 0)
        {
            var delete = _context.Sfees.Where(x => x.PaymentId == id).FirstOrDefault();
            _context.Sfees.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("Splist");

        }

        public IActionResult Stufees()
        {
            if (HttpContext.Session.GetString("UserId") != null|| HttpContext.Session.GetString("UserName") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        [HttpPost]
        public IActionResult Stufees(Sfees payment,Registration registration)
        {
            var check = _context.registration.Where(s => s.UserName == registration.UserName && s.Country == "3").FirstOrDefault();

            if (check != null)
            {
                var atnd = _context.Sfees.Where(s => s.UserName == payment.UserName).FirstOrDefault();
                if (atnd == null)
                {

                    _context.Sfees.Add(payment);
                    _context.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Message = "Successfully paid";


                    return View("Stufees", payment);

                }
                else
                {
                    ViewBag.Message = "Fees alrady taken";
                    return View("Stufees", payment);
                }
            }
            else
            {
                ViewBag.Message = "Invalid user name";
                return View("Stufees", payment);
            }
        }
            public IActionResult Addcourse()
        {
            if (HttpContext.Session.GetString("UserId") != null|| HttpContext.Session.GetString("UserName") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Addcourse([Bind("SubjectId,SName")] Subject tblSubject)
        {
            if (ModelState.IsValid)
            {
                _context.Subject.Add(tblSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Addcourse));
            }
            return View(tblSubject);
        }
        public IActionResult Showsubject()
        {
            if (HttpContext.Session.GetString("UserId") != null || HttpContext.Session.GetString("UserName") != null)
            {
                return View(_context.Subject.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public IActionResult Deletesubject(int id1 = 0)
        {
            try
            {
                var delete = _context.Subject.Where(x => x.SubjectId == id1).FirstOrDefault();
                _context.Subject.Remove(delete);
                _context.SaveChanges();
                return RedirectToAction("Showsubject");
            }
            catch
            {
                ViewBag.Message = "You can not Delet it.This subject is alrady assigned";
                return RedirectToAction("Showsubject");

            }
        }

        public IActionResult Addclass()
        {
            if (HttpContext.Session.GetString("UserId") != null|| HttpContext.Session.GetString("UserName") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Addclass([Bind("ClassId,CName")] Class tblSubject)
        {
            if (ModelState.IsValid)
            {
                _context.Class.Add(tblSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Addclass));
            }
            return View(tblSubject);
        }
        public IActionResult Showclass()
        {
            if (HttpContext.Session.GetString("UserId") != null || HttpContext.Session.GetString("UserName") != null)
            {
                
                return View(_context.Class.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public IActionResult Deleteclass(int id1 = 0)
        {
            try
            {
                var delete = _context.Class.Where(x => x.ClassId == id1).FirstOrDefault();
                _context.Class.Remove(delete);
                _context.SaveChanges();
                return RedirectToAction("Showclass");
            }
            catch
            {
                ViewBag.Message = "You can not Delet it.This subject is alrady assigned";
                return RedirectToAction("Showclass", ViewBag.Message = "You can not Delet it.This subject is alrady assigned");

            }
        }

        public IActionResult Addtime()
        {
            if (HttpContext.Session.GetString("UserId") != null|| HttpContext.Session.GetString("UserName") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Addtime([Bind("TimeId,TName")] Time tblSubject)
        {
            if (ModelState.IsValid)
            {
                _context.Time.Add(tblSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Addtime));
            }
            return View(tblSubject);
        }
        public IActionResult Showtime()
        {
            if (HttpContext.Session.GetString("UserId") != null || HttpContext.Session.GetString("UserName") != null)
            {
                return View(_context.Time.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public IActionResult Deletetime(int id1 = 0)
        {
            try { 
            var delete = _context.Time.Where(x => x.TimeId == id1).FirstOrDefault();
            _context.Time.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("Showtime");
        }
            catch
            {
                return RedirectToAction("Showtime");
            }
        }
        public IActionResult Fixcourse()
        {

            if (HttpContext.Session.GetString("UserId") != null|| HttpContext.Session.GetString("UserName") != null)
            {
               
                ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SName");
                ViewData["ClassId"] = new SelectList(_context.Class, "ClassId", "CName");
                ViewData["TimeId"] = new SelectList(_context.Time, "TimeId", "TName");
                var model = new Selectcourse();
                model.Country = "";
                return View(model);
                
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Fixcourse(Selectcourse model,Registration registration)
        {
            var check = _context.registration.Where(s => s.UserName == registration.UserName && s.Country == "2").FirstOrDefault();

            if (check != null)
            {
                var type = _context.Selectcourse.Where(u => u.UserName == model.UserName && u.TimeId == model.TimeId && u.Country == model.Country).FirstOrDefault();
                if (type == null)
                {
                   
                        _context.Selectcourse.Add(model);
                        _context.SaveChanges();
                        ModelState.Clear();
                        ViewBag.Message = model.UserName + " " + "Is Successfully Assaigned for the course";
                        ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SName");
                        ViewData["ClassId"] = new SelectList(_context.Class, "ClassId", "CName");
                        ViewData["TimeId"] = new SelectList(_context.Time, "TimeId", "TName");
                        return View("Fixcourse", model);
                   
                }
                else
                {
                    ViewBag.Message = "Conflict!!This Time Schedule Is Alrady Taken Use Another One";
                    ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SName");
                    ViewData["ClassId"] = new SelectList(_context.Class, "ClassId", "CName");
                    ViewData["TimeId"] = new SelectList(_context.Time, "TimeId", "TName");
                    return View("Fixcourse", model);
                }
            }
            else
            {
                ViewBag.Message = "Invalid user name";
                ViewData["SubjectId"] = new SelectList(_context.Subject, "SubjectId", "SName");
                ViewData["ClassId"] = new SelectList(_context.Class, "ClassId", "CName");
                ViewData["TimeId"] = new SelectList(_context.Time, "TimeId", "TName");
                return View("Fixcourse", model);
            }

        }

        public IActionResult Showcourse()
        {
            if (HttpContext.Session.GetString("UserId") != null|| HttpContext.Session.GetString("UserName") != null)
            {
                var list1 =  _context.Selectcourse.Include(t => t.Class).Include(t => t.Subject).Include(t => t.Time).ToList();
                return View(list1);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public IActionResult Deletecourse(int id1=0)
        {
            var delete = _context.Selectcourse.Where(x => x.Courseid == id1).FirstOrDefault();
            _context.Selectcourse.Remove(delete);
            _context.SaveChanges();
            return RedirectToAction("Showcourse");
        }
        public IActionResult Mfaculties()
        {

            if (HttpContext.Session.GetString("UserId") != null|| HttpContext.Session.GetString("UserName") != null)
            {
                var list1 = _context.registration.Where(s => s.Country == "2").ToList();
                return View(list1);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult FacultyDetail(string id = "")
        {
            if (HttpContext.Session.GetString("UserId") != null|| HttpContext.Session.GetString("UserName") != null)
            {

            return View(_context.registration.Where(x => x.UserName == id).FirstOrDefault());
               
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public ActionResult FacultyEdit(string id = "")

        {
            if (HttpContext.Session.GetString("UserId") != null|| HttpContext.Session.GetString("UserName") != null)
            {
             return View(_context.registration.Where(x => x.UserName == id).FirstOrDefault());
               
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
            
        }

        [HttpPost]
        public ActionResult FacultyEdit(string id, Registration result)

        {
            try
            {
                if (ModelState.IsValid)
                {
                    var deletedstudent = _context.registration.Where(x => x.UserName == result.UserName).FirstOrDefault();
                    _context.registration.Remove(deletedstudent);

                    _context.Add(result);
                    _context.SaveChanges();
                    ModelState.Clear();
                    ViewBag.Message = "Successfully Uploaded";

                }

                return RedirectToAction("FacultyEdit", result);
            }
            catch
            {
                ViewBag.Message = "You have to change the password again";
                return RedirectToAction("FacultyEdit", result);
            }

        }
        public ActionResult FacultyDelete(string id1 = "")
        {
            var deletedstudent = _context.registration.Where(x => x.UserName == id1).FirstOrDefault();
            _context.registration.Remove(deletedstudent);
            _context.SaveChanges();
            return RedirectToAction("Mfaculties");

        }
        public ActionResult StudentDelete(string id = "")
        {
            var deletedstudent = _context.registration.Where(x => x.UserName == id).FirstOrDefault();
            _context.registration.Remove(deletedstudent);
            _context.SaveChanges();
            return RedirectToAction("Mstudents");

        }
        public ActionResult AdminDelete(string id = "")
        {
            var deletedstudent = _context.registration.Where(x => x.UserName == id).FirstOrDefault();
            _context.registration.Remove(deletedstudent);
            _context.SaveChanges();
            return RedirectToAction("Mstuffs");

        }
        public IActionResult Mstudents()
        {
            if (HttpContext.Session.GetString("UserId") != null||HttpContext.Session.GetString("UserName") != null)
            {
                var list2 = _context.registration.Where(s => s.Country == "3").ToList();
                return View(list2);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public IActionResult Mstuffs()
        {
            if (HttpContext.Session.GetString("UserId") != null|| HttpContext.Session.GetString("UserName") != null)
            {
                var list3 = _context.registration.Where(s => s.Country == "1").ToList();
                return View(list3);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }
        public ActionResult AdminDetail()
        {
            if (HttpContext.Session.GetString("UserId") != null || HttpContext.Session.GetString("UserName") != null)
            {
                var id = HttpContext.Session.GetString("UserName");
                return View(_context.registration.Where(x => x.UserName == id).FirstOrDefault());
            }

            else
            {

                return RedirectToAction("Login", "Home");
            }
        }
        public IActionResult Addphotos()
        {
            if (HttpContext.Session.GetString("UserId") != null|| HttpContext.Session.GetString("UserName") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public IActionResult Addphotos(Image img)
        {

            var newFileName = string.Empty;

            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = HttpContext.Request.Form.Files;
                try
                {
                    if (!ModelState.IsValid)
                    {

                        var uploads = Path.Combine(he.WebRootPath, "pic");

                        foreach (var file in files)
                        {

                            if (file.Length > 0)
                            {
                                fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                                var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                                var FileExtension = Path.GetExtension(fileName);
                                newFileName = myUniqueFileName + FileExtension;
                                fileName = Path.Combine(he.WebRootPath, "pic") + $@"\{newFileName}";
                                PathDB = "pic/" + newFileName;
                                using (FileStream fs = System.IO.File.Create(fileName))
                                {
                                    file.CopyTo(fs);
                                    fs.Flush();
                                }
                            }
                        }

                        Image objvenue = new Image
                        {
                            ImageTitle = img.ImageTitle,
                            pic = PathDB,


                        };

                        _context.image.Add(objvenue);
                        _context.SaveChanges();
                        ViewBag.Message = "Uploaded Successfully";
                        ModelState.Clear();


                    }
                    return View(new Image());
                }
                catch
                {
                    return View(img);
                }
               
            }
            return View(img);
        }



        public IActionResult Deleteimage()
        {
            if (HttpContext.Session.GetString("UserId") != null|| HttpContext.Session.GetString("UserName") != null)
            {
               return View(_context.image.ToList());
               
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
           
        }
        public IActionResult Imgdelete(int id = 0)
        {
            var deletedstudent = _context.image.Where(x => x.ImageID == id).FirstOrDefault();
            _context.image.Remove(deletedstudent);
            _context.SaveChanges();
            return RedirectToAction("Deleteimage");

        }

        public IActionResult Addnotice()
        {
            if (HttpContext.Session.GetString("UserId") != null|| HttpContext.Session.GetString("UserName") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        [HttpPost]
        public IActionResult Addnotice(Notice notice)
        {
            var newFileName = string.Empty;

            if (HttpContext.Request.Form.Files != null)
            {
                var fileName = string.Empty;
                string PathDB = string.Empty;

                var files = HttpContext.Request.Form.Files;
                try
                {
                    if (!ModelState.IsValid)
                    {

                        var uploads = Path.Combine(he.WebRootPath, "pic");

                        foreach (var file in files)
                        {
                            if (file.Length > 0)
                            {
                                fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                                var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                                var FileExtension = Path.GetExtension(fileName);
                                newFileName = myUniqueFileName + FileExtension;
                                fileName = Path.Combine(he.WebRootPath, "pic") + $@"\{newFileName}";
                                PathDB = "pic/" + newFileName;
                                using (FileStream fs = System.IO.File.Create(fileName))
                                {
                                    file.CopyTo(fs);
                                    fs.Flush();
                                }
                            }
                        }

                        Notice objvenue = new Notice
                        {
                            NoticeTitle = notice.NoticeTitle,
                            pic = PathDB,


                        };

                        _context.Notice.Add(objvenue);
                        _context.SaveChanges();
                        ViewBag.Message = "Uploaded Successfully";
                        ModelState.Clear();


                    }
                    return View(new Notice());
                }
                catch
                {
                    return View(notice);
                }
            }
                return View(notice);
            }
        public IActionResult Deletenotice()
        {
            if (HttpContext.Session.GetString("UserId") != null||HttpContext.Session.GetString("UserName") != null)
            {
              return View(_context.Notice.ToList());
               
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
           
        }
        public IActionResult Noticedelete(int id = 0)
        {
            var deletedstudent = _context.Notice.Where(x => x.NoticeID == id).FirstOrDefault();
            _context.Notice.Remove(deletedstudent);
            _context.SaveChanges();
            return RedirectToAction("Deletenotice");

        }
    }
    }
