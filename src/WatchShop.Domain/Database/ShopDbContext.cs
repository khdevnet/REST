using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using WatchShop.Domain.Catalog;
using WatchShop.Domain.Customers;
using WatchShop.Domain.Orders;

namespace WatchShop.Domain.Database
{
    internal class ShopDbContext : DbContext
    {
        public ShopDbContext() : base("name=ShopDbContext")
        {
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<OrderProduct> OrderProducts { get; set; }

        public IDbSet<Cart> Carts { get; set; }

        public IDbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();

            BuildCustomer(modelBuilder);
            BuildCart(modelBuilder);
            BuildProduct(modelBuilder);
            BuildOrder(modelBuilder);
            BuildOrderProduct(modelBuilder);
        }

        #region
        private static void BuildCustomer(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
              .Property(x => x.Name)
              .HasMaxLength(256)
              .IsRequired();

            modelBuilder.Entity<Customer>()
              .Property(x => x.Address)
              .HasMaxLength(256)
              .IsRequired();

            modelBuilder.Entity<Customer>()
              .Property(x => x.Email)
              .HasMaxLength(256)
              .IsRequired();

            modelBuilder.Entity<Customer>()
             .Property(x => x.Phone)
             .HasMaxLength(256)
             .IsRequired();

            modelBuilder.Entity<Customer>()
                .HasOptional(customer => customer.Cart)
                .WithRequired(cart => cart.Customer);
        }

        private static void BuildCart(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .Property(p => p.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Cart>()
                .HasMany(p => p.Items)
                .WithRequired(p => p.Cart)
                .HasForeignKey(p => p.CartId);

    //        modelBuilder
    //            .Entity<Cart>()
    //.Property(t => t.)
    //.HasColumnAnnotation(
    //    "Index",
    //    new IndexAnnotation(new[]
    //        {
    //            new IndexAttribute("Index1"),
    //            new IndexAttribute("Index2") { IsUnique = true }
    //        })));
        }

        private static void BuildProduct(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
              .Property(x => x.Name)
              .HasMaxLength(256)
              .IsRequired();

            modelBuilder.Entity<Product>()
             .Property(x => x.Price)
             .HasPrecision(9, 2)
             .IsRequired();
        }

        private static void BuildOrder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
             .Property(x => x.Total)
             .HasPrecision(9, 2)
             .IsRequired();
        }

        private static void BuildOrderProduct(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
             .Property(x => x.Price)
             .HasPrecision(9, 2)
             .IsRequired();

            modelBuilder.Entity<OrderProduct>()
             .Property(x => x.Name)
             .HasMaxLength(256)
             .IsRequired();
        }
        #endregion
    }
}