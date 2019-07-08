using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BaiTapCODEFIRST.DAL;
using BaiTapCODEFIRST.Models;
using BaiTapCODEFIRST.ViewModels;

namespace BaiTapCODEFIRST.repository
{
    public class OrderItemRepository : IOrderItem
    {

        private DataContext db = new DataContext();
        public void CreateOrderItem(OrderItem oderItem)
        {
            db.OrderItems.Add(oderItem);
            db.SaveChanges();
        }

        public void DeleteOrderItem(int OrderItemId)
        {
            throw new NotImplementedException();
        }

        public OrderItemVM GetOrderItemDetail(int oderItemId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderItem> GetOrderItems()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateOrderItem(OrderItem Employee)
        {
            throw new NotImplementedException();
        }
    }
}