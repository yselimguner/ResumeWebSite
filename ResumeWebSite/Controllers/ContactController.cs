using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeWebSite.Models.Entity;
using ResumeWebSite.Repositories;

namespace ResumeWebSite.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        GenericRepository<Contact> contrepo = new GenericRepository<Contact>();
        public ActionResult Index()
        {
            var variables = contrepo.List();
            return View(variables);
        }

        public ActionResult DeleteComment(int id)
        {
            Contact c = contrepo.Find(x => x.Id == id);
            contrepo.TDelete(c);
            return RedirectToAction("Index");
        }
    }
}