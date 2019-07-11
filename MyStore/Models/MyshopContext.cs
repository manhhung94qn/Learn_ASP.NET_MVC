namespace MyStore.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class MyshopContext : DbContext
    {
        public MyshopContext()
            : base("name=MyshopContext")
        {
        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<OrderDetailModel> OrderDetails { get; set; }
        public DbSet<OrderModel> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<OrderModel>().HasMany(c => c.OrderDetailModels).WithRequired(c=>c.OrderModel);
            modelBuilder.Entity<OrderDetailModel>().HasRequired(c => c.ProductModel);
        }
    }

}