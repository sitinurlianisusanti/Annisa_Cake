using AnnisaCake.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnnisaCake.Web.Controllers
{
    public class BahanBakuKeluarController : Controller
    {
        private SI_TKueEntities db = new SI_TKueEntities();

        // GET: BahanBakuKeluar
        public ActionResult BahanBakuKeluar(int?methode)
        {
            if (methode != null && methode == 2)
            {
                //db.Configuration.ProxyCreationEnabled = false;
                var data = db.bahan_baku_keluar.ToList();
                var data2 = data.Select(x => new {
                    id = x.id,
                    tanggal_keluar = x.tgl_keluar.ToString("dd/MM/yyyy"),
                    nama_bahan_baku = x.bahan_baku.nama_bahan_baku,
                    jumlah = x.jumlah,
                    satuan = x.satuan,
                    deskripsi = x.deskripsi
                });

                return Json(new { data = data2 }, JsonRequestBehavior.AllowGet);
            }

            return View();
        }

        // GET: BahanBakuKeluar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BahanBakuKeluar/Create
        public ActionResult CreateBahanBakuKeluar()
        {
            ViewBag.bahanBaku = db.bahan_baku.ToList();
            return View();
        }

        // POST: BahanBakuKeluar/Create
        [HttpPost]
        public ActionResult CreateBahanBakuKeluar(bahan_baku_keluar bahanBakuKeluar)
        {

            ViewBag.bahanBaku = db.bahan_baku.ToList();
            try
            {
               
                bahan_baku bahanBaku = db.bahan_baku.Find(bahanBakuKeluar.id_bahan_baku);
                if (bahanBaku!=null && bahanBaku.stok < bahanBakuKeluar.jumlah)
                {
                    ModelState.AddModelError("jumlah", "Jumlah lebih besar dari stok");
                }
                else
                {
                    db.Entry(bahanBakuKeluar).State = EntityState.Added;
                    db.SaveChanges();

                    //decrease stok bahan baku
                    bahanBaku.stok -= bahanBakuKeluar.jumlah;
                    db.Entry(bahanBaku).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("BahanBakuKeluar");
                }
                
                return View();

            }
            catch(Exception x)
            {
                return View();
            }
        }

        // GET: BahanBakuKeluar/Edit/5
        public ActionResult EditBahanBakuKeluar(int? id)
        {
            ViewBag.bahanBaku = db.bahan_baku.ToList();
            bahan_baku_keluar bahanBakuKeluar = db.bahan_baku_keluar.Find(id);
            return View(bahanBakuKeluar);
        }

        // POST: BahanBakuKeluar/Edit/5
        [HttpPost]
        public ActionResult EditBahanBakuKeluar(bahan_baku_keluar bahanBakuKeluarParama)
        {
            ViewBag.bahanBaku = db.bahan_baku.ToList();
            try
            {
                bahan_baku_keluar bahanBakuKeluar = (bahan_baku_keluar)db.bahan_baku_keluar.AsNoTracking().
                    Where(x => x.id == bahanBakuKeluarParama.id).FirstOrDefault();

                //edit bahan_baku_masuk

                db.Entry(bahanBakuKeluarParama).State = EntityState.Modified;
                db.SaveChanges();

                //Remove stok from bahan_baku 

                bahan_baku bahanBaku = db.bahan_baku.Find(bahanBakuKeluar.id_bahan_baku);
                bahanBaku.stok += bahanBakuKeluar.jumlah;
                db.Entry(bahanBaku).State = EntityState.Modified;
                db.SaveChanges();
                //Add bahan_baku again to bahan_baku from new bahan_baku_Masuk
                bahan_baku bahanBaku2 = db.bahan_baku.Find(bahanBakuKeluarParama.id_bahan_baku);
                bahanBaku2.stok -= bahanBakuKeluarParama.jumlah;
                db.Entry(bahanBaku2).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("BahanBakuKeluar");
            }
            catch
            {
                return View();
            }
        }

        // POST: BahanBakuKeluar/Delete/5
        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                bahan_baku_keluar bahanBakuKeluar = db.bahan_baku_keluar.Find(id);
                bahan_baku bahanBaku = (bahan_baku)db.bahan_baku.AsNoTracking().
                        Where(x => x.id_bahan_baku == bahanBakuKeluar.id_bahan_baku).FirstOrDefault();

                db.bahan_baku_keluar.Remove(bahanBakuKeluar);
                db.SaveChanges();

                //add stok again
                bahanBaku.stok += bahanBakuKeluar.jumlah;
                db.Entry(bahanBaku).State = EntityState.Modified;
                db.SaveChanges();

                return Json(new { message = "succes" });
            }
            catch
            {
                return Json(new { message = "failed" });
            }
        }
        [HttpGet]
        public JsonResult GetSatuan(int idBahanBaku)
        {
            String satuan = db.bahan_baku.Find(idBahanBaku).satuan.ToString();
            return Json(new { satuan = satuan }, JsonRequestBehavior.AllowGet);
        }
    }
}
