using FPTBookS.Models;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FPTBookS.Controllers
{
    public class ProductsController : Controller
    {
        private Model1 db = new Model1();
        private readonly IHostingEnvironment _hostingEnv;

        
        // GET: Publishers
        public ActionResult Index()
        {
            var product = db.Products.Include(b => b.Category).Include(b => b.Author).Include(b => b.Publisher);
            return View(product);
        }


        // GET: Publishers/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.PublishID = new SelectList(db.Publishers, "PublishID", "PublishName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.myfile.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(product.myfile.FileName);
                    product.Imagas = _FileName;
                    string _path = Path.Combine(Server.MapPath("~/Contents/images"), _FileName);
                    product.myfile.SaveAs(_path);
                }
                
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Publishers/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "AuthorName");
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.PublisherID = new SelectList(db.Publishers, "PublisherID", "PublisherName");
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.myfile.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(product.myfile.FileName);
                    product.Imagas = _FileName;
                    string _path = Path.Combine(Server.MapPath("~/Contents/images"), _FileName);
                    product.myfile.SaveAs(_path);
                }
                
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Publishers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
