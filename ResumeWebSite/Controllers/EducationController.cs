using ResumeWebSite.Models.Entity;
using ResumeWebSite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeWebSite.Controllers
{
    public class EducationController : Controller
    {
        GenericRepository<Education> edurepo = new GenericRepository<Education>();
        // GET: Education
        public ActionResult Index()
        {
            var variables = edurepo.List();
            return View(variables);
        }

        [HttpGet]
        public ActionResult EducationAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EducationAdd(Education e)
        {
            if (!ModelState.IsValid)
            {
                return View("EducationAdd");
            }
            edurepo.TAdd(e);
            return RedirectToAction("Index");
        }

        public ActionResult EducationDelete(int id)
        {
            //var dtalent = dbResume.Talents.Find(id);
            //dbResume.Talents.Remove(dtalent);
            //dbResume.SaveChanges();
            //return RedirectToAction("Index");

            Education e = edurepo.Find(x => x.Id == id);
            edurepo.TDelete(e);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetEdu(int id)
        {
            Education e = edurepo.Find(x => x.Id == id);
            return View(e);
        }
        [HttpPost]
        public ActionResult GetEdu(Education ed)
        {
            if (!ModelState.IsValid)
            {
                return View("GetEdu");
            }
            Education e = edurepo.Find(x => x.Id == ed.Id);
            e.Number = ed.Number;
            e.Description = ed.Description;
            e.Class = ed.Class;
            edurepo.TUpdate(e);
            return RedirectToAction("Index");
        }
    }
}