using ResumeWebSite.Models.Entity;
using ResumeWebSite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeWebSite.Controllers
{
    public class ServicesController : Controller
    {
        GenericRepository<Services> servicerepo = new GenericRepository<Services>();
        // GET: Services
        public ActionResult Index()
        {
            var variables = servicerepo.List();
            return View(variables);
        }

        [HttpGet]
        public ActionResult ServiceAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ServiceAdd(Services s)
        {
            servicerepo.TAdd(s);
            return RedirectToAction("Index");
        }

        public ActionResult ServiceDelete(int id)
        {
            Services s = servicerepo.Find(x => x.Id == id);
            servicerepo.TDelete(s);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            Services s = servicerepo.Find(x => x.Id == id);
            return View(s);
        }
        [HttpPost]
        public ActionResult UpdateService(Services ser)
        {
            Services s = servicerepo.Find(x => x.Id == ser.Id);
            s.Name = ser.Name;
            s.Description = ser.Description;
            s.Icon = ser.Icon;
            servicerepo.TUpdate(s);
            return RedirectToAction("Index");
        }
    }
}