using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTapCODEFIRST.ViewModels
{
    public class OrderItemVM
    {
        public string Name { get; set; }  //product
        public decimal Price { get; set; }  //product
        public int Quantity { get; set; }    //order Item
        public string CustomerName { get; set; } //order
        public string CustomerPhone { get; set; }   //order
        public string CustomerEmail { get; set; }   //order
    }
}