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
        public ActionResult CreateKue(kue kue)
        {
            try
            {
                // TODO: Add insert logic here


                string fileName = Path.GetFileNameWithoutExtension(kue.UploadFile.FileName);
                string extension = Path.GetExtension(kue.UploadFile.FileName);
                fileName = fileName + extension;
                kue.gambar = "~/Content/picCake" + fileName;
                string filePath = Path.Combine(Server.MapPath("~/Content/picCake"), fileName);
                kue.id_gambar = Guid.NewGuid().ToString() + extension;
                string newNameImage = Path.Combine(Server.MapPath("~/Content/picCake"), kue.id_gambar);
                kue.UploadFile.SaveAs(filePath);
                Directory.Move(filePath, newNameImage);

                if (ModelState.IsValid)
                {
                    if (kue.UploadFile != null)
                    {
                        kue k = new kue();
                        k.gambar = kue.UploadFile.FileName;
                        k.id_gambar = kue.id_gambar;
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
            ViewBag.pathImage = "../../Content/picCake/" + kue.id_gambar;
            if (kue == null)
                return HttpNotFound();
            return View(kue);
        }

        // POST: Kue/Edit/5
        [HttpPost]
        [Route("api/image")]
        public ActionResult EditKue(kue kue)
        {
            try
            {
                string fileName;
                string filePath;
                string extension;
                string newNameImage;
                kue kue2 = si_kue.kues.Find(kue.id);

                if (kue.UploadFile != null)
                {
                    fileName = Path.GetFileNameWithoutExtension(kue.UploadFile.FileName);
                    extension = Path.GetExtension(kue.UploadFile.FileName);
                    fileName = fileName + extension;
                    kue.gambar = fileName;
                    filePath = Path.Combine(Server.MapPath("~/Content/picCake"), fileName);

                    string filePath2 = Path.Combine(Server.MapPath("~/Content/picCake"), string.IsNullOrEmpty(kue2.id_gambar) ? "" : kue2.id_gambar);
                    if (System.IO.File.Exists(filePath2))
                    {
                        System.IO.File.Delete(filePath2);
                    }
                    kue.UploadFile.SaveAs(filePath);
                    kue.id_gambar = Guid.NewGuid().ToString() + extension;
                    newNameImage = Path.Combine(Server.MapPath("~/Content/picCake"), kue.id_gambar.ToString());
                    Directory.Move(filePath, newNameImage);
                }


                if (ModelState.IsValid)
                {

                    kue2.gambar = kue.UploadFile != null ? kue.UploadFile.FileName : kue2.gambar;
                    kue2.id_gambar = kue.UploadFile != null ? kue.id_gambar : kue2.id_gambar;
                    kue2.nama_kue = kue.nama_kue;
                    kue2.id_category = kue.id_category;
                    kue2.harga = kue.harga;
                    kue2.stok = kue.stok;
                    si_kue.Entry(kue2).State = EntityState.Modified;
                    si_kue.SaveChanges();

                    return RedirectToAction("Kue");
                }
                kue.Kategoris = si_kue.categories.ToList<category>();

                return View(kue);
            }
            catch (Exception ex)
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
