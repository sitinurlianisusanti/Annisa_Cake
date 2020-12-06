using AnnisaCake.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AnnisaCake.Web.Controllers
{
    public class KategoriController : Controller
    {
        public SI_TKueEntities db = new SI_TKueEntities();
        // GET: Category
        public ActionResult Kategori(int? methode)
        {
            var data = db.categories.ToList();
            if (methode != null && methode == 2)
            {
                var data2 = data.Select(x => new
                {
                    id = x.id,
                    nama_kategori = x.nama_kategori
                });

                return Json(new { data = data2 }, JsonRequestBehavior.AllowGet);
            }

            return View(data);
        }

        // GET: Category/Details/5
        public ActionResult DetailsKategori(int? id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            category category = db.categories.Find(id);

            if (category == null)
                return HttpNotFound();
            return View(category);
        }

        // GET: Category/Create
        public ActionResult CreateKategori()
        {
            return View();
        }


        // POST: Category/Create
        [HttpPost]
        public ActionResult CreateKategori(category category)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Kategori");
                }
                return View(category);
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult EditKategori(int? id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            category category = db.categories.Find(id);

            if (category == null)
                return HttpNotFound();
            return View(category);
        }
        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult EditKategori(category category)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    db.Entry(category).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Kategori");
                }
                return View(category);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult DeleteKategori(int? id)
        {
            try
            {
                category category = db.categories.Find(id);
                db.categories.Remove(category);
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
