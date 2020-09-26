using AnnisaCake.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnnisaCake.Web.Controllers
{
    public class B_BakuMasukController : Controller
    {
        public SI_TKueEntities si_kue = new SI_TKueEntities();
        // GET: B_BakuMasuk
        public ActionResult BahanBaku_Masuk()
        {
            return View();
        }

        // GET: B_BakuMasuk/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: B_BakuMasuk/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: B_BakuMasuk/Create
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

        // GET: B_BakuMasuk/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: B_BakuMasuk/Edit/5
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

        // GET: B_BakuMasuk/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: B_BakuMasuk/Delete/5
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
