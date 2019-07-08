using BaiTapCODEFIRST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTapCODEFIRST.repository
{
    public interface IOrder
    {
        void InsertOrder(Order order); // C

        IEnumerable<Order> GetOrder(); // R

        Order GetOrderByID(int OrderId); // R

        void UpdateEmployee(Order order); //U

        void DeleteOrder(int OrderId); //D

        void Save();
    }
}