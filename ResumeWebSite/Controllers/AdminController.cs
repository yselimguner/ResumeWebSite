using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeWebSite.Models.Entity;
using ResumeWebSite.Repositories;

namespace ResumeWebSite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Admin> adrepo = new GenericRepository<Admin>();//İsteseydim Yeni Bir Admin Repository tanımlayabilirdim ama onun yerine bunu yaptım.
        
        public ActionResult Index()
        {
            var variables = adrepo.List();
            return View(variables);
        }

        [HttpGet]
        public ActionResult AdminAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAdd(Admin p)
        {
            adrepo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult AdminDelete(int id)
        {
            Admin a = adrepo.Find(x => x.Id == id);
            adrepo.TDelete(a);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            Admin a = adrepo.Find(x => x.Id == id);
            return View(a);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin ad)
        {
            Admin a = adrepo.Find(x => x.Id == ad.Id);
            a.Username = ad.Username;
            a.Password = ad.Password;
            adrepo.TUpdate(a);
            return RedirectToAction("Index");
        }
    }
}