using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyStore.Repository
{
    public interface IProduct
    {
        IEnumerable<ProductModel> getAllProduct();
        ProductModel getProductById(int? productId);
        void insertProduct(ProductModel product);
        void updateProduct(ProductModel product);
        void deleteProduct(int productId);
        void Save();
    }
}