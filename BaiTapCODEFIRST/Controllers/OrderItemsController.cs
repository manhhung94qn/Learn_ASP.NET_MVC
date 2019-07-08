using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTapCODEFIRST.DAL;
using BaiTapCODEFIRST.FluentValidator;
using BaiTapCODEFIRST.Models;
using BaiTapCODEFIRST.repository;
using BaiTapCODEFIRST.ViewModels;
using FluentValidation.Results;

namespace BaiTapCODEFIRST.Controllers
{
    public class OrderItemsController : Controller
    {
        private DataContext db = new DataContext();

        private IOrderItem odit;
        public OrderItemsController()
        {
            this.odit = new OrderItemRepository();
        }

        // GET: OrderItems
        public ActionResult Index()
        {
            return View(db.OrderItems.ToList());
        }

        // GET: OrderItems/Details/5
        public ActionResult Details(int? id)
        {
            List< OrderItemVM> orderItemDetailList = new List<OrderItemVM>();
            var orderItemDetail = (from item in db.OrderItems
                              join product in db.Products
                              on item.Product_ID equals product.ID
                              join order in db.Orders
                              on item.Oder_ID equals order.ID
                              where item.ID == id
                              select new {
                                        product.Name, 
                                        product.Price, 
                                        item.Quantity, 
                                        order.CustomerName, 
                                        order.CustomerPhone, 
                                        order.CustomerEmail
                                }).ToList();
            foreach (var item in orderItemDetail)
            {
                OrderItemVM obj = new OrderItemVM();
                obj.Name = item.Name;
                obj.Price = item.Price;
                obj.Quantity = item.Quantity;
                obj.CustomerName = item.CustomerName;
                obj.CustomerPhone = item.CustomerPhone;
                obj.CustomerEmail = item.CustomerEmail;
                orderItemDetailList.Add(obj);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItemDetailList[0]);
        }

        // GET: OrderItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Oder_ID,Product_ID,Quantity")] OrderItem orderItem)
        {
            OrderItemValidator orderItemValidator = new OrderItemValidator();

            ValidationResult result = orderItemValidator.Validate(orderItem);

            if (result.IsValid)
            {
                this.odit.CreateOrderItem(orderItem);
                return RedirectToAction("Index");
            } else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }

            return View(orderItem);
        }

        // GET: OrderItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // POST: OrderItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Oder_ID,Product_ID,Quantity")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderItem);
        }

        // GET: OrderItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // POST: OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderItem orderItem = db.OrderItems.Find(id);
            db.OrderItems.Remove(orderItem);
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
