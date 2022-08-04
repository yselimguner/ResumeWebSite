using ResumeWebSite.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ResumeWebSite.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            DbResumeEntities db = new DbResumeEntities();
            var user = db.Admin.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (user !=null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                Session["Username"] = user.Username.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}