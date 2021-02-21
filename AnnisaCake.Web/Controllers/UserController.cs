using AnnisaCake.Web.Helper;
using AnnisaCake.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnnisaCake.Web.Controllers
{
    public class UserController : Controller
    {
        private SI_TKueEntities db = new SI_TKueEntities();

        // GET: User
        [UserAuditFilter]
        public ActionResult Index(int? methode)
        {
            if (methode != null && methode == 2)
            {
                //db.Configuration.ProxyCreationEnabled = false;
                var data2 = db.users.ToList();
                var data = data2.Select(x => new
                {
                    id_user = x.id_user,
                    nama_user = x.nama_user,
                    no_hp = x.no_hp,
                    alamat = x.alamat,
                    email = x.email,
                    role = db.role_user.Find(x.id_role).role.ToString()

                });
                return Json(new { data }, JsonRequestBehavior.AllowGet);
            }

            return View(db.users.ToList());
        }

        public ActionResult GetUser()
        {
            List<user> user = db.users.ToList();
            return Json( user , JsonRequestBehavior.AllowGet);
        }
        // GET: User/Create
        public ActionResult CreateUser()
        {
            ViewBag.RoleUser = db.role_user.ToList();
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult CreateUser(user user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Added;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: User/Edit/5
        public ActionResult EditUser(int id_user)
        {
            ViewBag.RoleUser = db.role_user.ToList();
            user user = db.users.Find(id_user);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult EditUser(user user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        public JsonResult DeleteUser(int id_user)
        {
            try
            {
                user user = db.users.Find(id_user);
                db.users.Remove(user);
                db.SaveChanges();
                return Json(new { message = "succes" });
            }
            catch
            {
                return Json(new { message = "failed" });
            }
        }
    }
}
