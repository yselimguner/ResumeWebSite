using ResumeWebSite.Models.Entity;
using ResumeWebSite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeWebSite.Controllers
{
    public class SocialMediaController : Controller
    {
        GenericRepository<SocialMedia> smediarepo = new GenericRepository<SocialMedia>();
        // GET: SocialMedia
        public ActionResult Index()
        {
            var variables = smediarepo.List();
            return View(variables);
        }

        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(SocialMedia sm)
        {
            smediarepo.TAdd(sm);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {

            SocialMedia sm = smediarepo.Find(x => x.Id == id);
            smediarepo.TDelete(sm);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            SocialMedia sm = smediarepo.Find(x => x.Id == id);
            return View(sm);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia sme)
        {
            SocialMedia sm = smediarepo.Find(x => x.Id == sme.Id);
            sm.Brand = sme.Brand;
            sm.link = sme.link;
            sm.icon = sme.icon;
            smediarepo.TUpdate(sm);
            return RedirectToAction("Index");
        }
    }
}