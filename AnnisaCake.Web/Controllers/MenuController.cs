using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnnisaCake.Web.Models;
using AutoMapper;

namespace AnnisaCake.Web.Controllers
{
    public class MenuController : Controller
    {
        private SI_TKueEntities db = new SI_TKueEntities();
        private readonly IMapper mapper;
        public MenuController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        // GET: Menu
        public ActionResult GetMenuJson()
        {
            List<MenuTree> menu = new List<MenuTree>();
            menu = GetMenuList(null, null);
            return Json(menu, JsonRequestBehavior.AllowGet);
        }

        public List<MenuTree> GetMenuList(int? parent,string role)
        {
            List<MenuTree> subMenuTreeList = new List<MenuTree>();
            List<MenuTree> menuTreeList = new List<MenuTree>();
            var data = db.SP_GetMenuByRoleUser(parent, role).ToList();
            menuTreeList = mapper.Map<List<MenuTree>>(db.SP_GetMenuByRoleUser(parent, role).ToList());
            foreach (MenuTree menu in menuTreeList)
            {
                subMenuTreeList = mapper.Map<List<MenuTree>>(db.SP_GetMenuByRoleUser(menu.id, role).ToList());
                if (subMenuTreeList.Count > 0)
                {
                    menu.sub = GetMenuList(menu.id,menu.role);
                }
                else
                {
                    menu.sub = null;
                }
            }
            return menuTreeList;
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
           // db.tb_menu_tree
            return View();
        }

        // POST: Menu/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Menu/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Menu/Edit/5
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

        // GET: Menu/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Menu/Delete/5
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
