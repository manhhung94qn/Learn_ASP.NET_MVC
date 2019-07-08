using BaiTapCODEFIRST.Models;
using BaiTapCODEFIRST.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTapCODEFIRST.repository
{
    public interface IOrderItem
    {
        void CreateOrderItem(OrderItem oderItem); // C

        IEnumerable<OrderItem> GetOrderItems(); // R

        OrderItemVM GetOrderItemDetail(int oderItemId); // R

        void UpdateOrderItem(OrderItem Employee); //U

        void DeleteOrderItem(int OrderItemId); //D

        void Save();
    }
}