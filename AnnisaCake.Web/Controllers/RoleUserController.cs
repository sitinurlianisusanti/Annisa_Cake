using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnnisaCake.Web.Models;

namespace AnnisaCake.Web.Controllers
{
    public class RoleUserController : Controller
    {
        private SI_TKueEntities db = new SI_TKueEntities();
        // GET: RoleUser
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRoleUser()
        {
            List<role_user> role = db.role_user.ToList();
            return Json(role, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetRoleUserIndex()
        {
            List<role_user> role = db.role_user.ToList();
            return Json(new { data = role }, JsonRequestBehavior.AllowGet);
        }

        // GET: RoleUser/Create
        public ActionResult CreateRoleUser()
        {
            return View();
        }

        // POST: RoleUser/Create
        [HttpPost]
        public ActionResult CreateRoleUser(role_user roleUser)
        {

            try
            {
                db.Entry(roleUser).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleUser/Edit/5
        public ActionResult EditRoleUser(int idRole)
        {
            role_user roleUser = db.role_user.Find(idRole);
            return View(roleUser);
        }

        // POST: RoleUser/Edit/5
        [HttpPost]
        public ActionResult EditRoleUser(role_user roleUser)
        {
            try
            {
                db.Entry(roleUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeleteRoleUser(int idRole)
        {
            try
            {
                role_user roleUser = db.role_user.Find(idRole);
                db.role_user.Remove(roleUser);
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
