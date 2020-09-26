using AnnisaCake.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AnnisaCake.Web.Controllers
{
    public class KueController : Controller
    {
        public SI_TKueEntities si_kue = new SI_TKueEntities();
        // GET: Kue
        public ActionResult Kue()
        {
            var data = si_kue.SP_GetAllKue().ToList();
            return View(data);
        }

        // GET: Kue/Details/5
        public ActionResult DetailsKue(int? id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            kue kue = si_kue.kues.Find(id);

            if (kue == null)
                return HttpNotFound();
            return View(kue);
        }

        // GET: Kue/Create
       
        public ActionResult CreateKue()
        {
            kue kue = new kue();
            kue.Kategoris = si_kue.categories.ToList<category>();
            return View(kue);
        }

    
        [HttpPost]
        public ActionResult CreateKue(kue kue )
        {
            try
            {
                // TODO: Add insert logic here

               
                string fileName = Path.GetFileNameWithoutExtension(kue.UploadFile.FileName);
                string extension = Path.GetExtension(kue.UploadFile.FileName);
                fileName = fileName + extension;
                kue.gambar = "~/Content/picCake" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/picCake"), fileName);
                kue.UploadFile.SaveAs(fileName);
                if (ModelState.IsValid) 
                {
                    if (kue.UploadFile != null) 
                    {
                        kue k = new kue();
                        k.gambar = kue.UploadFile.FileName;
                        k.nama_kue = kue.nama_kue;
                        k.id_category = kue.id_category;
                        k.harga = kue.harga;
                        k.stok = kue.stok;
                        si_kue.kues.Add(k);
                        si_kue.SaveChanges();
                        return RedirectToAction("Kue");
                        
                    }
                    
                }
                kue.Kategoris = si_kue.categories.ToList<category>();

                return View(kue);
            }
            catch
            {
                return View();
            }
        }

        // GET: Kue/Edit/5
        public ActionResult EditKue(int? id)
        {
            //kue kue = new kue();
           
           
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            kue kue = si_kue.kues.Find(id);
            kue.Kategoris = si_kue.categories.ToList<category>();
            ViewBag.pathImage = "../../Content/picCake/"+ kue.gambar;
            //tes change git + dev
            // add comment for dev 2
            //buat crud
            if (kue == null)
                return HttpNotFound();
            return View(kue);
        }

        // POST: Kue/Edit/5
        [HttpPost]
        public ActionResult EditKue(kue kue)
        {
            //add crud alamat
            try
            {
                if (kue.gambar != null) { 
                
                
                }
                string fileName = Path.GetFileNameWithoutExtension(kue.UploadFile.FileName);
                string extension = Path.GetExtension(kue.UploadFile.FileName);
                fileName = fileName + extension;
                kue.gambar = "~/Content/picCake" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/picCake"), fileName);
                kue.UploadFile.SaveAs(fileName);
                if (ModelState.IsValid)
                {
                    si_kue.Entry(kue).State = EntityState.Modified;
                    si_kue.SaveChanges();

                    return RedirectToAction("Kue");
                }
                kue.Kategoris = si_kue.categories.ToList<category>();
         
                return View(kue);
            }
            catch
            {
                return View();
            }
        }

        // GET: Kue/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Kue/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
