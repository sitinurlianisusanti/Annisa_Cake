using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnnisaCake.Web.Models;

namespace AnnisaCake.Web.Controllers
{
    public class bahan_baku_MasukController : Controller
    {
        private SI_TKueEntities db = new SI_TKueEntities();

        // GET: bahan_baku_Masuk
        public ActionResult Index()
        {
            return View(db.bahan_baku_Masuk.ToList());
        }

        // GET: bahan_baku_Masuk/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bahan_baku_Masuk bahan_baku_Masuk = db.bahan_baku_Masuk.Find(id);
            if (bahan_baku_Masuk == null)
            {
                return HttpNotFound();
            }
            return View(bahan_baku_Masuk);
        }

        // GET: bahan_baku_Masuk/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: bahan_baku_Masuk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tgl_pembelian,bahan_baku,jumlah,satuan,harga")] bahan_baku_Masuk bahan_baku_Masuk)
        {
            if (ModelState.IsValid)
            {
                db.bahan_baku_Masuk.Add(bahan_baku_Masuk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bahan_baku_Masuk);
        }

        // GET: bahan_baku_Masuk/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bahan_baku_Masuk bahan_baku_Masuk = db.bahan_baku_Masuk.Find(id);
            if (bahan_baku_Masuk == null)
            {
                return HttpNotFound();
            }
            return View(bahan_baku_Masuk);
        }

        // POST: bahan_baku_Masuk/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tgl_pembelian,bahan_baku,jumlah,satuan,harga")] bahan_baku_Masuk bahan_baku_Masuk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bahan_baku_Masuk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bahan_baku_Masuk);
        }

        // GET: bahan_baku_Masuk/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bahan_baku_Masuk bahan_baku_Masuk = db.bahan_baku_Masuk.Find(id);
            if (bahan_baku_Masuk == null)
            {
                return HttpNotFound();
            }
            return View(bahan_baku_Masuk);
        }

        // POST: bahan_baku_Masuk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bahan_baku_Masuk bahan_baku_Masuk = db.bahan_baku_Masuk.Find(id);
            db.bahan_baku_Masuk.Remove(bahan_baku_Masuk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
