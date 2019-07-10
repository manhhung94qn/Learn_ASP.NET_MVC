using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyStore.Models;

namespace MyStore.Controllers
{
    public class OrderDetailController : Controller
    {
        private MyshopContext db = new MyshopContext();

        // GET: OrderDetail
        public ActionResult Index()
        {
            return View(db.OrderDetails.ToList());
        }

        // GET: OrderDetail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetailModel orderDetailModel = db.OrderDetails.Find(id);

            

            if (orderDetailModel == null)
            {
                return HttpNotFound();
            }
            return View(orderDetailModel);
        }

        // GET: OrderDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetail/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create([Bind(Include = "OrderID,ProductID,Quantity")] OrderDetailModel orderDetailModel)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetails.Add(orderDetailModel);
                db.SaveChanges();
                return Json(new { status = true });
                //return RedirectToAction("Index");
            }
            return Json(new { status= false});
            //return View(orderDetailModel);
        }

        // GET: OrderDetail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetailModel orderDetailModel = db.OrderDetails.Find(id);
            if (orderDetailModel == null)
            {
                return HttpNotFound();
            }
            return View(orderDetailModel);
        }

        // POST: OrderDetail/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OrderID,ProductID,Quantity")] OrderDetailModel orderDetailModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetailModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderDetailModel);
        }

        // GET: OrderDetail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetailModel orderDetailModel = db.OrderDetails.Find(id);
            if (orderDetailModel == null)
            {
                return HttpNotFound();
            }
            return View(orderDetailModel);
        }

        // POST: OrderDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetailModel orderDetailModel = db.OrderDetails.Find(id);
            db.OrderDetails.Remove(orderDetailModel);
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
