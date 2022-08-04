using ResumeWebSite.Models.Entity;
using ResumeWebSite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeWebSite.Controllers
{
    public class AboutMeController : Controller
    {
        // GET: AboutMe
        GenericRepository<AboutMe> aboutMeRepositories = new GenericRepository<AboutMe>();

        public ActionResult Index()
        {
            var variables = aboutMeRepositories.List();
            return View(variables);
        }
        [HttpGet]
        public ActionResult GetMe(int id)
        {
            AboutMe me = aboutMeRepositories.Find(x => x.Id == id);
            return View(me);
        }
        [HttpPost]
        public ActionResult GetMe(AboutMe ame)
        {
            AboutMe me = aboutMeRepositories.Find(x => x.Id == ame.Id);
            me.FirstName = ame.FirstName;
            me.Address = ame.Address;
            me.Phone = ame.Phone;
            me.Mail = ame.Mail;
            me.Description = ame.Description;
            me.Photo = ame.Photo;
            aboutMeRepositories.TUpdate(me);
            return RedirectToAction("Index");
        }

        DbResumeEntities db = new DbResumeEntities();
        

    }
}