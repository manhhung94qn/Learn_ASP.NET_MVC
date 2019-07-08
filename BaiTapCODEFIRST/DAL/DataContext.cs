using BaiTapCODEFIRST.Models;
using System;

using System.Collections.Generic;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

using System.Web;

namespace BaiTapCODEFIRST.DAL
{
    public class DataContext: DbContext
    {
        public DataContext(): base("DataContext")
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}