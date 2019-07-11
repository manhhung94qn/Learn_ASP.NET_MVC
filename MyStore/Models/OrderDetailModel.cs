using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyStore.Models
{
    public class OrderDetailModel
    {
        [Key]
        public int ID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ProductID")]
        public virtual ProductModel ProductModel { get; set; }
        [ForeignKey("OrderID")]
        public virtual OrderModel OrderModel { get; set; }
    }
}