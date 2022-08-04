using ResumeWebSite.Models.Entity;
using ResumeWebSite.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeWebSite.Controllers
{
    [Authorize]
    public class CertificateController : Controller
    {
        GenericRepository<Certificates> certrepo = new GenericRepository<Certificates>();
        // GET: Certificate
  
        public ActionResult Index()
        {
            var variables = certrepo.List();
            return View(variables);
        }
        [HttpGet]
        public ActionResult CertificateAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CertificateAdd(Certificates c)
        {
            certrepo.TAdd(c);
            return RedirectToAction("Index");
        }
        public ActionResult CertificateDelete(int id)
        {
            Certificates c = certrepo.Find(x => x.Id == id);
            certrepo.TDelete(c);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCertificate(int id)
        {
            Certificates c = certrepo.Find(x => x.Id == id);
            return View(c);
        }
        [HttpPost]
        public ActionResult UpdateCertificate(Certificates cer)
        {
            Certificates c = certrepo.Find(x => x.Id == cer.Id);
            c.Title = cer.Title;
            c.Category = cer.Category;
            c.Image = cer.Image;
            c.Date = cer.Date;
            certrepo.TUpdate(c);
            return RedirectToAction("Index");
        }
    }
}