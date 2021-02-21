using AnnisaCake.Web.Helper;
using AnnisaCake.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AnnisaCake.Web.Controllers
{
    public class PesananController : Controller
    {
        private SI_TKueEntities db = new SI_TKueEntities();
        // GET: Pesanan
        [UserAuditFilter]
        public ActionResult Index()
        {
            ViewBag.DataStatus = db.status_pesanan.
                Select(x=>new {
                id_status=x.id_status,
                status=x.status
                }).
                ToList();
            return View();
        }

        public ActionResult GetPesanan()
        {
            var data = db.get_pesanan().ToList();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        // GET: Pesanan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Pesanan/Create
        [HttpPost]
        public ActionResult EditStatus(int idPesanan, int idStatus)
        {
            try
            {
                var pesanan = db.pesanans.Find(idPesanan);
                pesanan.id_status = idStatus;

                db.Entry(pesanan).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { message = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { message = "filed" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult CancleEdit(int idPesanan)
        {
            string idStatus = db.pesanans.Find(idPesanan).id_status.ToString(); ;
            return Json(new {idStatus },JsonRequestBehavior.AllowGet);
        }

        // GET: Pesanan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Pesanan/Edit/5
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

        // GET: Pesanan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pesanan/Delete/5
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
