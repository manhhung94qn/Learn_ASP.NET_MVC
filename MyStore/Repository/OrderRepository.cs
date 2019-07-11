using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyStore.Models;
using MyStore.ModelView;

namespace MyStore.Repository
{
    public class OrderRepository : IOrder
    {
        private MyshopContext db;
        public OrderRepository(MyshopContext shopData)
        {
            this.db = shopData;
        }
        public OrderModel getOrderByID(int? ID)
        {
            if(ID == null)
            {
                return null;
            }
            OrderModel order = db.Orders.Find(ID);
            return order;
        }

        public OrderModel addOrder(OrderModel order)
        {
            DateTime timeNow = DateTime.Now;
            order.DateOrder = timeNow;
            order.CodeOrder = "MYSHOP" + Convert.ToString(timeNow.Year) + 
                Convert.ToString(timeNow.Date) + Convert.ToString(timeNow.Hour) + 
                Convert.ToString(timeNow.Minute) + Convert.ToString(timeNow.Second);

            db.Orders.Add(order);

            db.SaveChanges();
            return order;
        }
    }
}