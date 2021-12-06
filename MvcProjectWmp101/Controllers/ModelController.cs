using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjectWmp101.Models;
using MvcProjectWmp101.ViewModel;

namespace MvcProjectWmp101.Controllers
{
    public class ModelController : Controller
    {
        // GET: Model
        [HttpGet]
        public ActionResult Index()
        {
            Kisi kisi = new Kisi();
            kisi.Ad = "Eren";
            kisi.Soyad = "Baba";
            kisi.Yas = 24;

            Adres adr = new Adres();
            adr.AdresTanimi = " DENEME adres";
            adr.Sehir = "istanbul";

            indexViewModel mod = new indexViewModel();
            mod.KisiNesnesi = kisi;
            mod.AdresNesnesi = adr;

            return View(mod);
        }

        [HttpPost]
        public ActionResult Index(indexViewModel model)
        {
            return View(model);
        }
    }
}