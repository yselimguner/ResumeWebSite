using ResumeWebSite.Models.Entity;
using ResumeWebSite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeWebSite.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        GenericRepository<Skill> skrepo = new GenericRepository<Skill>();
        public ActionResult Index()
        {
            var variables = skrepo.List();
            return View(variables);
        }

        [HttpGet]
        public ActionResult SkillAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SkillAdd(Skill sk)
        {
            skrepo.TAdd(sk);
            return RedirectToAction("Index");
        }
        public ActionResult SkillDelete(int id)
        {
            Skill sk = skrepo.Find(x => x.Id == id);
            skrepo.TDelete(sk);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            Skill sk = skrepo.Find(x => x.Id == id);
            return View(sk);
        }
        [HttpPost]
        public ActionResult UpdateSkill(Skill ski)
        {
            Skill sk = skrepo.Find(x => x.Id == ski.Id);
            sk.Name = ski.Name;
            sk.Percentage = ski.Percentage;
            skrepo.TUpdate(sk);
            return RedirectToAction("Index");
        }
    }
}