using MvcProjectWmp101.Models.Manager;
using MvcProjectWmp101.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectWmp101.Controllers
{
    public class CsEfController : Controller
    {
        // GET: CsEf
        public ActionResult Index()
        {
            StudentsDatabaseContext db = new StudentsDatabaseContext();
            ClsAddViewModel model = new ClsAddViewModel();
            model.Classes = db.Classes.ToList();
            model.Students = db.Students.ToList();

            return View(model);
        }
    }
}