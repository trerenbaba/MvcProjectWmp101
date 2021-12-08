using MvcProjectWmp101.Models;
using MvcProjectWmp101.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectWmp101.Controllers
{
    public class AddressesController : Controller
    {
        // GET: Addresses
        public ActionResult NewAddress()
        {
            DatabaseContext db = new DatabaseContext();

            List<SelectListItem> personsList = (from s in db.Persons
                                                select new SelectListItem()
                                                {
                                                    Text = s.Name + " " + s.SurName,
                                                    Value = s.Id.ToString()
                                                }).ToList();

            //List<Persons> persons = db.Persons.ToList();
            //List<SelectListItem> personsList = new List<SelectListItem>();
            //foreach (Persons person in persons)
            //{
            //    SelectListItem item = new SelectListItem();
            //    item.Text = person.Name+" "+person.SurName;
            //    item.Value = person.Id.ToString();
            //    personsList.Add(item);
            //}
            TempData["persons"] = personsList;
            ViewBag.persons = personsList;
            return View();
        }

        [HttpPost]
        public ActionResult NewAddress(Addresses address)
        {
            DatabaseContext db = new DatabaseContext();
            Persons person = db.Persons.Where(x => x.Id == address.Persons.Id).FirstOrDefault();

            if (person != null)
            {
                address.Persons = person;
                db.Adresses.Add(address);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    ViewBag.Result = "Address enrollment completed successfully.";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Address enrollment failure.";
                    ViewBag.Status = "danger";
                }
            }
            ModelState.Clear();
            ViewBag.persons = TempData["persons"];
            return View();
        }

        public ActionResult Update(int? aid) //nullable int tipler null gelemez null gelebilir hale getirdik.
        {
            Addresses adr = null;

            if (aid != null)
            {
                DatabaseContext db = new DatabaseContext();
                List<SelectListItem> personsList = (from s in db.Persons
                                                    select new SelectListItem()
                                                    {
                                                        Text = s.Name + " " + s.SurName,
                                                        Value = s.Id.ToString()
                                                    }).ToList();
                adr = db.Adresses.FirstOrDefault(x => x.Id == aid);
                personsList.Find(x => x.Value == adr.Persons.Id.ToString()).Selected = true;


                TempData["persons"] = personsList;
                ViewBag.persons = personsList;

            }
            return View(adr);
        }
        [HttpPost]
        public ActionResult Update(Addresses model, int? aid) //nullable int tipler null gelemez null gelebilir hale getirdik.
        {
            DatabaseContext db = new DatabaseContext();

            Persons person = db.Persons.FirstOrDefault(x => x.Id == model.Persons.Id); 
            Addresses address = db.Adresses.FirstOrDefault(s => s.Id == aid); //aid yerine model.Id olur mu dene...

            if (person!=null)
            {
                address.Persons = person;  
                address.Description = model.Description;
                address.City = model.City;

                int result = db.SaveChanges();
                if (result > 0)
                {
                    ViewBag.Result = "Address updated successfully.";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Address updated failure.";
                    ViewBag.Status = "danger";
                }

            }

            ViewBag.persons = TempData["persons"];
            return View();
        }

    }
}