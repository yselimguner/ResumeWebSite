using ResumeWebSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ResumeWebSite.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        DbResumeEntities db = new DbResumeEntities();
        public ActionResult Index()
        {
            var values = db.AboutMe.ToList(); 
            return View(values);
        }
        public PartialViewResult Services()
        {
            var service = db.Services.ToList();
            return PartialView(service);
        }
        public PartialViewResult Certificates()
        {
            var certificate = db.Certificates.ToList();
            return PartialView(certificate);
        }
        
        
        public PartialViewResult Hobbies()
        {
            var hobby = db.Hobbies.ToList();
            return PartialView(hobby);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(Contact c)
        {
            c.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Contact.Add(c);
            db.SaveChanges();
            return PartialView();
        }

        public PartialViewResult Education()
        {
            var edu = db.Education.ToList();
            return PartialView(edu);
        }

        public PartialViewResult Talents()
        {
            var tal = db.Talents.ToList();
            return PartialView(tal);
        }
        public PartialViewResult SocialMedia()
        {
            var sm = db.SocialMedia.ToList();
            return PartialView(sm);
        }
        public PartialViewResult Skill()
        {
            var skill = db.Skill.ToList();
            return PartialView(skill);
        }

    }
}