using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnnisaCake.Web.Models;
using AutoMapper;
using AnnisaCake.Web.Helper;
using System.Net.Http;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace AnnisaCake.Web.Controllers
{
    public class PelangganController : Controller
    {
        private readonly IMapper mapper;
        public PelangganController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public SI_TKueEntities db = new SI_TKueEntities();
        // GET: Pelanggan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            try
            {
                string emailHp = collection["email_hp"].ToString();
                string pass = collection["password"].ToString();
                var pelanggan = db.pelanggans.Where(x => (x.no_hp == emailHp || x.email==emailHp) && x.sandi == pass).FirstOrDefault();

                if (pelanggan != null)
                {
                    Session["pelanggan"] = pelanggan.nama_pelanggan;
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Pelanggan/Details/5
        public ActionResult Regis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Regis(ViewModel.pelanggan pelParam)
        {
            try
            {
                bool erro = false;
                if (pelParam.sandi != pelParam.sandi_confirm)
                {
                    erro = true;
                }
                var pelCek = db.pelanggans.Where(x => x.no_hp == pelParam.no_hp).FirstOrDefault();
                if (pelCek != null)
                {
                    erro = true;
                }

                if (!erro)
                {
                    //make new id
                    Guid newId = Guid.NewGuid();
                    //make new kode komfirmasi
                    string kodeKonfirmasi = Utils.KodeKonfirmasi();

                    //mapping and add to database for new pelanggan 
                    //var pel = mapper.Map<ViewModel.pelanggan, pelanggan_tamp>(pelParam);
                    pelanggan_tamp pel= mapper.Map<pelanggan_tamp>(pelParam);
                    pel.id_pelanggan = newId;
                    pel.kode_konfirmasi = kodeKonfirmasi;
                    db.Entry(pel).State = EntityState.Added;
                    db.SaveChanges();



                    //using (var client = new HttpClient())
                    //{
                    //    //client.BaseAddress = new Uri("https://api.callmebot.com/");
                    //    client.BaseAddress = new Uri("https://reguler.zenziva.net/");
                    //    //http post
                    //    string text = "Jangan berikan kode Kepada siapapun \n Kode Konfirmasi anda " + kodeKonfirmasi + "\n";

                    //    //var responsTask = client.GetAsync("whatsapp.php?phone=" + pel.no_hp + "&text=" + text + "&apikey=700180");
                    //    var responsTask = client.GetAsync("apps/smsapi.php?nohp=" + pel.no_hp + "&pesan=" + text + "&userkey=azishapidin.com&passkey=4215");
                    //    responsTask.Wait();

                    //    var result = responsTask.Result;
                    //    if (result.IsSuccessStatusCode)
                    //    {
                    //        //go to confirm view
                    //        return RedirectToAction("Confim", new { idPelanggan = newId });
                    //    }

                    //}

                    Utils.SendEmail(pelParam.email,"Kode Konfrimasi",kodeKonfirmasi);

                    return RedirectToAction("Confim", new { idPelanggan = newId });

                }
                // TODO: Add insert logic here

                return View();
            }
            catch(DbEntityValidationException x)
            {
                return View();
            }
        }
        public ActionResult Confim(string idPelanggan)
        {
            ViewBag.idPelanggan = idPelanggan;
            return View();
        }

        [HttpPost]
        public ActionResult Confim(FormCollection collection)
        {
            try
            {
                string kodeKonfirmasi = collection["kode_konfirmasi"].ToString();
                Guid idPelanggan = Guid.Parse(collection["id_pelanggan"].ToString());
                var pelangganTamp = db.pelanggan_tamp.Find(idPelanggan);
                if (pelangganTamp.kode_konfirmasi == kodeKonfirmasi)
                {
                    db.fil_pelanggan_from_tamp(idPelanggan);
                    db.SaveChanges();
                }

                return RedirectToAction("Login");
            }
            catch(DbEntityValidationException x)
            {
                return View();
            }
        }

        // POST: Pelanggan/Edit/5
        
        // GET: Pelanggan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pelanggan/Delete/5
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
