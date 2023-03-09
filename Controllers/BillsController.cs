using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FPTBookS.Models;

namespace FPTBookS.Controllers
{
    public class BillsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Bills
        public async Task<ActionResult> Index()
        {
            ViewBag.Category = db.Categories.ToList();
            return View(await db.Bills.Include(p => p.BillDetails.Select(o => o.Product)).ToListAsync());
        }

        // GET: Bills/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            ViewBag.Category = db.Categories.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = await db.Bills.FindAsync(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // GET: Bills/Create
        public ActionResult Create()
        {
            ViewBag.Category = db.Categories.ToList();
            return View();
        }

        // POST: Bills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection form)
        {
            ViewBag.Category = db.Categories.ToList();

            Bill bill = new Bill();

            Random rd = new Random();
            bill.BillID = rd.Next(1, 999999);
            bill.BillCustomer = form["BillCustomer"];
            bill.BillPhone = form["BillPhone"];
            bill.BillAddress = form["BillAddress"];
            bill.BillDate = DateTime.Now;
            db.Bills.Add(bill);
            Cart cart = Session["Cart"] as Cart;
            foreach (var item in cart.Items)
            {
                BillDetail bill_Detail = new BillDetail();
                bill_Detail.BillDetails = rd.Next(1, 999999);
                bill_Detail.BillID = bill.BillID;
                bill_Detail.ProductID= item._shopping_product.ProductID;
                bill_Detail.UnitPrice = (decimal)item._shopping_product.Price;
                bill_Detail.Quantity = item._shopping_quantity;
                db.BillDetails.Add(bill_Detail);
            }


            await db.SaveChangesAsync();
            return RedirectToAction("User","Home");
        }

        // GET: Bills/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.Category = db.Categories.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = await db.Bills.FindAsync(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: Bills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BillID,BillDate,BillCustomer,BillAddress,BillPhone")] Bill bill)
        {
            ViewBag.Category = db.Categories.ToList();
            if (ModelState.IsValid)
            {
                db.Entry(bill).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bill);
        }

        // GET: Bills/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            ViewBag.Category = db.Categories.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = await db.Bills.FindAsync(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ViewBag.Category = db.Categories.ToList();
            Bill bill = await db.Bills.FindAsync(id);
            db.Bills.Remove(bill);
            await db.SaveChangesAsync();
            return RedirectToAction("User","Home");
        }

        protected override void Dispose(bool disposing)
        {
            ViewBag.Category = db.Categories.ToList();
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
