using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FPTBookS.Models;

namespace FPTBookS.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult Index(int? id)
        {
            ViewBag.Category = db.Categories.ToList();

            if (id == null)
            {
                return View(db.Products.ToList());
            }else
            {
                return View(db.Products.Where(p => p.CategoryID == id).ToList());
            }
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            ViewBag.Category = db.Categories.ToList();
            string searchtext = form["search"];
            return View(db.Products.Where(p => p.ProductName.Contains(searchtext)).ToList());
        }

        public ActionResult Admin(int? id)
        {
            ViewBag.Category = db.Categories.ToList();

            if (id == null)
            {
                return View(db.Products.ToList());
            }
            else
            {
                return View(db.Products.Where(p => p.CategoryID == id).ToList());
            }
        }

        [HttpPost]
        public ActionResult Admin(FormCollection form)
        {
            ViewBag.Category = db.Categories.ToList();
            string searchtext = form["search"];
            return View(db.Products.Where(p => p.ProductName.Contains(searchtext)).ToList());
        }

        public ActionResult User(int? id)
        {
            ViewBag.Category = db.Categories.ToList();

            if (id == null)
            {
                return View(db.Products.ToList());
            }
            else
            {
                return View(db.Products.Where(p => p.CategoryID == id).ToList());
            }
        }

        [HttpPost]
        public ActionResult User(FormCollection form)
        {
            ViewBag.Category = db.Categories.ToList();
            string searchtext = form["search"];
            return View(db.Products.Where(p => p.ProductName.Contains(searchtext)).ToList());
        }

        public ActionResult Details(int id)
        {
            ViewBag.Category = db.Categories.ToList();
            return View(db.Products.Where(s => s.ProductID == id).FirstOrDefault());
        }

        public ActionResult Category()
        {
            ViewBag.Category = db.Categories.ToList();
            return View(db.Categories.ToList());
        }

    }
}