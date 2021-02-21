using AnnisaCake.Web.Helper;
using AnnisaCake.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AnnisaCake.Web.Controllers
{
    public class UkuranController : Controller
    {
        // GET: Ukuran
        public SI_TKueEntities db = new SI_TKueEntities();

        [UserAuditFilter]
        public ActionResult UkuranKue()
        {
            return View();
        }

        public ActionResult GetUkuranKue()
        {
                var data = db.ukuran_kue.ToList();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }



        // GET: Ukuran/Create
        [UserAuditFilter]
        public ActionResult CreateUkuran()
        {
            return View();
        }

        // POST: Ukuran/Create
        [HttpPost]
        public ActionResult CreateUkuran(ukuran_kue ukuranKue)
        {
            try
            {
                db.Entry(ukuranKue).State = EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("UkuranKue");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ukuran/Edit/5
        public ActionResult EditUkuran(int idUkuran)
        {
            ukuran_kue ukuraKue = db.ukuran_kue.Find(idUkuran);
            return View(ukuraKue);
        }

        // POST: Ukuran/Edit/5
        [HttpPost]
        public ActionResult EditUkuran(ukuran_kue ukuraKue)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(ukuraKue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UkuranKue");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeleteUkuran(int? idUkuran)
        {
            try
            {
                ukuran_kue ukuranKue = db.ukuran_kue.Find(idUkuran);
                db.ukuran_kue.Remove(ukuranKue);
                db.SaveChanges();
                return Json(new { message = "succes" });
            }
            catch
            {
                return Json(new { message = "succes" });
            }

        }
    }
}
