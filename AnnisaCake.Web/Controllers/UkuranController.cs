﻿using AnnisaCake.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnnisaCake.Web.Controllers
{
    public class UkuranController : Controller
    {
        // GET: Ukuran
        public SI_TKueEntities db = new SI_TKueEntities();
        public ActionResult UkuranKue(int? methode)
        {
            //if(methode!=null && methode == 2)
            //{
            //    var toping =db.to
            //    var data = db.ukuran_kue.ToList();
            //    var data2 = data.Select(x => new
            //    {
            //        id_ukuran = x.id_ukuran,
            //        jenis_ukuran=x.jenis_ukuran,
            //        toping=db.topings.
            //        nama_kategori = x.nama_kategori
            //    });

            //    return Json(new { data = data2 }, JsonRequestBehavior.AllowGet);

          //  }
            return View();
        }

       

        // GET: Ukuran/Create
        public ActionResult CreateUkuran()
        {
            return View();
        }

        // POST: Ukuran/Create
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

        // GET: Ukuran/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ukuran/Edit/5
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

        // GET: Ukuran/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ukuran/Delete/5
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
