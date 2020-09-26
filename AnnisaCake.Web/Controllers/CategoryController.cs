using AnnisaCake.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AnnisaCake.Web.Controllers
{
    public class CategoryController : Controller
    {
        public SI_TKueEntities si_kue = new SI_TKueEntities();
        // GET: Category
        public ActionResult Category()
        {
            List<category> data = si_kue.Database.SqlQuery<category>("exec GetCategory").ToList();
            return View(data);
        }

        // GET: Category/Details/5
        public ActionResult DetailsCategory(int? id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            category category = si_kue.categories.Find(id);

            if (category == null)
                return HttpNotFound();
            return View(category);
        }

        // GET: Category/Create
        public ActionResult CreateCategory()
        {
            return View();
        }


        // POST: Category/Create
        [HttpPost]
        public ActionResult CreateCategory(category category)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    si_kue.categories.Add(category);
                    si_kue.SaveChanges();
                    return RedirectToAction("Category");
                }
                return View(category);
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult EditCategory(int? id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            category category = si_kue.categories.Find(id);

            if (category == null)
                return HttpNotFound();
            return View(category);
        }
        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult EditCategory(category category)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    si_kue.Entry(category).State = EntityState.Modified;
                    si_kue.SaveChanges();

                    return RedirectToAction("Category");
                }
                return View(category);
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult DeleteCategory(int? id)
        {
            if (id == null)

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            category category = si_kue.categories.Find(id);

            if (category == null)
                return HttpNotFound();
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult DeleteCategory(int? id, category category)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    if (id == null)

                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    category = si_kue.categories.Find(id);
                    if (category == null)
                        return HttpNotFound();
                    si_kue.categories.Remove(category);
                    si_kue.SaveChanges();
                    return RedirectToAction("Category");

                }
                return View(category);
            }
            catch
            {
                return View();
            }
        }
    }
}
