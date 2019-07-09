using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyStore.Models;

namespace MyStore.Repository
{
    public class ProductRepository : IProduct
    {
        private MyshopContext db;
        public ProductRepository (MyshopContext shopData)
        {
            this.db = shopData;
        }

        public IEnumerable<ProductModel> getAllProduct()
        {
            return db.Products.ToList();
        }

        public ProductModel getProductById(int? productId)
        {
            ProductModel product = db.Products.Find(productId);
            return product;
        }

        public void deleteProduct(int productId)
        {
            ProductModel product = db.Products.Find(productId);
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public void insertProduct(ProductModel product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void updateProduct(ProductModel product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}