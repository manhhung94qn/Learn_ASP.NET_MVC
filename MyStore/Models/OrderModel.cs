using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyStore.Models
{
    public class OrderModel
    {
        public int ID { get; set; }
        public string CodeOrder { get; set; }
        public DateTime DateOrder { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerAddress { get; set; }
        public virtual ICollection<OrderDetailModel> OrderDetailModels { get; set; }
    }
}