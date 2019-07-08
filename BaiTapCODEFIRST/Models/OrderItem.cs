using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BaiTapCODEFIRST.Models
{
    public class OrderItem
    {
        [Key]
        public int ID { get; set; }
        public int Oder_ID { get; set; }
        public int Product_ID { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}