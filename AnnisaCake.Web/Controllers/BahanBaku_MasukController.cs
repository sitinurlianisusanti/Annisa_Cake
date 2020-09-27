using AnnisaCake.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnnisaCake.Web.Controllers
{
    public class BahanBaku_MasukController : Controller
    {
        public SI_TKueEntities db = new SI_TKueEntities();
        // GET: BahanBaku_Masuk
        public ActionResult BahanBaku_Masuk()
        {
            return View(db.bahan_baku_Masuk.ToList());
        }

        // GET: BahanBaku_Masuk/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BahanBaku_Masuk/Create
        public ActionResult CreateBahanBaku_Masuk()
        {
            return View();
        }

        // POST: BahanBaku_Masuk/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BahanBaku_Masuk/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BahanBaku_Masuk/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BahanBaku_Masuk/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BahanBaku_Masuk/Delete/5
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
