using AnnisaCake.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnnisaCake.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(user objUser)
        {
            if (ModelState.IsValid)
            {
                using (SI_TKueEntities db = new SI_TKueEntities())
                {
                    var obj = db.users.Where(a => a.nama_user.Equals(objUser.nama_user) && a.sandi.Equals(objUser.sandi)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["role"] = obj.id_role.ToString();
                        Session["username"] = obj.nama_user.ToString();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}