using SecurityMVC5.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
    
    public partial class EShopV20DbContext : DbContext
    {
        public EShopV20DbContext() : base("name=EShopV20") { }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
    }