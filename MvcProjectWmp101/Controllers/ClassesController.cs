using MvcProjectWmp101.Models;
using MvcProjectWmp101.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectWmp101.Controllers
{
    public class ClassesController : Controller
    {
        // GET: Classes
        public ActionResult NewClass()
        {
            return View();
        }

        [HttpPost]

        public ActionResult NewClass(Classes classes)
        {
            StudentsDatabaseContext db = new StudentsDatabaseContext();
            db.Classes.Add(classes);

            int result;

            try
            {           
                result = db.SaveChanges();      
            }
            catch (Exception)
            {

                result = 0;
            }
            if (result > 0)
            {
                ViewBag.Result = "Başarılı";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "başarısız";
                ViewBag.Status = "danger";
            }
            ModelState.Clear();

            return View();
        }
    }
}