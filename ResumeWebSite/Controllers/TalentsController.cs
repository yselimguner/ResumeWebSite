using ResumeWebSite.Models.Entity;
using ResumeWebSite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeWebSite.Controllers
{
    public class TalentsController : Controller
    {
        // GET: Talents
        GenericRepository<Talents> talentRepository = new GenericRepository<Talents>();
        DbResumeEntities dbResume = new DbResumeEntities();
        public ActionResult Index()
        {
            var variables = talentRepository.List();
            return View(variables);
        }
        [HttpGet]
        public ActionResult TalentAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TalentAdd(Talents p)
        {
            talentRepository.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult TalentDelete(int id)
        {
            //var dtalent = dbResume.Talents.Find(id);
            //dbResume.Talents.Remove(dtalent);
            //dbResume.SaveChanges();
            //return RedirectToAction("Index");

            Talents t = talentRepository.Find(x => x.Id == id);
            talentRepository.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetTalents(int id)
        {
            Talents t = talentRepository.Find(x => x.Id == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetTalents(Talents tal)
        {
            Talents t = talentRepository.Find(x => x.Id == tal.Id);
            t.Name = tal.Name;
            t.Description = tal.Description;
            t.TalentImage = tal.TalentImage;
            talentRepository.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}