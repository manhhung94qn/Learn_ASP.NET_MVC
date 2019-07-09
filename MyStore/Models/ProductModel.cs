using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyStore.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string AvatarUrl { get; set; }
        public decimal Price { get; set; }

    }
}