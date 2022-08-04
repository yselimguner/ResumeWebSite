using ResumeWebSite.Models.Entity;
using ResumeWebSite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeWebSite.Controllers
{
    public class HobbiesController : Controller
    {
        // GET: Hobbies
        GenericRepository<Hobbies> horepo = new GenericRepository<Hobbies>();
        public ActionResult Index()
        {
            var variables = horepo.List();
            return View(variables);
        }

        [HttpGet]
        public ActionResult HobbyAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult HobbyAdd(Hobbies h)
        {
            horepo.TAdd(h);
            return RedirectToAction("Index");
        }

        public ActionResult HobbyDelete(int id)
        {
            Hobbies h = horepo.Find(x => x.Id == id);
            horepo.TDelete(h);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateHobbies(int id)
        {
            Hobbies h = horepo.Find(x => x.Id == id);
            return View(h);
        }
        [HttpPost]
        public ActionResult UpdateHobbies(Hobbies hob)
        {
            Hobbies h = horepo.Find(x => x.Id == hob.Id);
            h.Categories = hob.Categories;
            h.Date = hob.Date;
            h.Description = hob.Description;
            h.Images = hob.Images;
            h.Title = hob.Title;
            horepo.TUpdate(h);
            return RedirectToAction("Index");
        }
    }
}