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
    public class Toping_KueController : Controller
    {
        public SI_TKueEntities si_kue = new SI_TKueEntities();
        // GET: Toping_Kue
        public ActionResult Toping_Kue()
        {
            var data = si_kue.topings.ToList();
            return View(data);
        }

        // GET: Toping_Kue/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Toping_Kue/Create
        public ActionResult CreateToping()
        {
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
                    si_kue.topings.Add(toping);
                    si_kue.SaveChanges();
                    return RedirectToAction("Toping_Kue");
                }
                return View(toping);
            }
            catch
            {
                return View();
            }
        }

        // GET: Toping_Kue/Edit/5
        public ActionResult EditToping(int?kode_toping)
        {
            //if (id == null)

            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //    toping toping = si_kue.topings.Find(id);

            //if (toping == null)
            //    return HttpNotFound();
            //return View(toping);

            toping toping = si_kue.topings.Find(kode_toping);
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
                    si_kue.Entry(toping).State = EntityState.Modified;
                    si_kue.SaveChanges();

                    return RedirectToAction("Toping_Kue");
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
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
