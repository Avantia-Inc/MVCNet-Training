using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTraining.Web.Areas.Admin.Models;
using MvcTraining.Web.Models;

namespace MvcTraining.Web.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private MvcTrainingContext db = new MvcTrainingContext();

        //
        // GET: /Admin/Product/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet, ChildActionOnly]
        public ActionResult List()
        {
            return PartialView(db.Products.ToList());
        }

        //
        // GET: /Admin/Product/Create

        [HttpGet]
        public ActionResult Create()
        {
			return PartialView();
        }

        //
        // POST: /Admin/Product/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/Product/Edit/5

        [HttpGet]
        public PartialViewResult Edit(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }
            return PartialView(product);
        }

        //
        // POST: /Admin/Product/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Admin/Product/Delete/5

        [HttpPost]
        public void Delete(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}