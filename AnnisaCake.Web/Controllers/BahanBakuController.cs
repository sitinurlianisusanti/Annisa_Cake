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
    public class BahanBakuController : Controller
    {
        private SI_TKueEntities db = new SI_TKueEntities();
        // GET: BahanBaku
        [UserAuditFilter]
        public ActionResult BahanBaku(int ?methode)
        {
            if(methode !=null && methode == 2)
            {
                var data = db.bahan_baku.ToList();
                var data2 = data.Select(x => new
                {
                    id_bahan_baku = x.id_bahan_baku,
                    nama_bahan_baku = x.nama_bahan_baku,
                    satuan = x.satuan,
                    stok = x.stok
                });
                return Json(new { data = data2 }, JsonRequestBehavior.AllowGet);
            }
            return View(db.bahan_baku.ToList());
        }
       

        // GET: BahanBaku/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BahanBaku/Create
        public ActionResult CreateBahanBaku()
        {
            return View();
        }

        // POST: BahanBaku/Create
        [HttpPost]
        public ActionResult CreateBahanBaku(bahan_baku bahanBaku)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    bahanBaku.stok = 0;
                    db.Entry(bahanBaku).State = EntityState.Added;

                db.bahan_baku.Add(bahanBaku);
                    db.SaveChanges();
                    return RedirectToAction("BahanBaku");
                }
                return View(bahanBaku);
            }
            catch
            {
                return View();
            }
        }

        // GET: BahanBaku/Edit/5
        public ActionResult EditBahanBaku(int idBahanBaku)
        {
            bahan_baku bahanBaku= db.bahan_baku.Find(idBahanBaku);
            return View(bahanBaku);
        }

        // POST: BahanBaku/Edit/5
        [HttpPost]
        public ActionResult EditBahanBaku(bahan_baku bahanBaku)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(bahanBaku).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("BahanBaku");
                }
                return View(bahanBaku);
            }
            catch
            {
                return View();
            }
        }

        // POST: BahanBaku/Delete/5
        [HttpPost]
        public JsonResult DeleteBahanBaku(int idBahanBaku)
        {
            try
            {
                bahan_baku bahanBaku = db.bahan_baku.Find(idBahanBaku);
                db.bahan_baku.Remove(bahanBaku);
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
