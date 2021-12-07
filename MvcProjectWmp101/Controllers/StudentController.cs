using MvcProjectWmp101.Models;
using MvcProjectWmp101.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectWmp101.Controllers
{
    public class StudentController : Controller
    {

        // GET: Student
        public ActionResult Index()
        {
            StudentsDatabaseContext db = new StudentsDatabaseContext();

            List<SelectListItem> classList = (from s in db.Classes
                                              select new SelectListItem() {
                                                  Text=s.ClassName,
                                                  Value=s.Id.ToString()
                                              }
                                            ).ToList();

            TempData["classes"] = classList;
            ViewBag.classes = classList;
            return View();

        }

       [HttpPost]
       public ActionResult Index(Students students)
        {
            StudentsDatabaseContext db = new StudentsDatabaseContext();
            Classes classes = db.Classes.FirstOrDefault(x => x.Id == students.Classes.Id);

            if (classes!=null)
            {
                students.Classes = classes;
                db.Students.Add(students);
                int result = db.SaveChanges();
                if (result>0)
                {
                    ViewBag.Result = "başarılı";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "başarısız";
                    ViewBag.Status = "danger";
                }
                
            }
            ModelState.Clear();
            ViewBag.classes = TempData["classes"];

            return View();
        }
    }
}