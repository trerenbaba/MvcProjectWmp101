using MvcProjectWmp101.Models;
using MvcProjectWmp101.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectWmp101.Controllers
{
    public class PersonsController : Controller
    {
        // GET: Persons
        public ActionResult NewPerson()
        {
            return View();
        }


        [HttpPost]
        public ActionResult NewPerson(Persons persons)
        {
            DatabaseContext db = new DatabaseContext();
            db.Persons.Add(persons);

            int result = db.SaveChanges();

            if (result > 0)
            {
                ViewBag.Result = "Person enrollment completed succesfly.";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Person enrollment failure.";
                ViewBag.Status = "danger";
            }
            ModelState.Clear();//Textboxfor temizleme.
            return View();
        }

        public ActionResult Update(int? pid) //nullable int tipler null gelemez null gelebilir hale getirdik.
        {
            Persons per = null;
            if (pid != null)
            {
                DatabaseContext db = new DatabaseContext();
                per = db.Persons.FirstOrDefault(x => x.Id == pid);
            }
            return View(per);
        }
        [HttpPost]
        public ActionResult Update(Persons model, int? pid) //nullable int tipler null gelemez null gelebilir hale getirdik.
        {
            DatabaseContext db = new DatabaseContext();
            Persons persons = db.Persons.FirstOrDefault(x => x.Id == pid);

            if (persons != null)
            {
                persons.Name = model.Name;
                persons.SurName = model.SurName;
                persons.Age = model.Age;
                int result = db.SaveChanges();

                if (result > 0)
                {
                    ViewBag.Result = "Person updated succesfly.";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Person updated failure.";
                    ViewBag.Status = "danger";
                }
            }
            return View();
        }

        public ActionResult Delete(int? pid)
        {
            Persons per = null;

            if (pid != null)
            {
                DatabaseContext db = new DatabaseContext();
                per = db.Persons.Find(pid);
            }

            return View(per);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteOk(int? pid)
        {


            if (pid != null)
            {
                DatabaseContext db = new DatabaseContext();
                Persons per = db.Persons.Find(pid);

                //List<Addresses> adr = db.Adresses.Where(x => x.Persons.Id == per.Id).ToList(); //benim çözümüm
                List<Addresses> adr = (from s in db.Adresses where s.Persons.Id == pid select s).ToList();
                db.Adresses.RemoveRange(adr);
                db.Persons.Remove(per);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Ef");
        }
    }
}