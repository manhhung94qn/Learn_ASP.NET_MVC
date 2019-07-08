using BaiTapCODEFIRST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTapCODEFIRST.DAL
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext db)
        {
            var products = new List<Product>
            {
                new Product{Name="Đường trắng",Price=10000},
                new Product {Name= "Bột ngọt", Price= 12000},
                new Product {Name= "Muối", Price= 5000}
            };
            products.ForEach(prod => db.Products.Add(prod));
            db.SaveChanges();

            var orders = new List<Order>
            {
                new Order { CustomerName = "Mạnh Khả", CustomerPhone = "0344895969", CustomerEmail = "manhhung94qn@gmail.com"},

                new Order { CustomerName = "Nguyên Khang", CustomerPhone = "0344898989", CustomerEmail = "nguyenkhangqn@gmail.com"},
            };

            orders.ForEach(or => db.Orders.Add(or));
            db.SaveChanges();

            var orderItems = new List<OrderItem>
            {
                new OrderItem {Oder_ID = 1, Product_ID = 1, Quantity = 2},
                new OrderItem {Oder_ID = 1, Product_ID = 2, Quantity = 1},
                new OrderItem {Oder_ID = 2, Product_ID = 3, Quantity = 1}
            };

            orderItems.ForEach(item => db.OrderItems.Add(item));
            db.SaveChanges();
        }
    }
}