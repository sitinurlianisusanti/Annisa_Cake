using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnnisaCake.Web.Helper;
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
        [UserAuditFilter]
        public ActionResult GetMenuJson(string idrole)
        {

            List<MenuTree> menu = new List<MenuTree>();
            menu = GetMenuList(null, idrole);
            return Json(menu, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMenuJsonLogin()
        {
            if (Session["role"] != null)
            {
                string role = Session["role"].ToString();
                List<MenuTree> menu = new List<MenuTree>();
                menu = GetMenuListLogin(null, role);
                return Json(menu, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<MenuTree> menu = new List<MenuTree>();
                menu = GetMenuListLogin(null, null);
                return Json(menu, JsonRequestBehavior.AllowGet);
            }

        }



        public List<MenuTree> GetMenuList(int? parent, string role)
        {
            List<MenuTree> subMenuTreeList = new List<MenuTree>();
            List<MenuTree> menuTreeList = new List<MenuTree>();
            var data = db.SP_GetMenuByRoleUser(parent, role).ToList();
            menuTreeList = mapper.Map<List<MenuTree>>(db.SP_GetMenuByRoleUser(parent, role).ToList());
            foreach (MenuTree menu in menuTreeList)
            {
                subMenuTreeList = mapper.Map<List<MenuTree>>(db.SP_GetMenuByRoleUser(menu.id, role).ToList());
                if (subMenuTreeList.Count > 0 )
                {
                    menu.sub = GetMenuList(menu.id, role);
                }
                else
                {
                    menu.sub = null;
                }
            }
            return menuTreeList;
        }

        public List<MenuTree> GetMenuListLogin(int? parent, string role)
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
                    menu.sub = GetMenuListLogin(menu.id,role);
                }
                else
                {
                    menu.sub = null;
                }
            }
            return menuTreeList.Where(x => x.role == "1").ToList();
        }
        //public List<MenuTree> GetMenuListParent(int? parent, string role)
        //{
        //    List<MenuTree> subMenuTreeList = new List<MenuTree>();
        //    List<MenuTree> menuTreeList = new List<MenuTree>();
        //    var data = db.SP_GetMenuByRoleUser(parent, role).ToList();
        //    menuTreeList = mapper.Map<List<MenuTree>>(db.SP_GetMenuByRoleUser(parent, role).ToList());
        //    foreach (MenuTree menu in menuTreeList)
        //    {
        //        subMenuTreeList = mapper.Map<List<MenuTree>>(db.SP_GetMenuByRoleUser(menu.id, role).ToList());
        //        if (subMenuTreeList.Count > 0)
        //        {
        //            menu.sub = GetMenuList(menu.id, menu.role);
        //        }
        //        else
        //        {
        //            menu.sub = null;
        //        }
        //    }
        //    return menuTreeList;
        //}
    }
}
