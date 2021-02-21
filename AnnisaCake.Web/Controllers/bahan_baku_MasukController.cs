﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using System.Web.Services;
using AnnisaCake.Web.Helper;
using AnnisaCake.Web.Models;
using AnnisaCake.Web.Tools;

namespace AnnisaCake.Web.Controllers
{
    public class bahan_baku_MasukController : Controller
    {
        private SI_TKueEntities db = new SI_TKueEntities();

        [UserAuditFilter]
        // GET: bahan_baku_Masuk
        public ActionResult Index(int ?methode)
        {
            if (methode!=null && methode== 2){
                //db.Configuration.ProxyCreationEnabled = false;
                var data = db.bahan_baku_Masuk.ToList();
                var data2 = data.Select(x => new {
                        id=x.id,
                        tgl_pembelian=x.tgl_pembelian.ToString("dd/MM/yyyy"),
                        nama_bahan_baku= x.bahan_baku.nama_bahan_baku,
                        jumlah=x.jumlah,
                        satuan =x.satuan,
                        harga=x.harga
                    });
                
                return Json(new { data = data2 }, JsonRequestBehavior.AllowGet);
            }

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
            ViewBag.bahanBaku = db.bahan_baku.ToList();
            return View();
        }

        // POST: bahan_baku_Masuk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(bahan_baku_Masuk bahan_baku_Masuk)
        {
            ViewBag.bahanBaku = db.bahan_baku.ToList();
            try
            {
                if (ModelState.IsValid)
                {
                    bahan_baku bahanBaku = db.bahan_baku.Find(bahan_baku_Masuk.id_bahan_baku);
                    db.Entry(bahan_baku_Masuk).State = EntityState.Added;
                    //db.bahan_baku_Masuk.Add(bahan_baku_Masuk);
                    db.SaveChanges();

                    //Add stok into Bahan baku 

                    bahanBaku.stok += bahan_baku_Masuk.jumlah;
                    db.Entry(bahanBaku).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

            }
            catch (Exception x)
            {
                return View();

            }
            return View();
        }

        // GET: bahan_baku_Masuk/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.bahanBaku = db.bahan_baku.ToList();
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
        public ActionResult Edit(bahan_baku_Masuk bahanBakuMasukParam)
        {
            if (ModelState.IsValid)
            {
                bahan_baku_Masuk bahanBakuMasuk = (bahan_baku_Masuk)db.bahan_baku_Masuk.AsNoTracking().Where(x => x.id == bahanBakuMasukParam.id).FirstOrDefault();

                //edit bahan_baku_masuk
                
                db.Entry(bahanBakuMasukParam).State = EntityState.Modified;
                db.SaveChanges();

                //Remove stok from bahan_baku 
                
                bahan_baku bahanBaku = db.bahan_baku.Find(bahanBakuMasuk.id_bahan_baku);
                bahanBaku.stok -= bahanBakuMasuk.jumlah;
                db.Entry(bahanBaku).State = EntityState.Modified;
                db.SaveChanges();
                //Add bahan_baku again to bahan_baku from new bahan_baku_Masuk
                bahan_baku bahanBaku2 = db.bahan_baku.Find(bahanBakuMasukParam.id_bahan_baku);
                bahanBaku2.stok += bahanBakuMasukParam.jumlah;
                db.Entry(bahanBaku2).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(bahanBakuMasukParam);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                bahan_baku_Masuk bahan_baku_Masuk = db.bahan_baku_Masuk.Find(id);
                db.bahan_baku_Masuk.Remove(bahan_baku_Masuk);
                db.SaveChanges();
                return Json(new { message = "succes" });
            }
            catch
            {
                return Json(new { message = "failed" });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public JsonResult GetSatuan(int idBahanBaku)
        {
            String satuan = db.bahan_baku.Find(idBahanBaku).satuan.ToString();
            return Json(new { satuan = satuan }, JsonRequestBehavior.AllowGet);
            //return (data);
        }
    }
}
