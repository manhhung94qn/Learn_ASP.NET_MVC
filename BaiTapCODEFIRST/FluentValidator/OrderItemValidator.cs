using BaiTapCODEFIRST.DAL;
using BaiTapCODEFIRST.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTapCODEFIRST.FluentValidator
{
    public class OrderItemValidator: AbstractValidator<OrderItem>
    {
        DataContext db = new DataContext();
        public OrderItemValidator()
        {
            RuleFor(x => x.Oder_ID).Must( CheckExitsInOrder ).WithMessage("Order không tồn tại, vui lòng kiểm tra lại");

            RuleFor(x => x.Product_ID).Must(checkExitsInProduct).WithMessage("Sản phẩm bạn yêu cầu không tồn tại.");

            RuleFor(x => x.Quantity).InclusiveBetween(0, 5000).WithMessage("Vui lòng chọn số lượng sản phẩm");

        }

        public Boolean CheckExitsInOrder(int id)
        {
            var Order = db.Orders.Find(id);
            
            if ( Order != null )
            {
                return true;
            }
            return false;
        }

        public Boolean checkExitsInProduct(int id)
        {
            var product = db.Products.Find(id);
            if ( product !=null )
            {
                return true;
            }
            return false;
        }

    }
}