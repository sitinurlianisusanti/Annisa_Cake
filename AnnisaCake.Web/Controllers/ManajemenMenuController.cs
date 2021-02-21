using AnnisaCake.Web.Helper;
using AnnisaCake.Web.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnnisaCake.Web.Controllers
{
    public class ManajemenMenuController : Controller
    {
        private SI_TKueEntities db = new SI_TKueEntities();
        private readonly IMapper mapper;
        public ManajemenMenuController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        // GET: User
        [UserAuditFilter]
        public ActionResult GetUser(int? methode)
        {
            return View(db.users.ToList());
        }

        // GET: Default
        [UserAuditFilter]
        public ActionResult Index()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult UpdateRoleMenu(int idMenu, string idRole, string state)
        {

            try
            {
                tb_menu_tree menu = db.tb_menu_tree.Find(idMenu);
                if (state == "add")
                    menu.role = string.IsNullOrEmpty(menu.role) ? "," + idRole + "," : menu.role + idRole + ",";
                else
                    menu.role = menu.role.Replace("," + idRole + ",", ",");
                db.Entry(menu).State= EntityState.Modified;
                db.SaveChanges();

                return Json(new { message = "success" });
            }
            catch(Exception ex)
            {
                return Json(new { message = "error" });
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Default/Edit/5
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

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
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
