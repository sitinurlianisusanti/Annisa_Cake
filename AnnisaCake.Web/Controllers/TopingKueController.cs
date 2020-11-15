using AnnisaCake.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AnnisaCake.Web.Controllers
{
    public class TopingKueController : Controller
    {
        public SI_TKueEntities db = new SI_TKueEntities();
        // GET: Toping_Kue
        public ActionResult TopingKue(int? methode)
        {
            if (methode != null && methode == 2)
            {
                var data = db.topings.ToList();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
            var dataTopings = db.topings.ToList();
            return View(dataTopings);
        }

        // GET: Toping_Kue/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Toping_Kue/Create
        public ActionResult CreateToping()
        {
            var newKodeToping = 1;
            try
            {
                newKodeToping = db.topings.Max(x => x.kode_toping)+1;
            }
            catch (Exception X)
            {

            }
            ViewBag.newKodeToping = newKodeToping;
            return View();
        }

        // POST: Toping_Kue/Create
        [HttpPost]
        public ActionResult CreateToping(toping toping)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    db.topings.Add(toping);
                    db.SaveChanges();
                    return RedirectToAction("TopingKue");
                }
                return View(toping);
            }
            catch
            {
                return View();
            }
        }

        // GET: Toping_Kue/Edit/5
        public ActionResult EditToping(int?kodeToping)
        {

            toping toping = db.topings.Find(kodeToping);
            return View(toping);
        }

        // POST: Toping_Kue/Edit/5
        [HttpPost]
        public ActionResult EditToping(toping toping)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    db.Entry(toping).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("TopingKue");
                }
                return View(toping);
            }
            catch
            {
                return View();
            }
        }

        // GET: Toping_Kue/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Toping_Kue/Delete/5
        [HttpPost]
        public JsonResult DeleteToping(int kodeToping)
        {
            try
            {
                toping toping = db.topings.Find(kodeToping);
                db.topings.Remove(toping);
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
