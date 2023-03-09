using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FPTBookS.Models;

namespace FPTBookS.Controllers
{
    public class OrdersController : Controller
    {
        private Model1 db = new Model1();

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            Order or = new Order();
            or.Descriptions = form["Adress_Delivery"];
            or.Orderdate = DateTime.Now;
            Random rd = new Random();
            or.OrderID = rd.Next(1,999999);
            Cart cart = Session["Cart"] as Cart;
            db.Orders.Add(or);
            //foreach (var item in cart.Items)
            //{
            //    OrderDetail _order_Detail = new OrderDetail();
            //    _order_Detail.OrderID = or.OrderID;
            //    _order_Detail.ProductID = item._shopping_product.ProductID;
            //    _order_Detail.UnitPriceSale = item._shopping_product.Price;
            //    _order_Detail.QuantitySale = item._shopping_quantity;
            //    db.OrderDetails.Add(_order_Detail);
            //}
            db.SaveChanges();
            return View();
        }

    }
}
