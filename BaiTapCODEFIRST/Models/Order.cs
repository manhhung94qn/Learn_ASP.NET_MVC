using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTapCODEFIRST.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}