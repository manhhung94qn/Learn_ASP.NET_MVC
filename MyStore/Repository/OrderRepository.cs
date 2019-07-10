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
        public List<OrderInforVM> getOrderDetail(int? ID)
        {
            OrderModel orderModel = db.Orders.Find(ID);
            List< OrderDetailModel> OrderDetail = orderModel.OrderDetailModels.Select(o => o.ID == ID);
            return OrderDetail;
        }
    }
}