using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WatchShop.Domain.Accounts.Extensibility.Entities;
using WatchShop.Domain.Carts.Extensibility.Entities;
using WatchShop.Domain.Catalogs.Extensibility.Entities;
using WatchShop.Domain.Identities;

namespace WatchShop.Domain.Database
{
    internal class ShopDbContext : DbContext, IShopDbContext
    {
        public ShopDbContext() : base("name=ShopDbContext")
        {
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<OrderProduct> OrderProducts { get; set; }

        public IDbSet<Cart> Carts { get; set; }

        public IDbSet<Token> Tokens { get; set; }

        public IDbSet<Identity> Identities { get; set; }

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
            BuildIdentity(modelBuilder);
            BuildToken(modelBuilder);
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

            modelBuilder.Entity<Customer>()
                .HasOptional(customer => customer.Identity)
                .WithRequired(identity => identity.Customer);

            modelBuilder.Entity<Customer>()
                .HasOptional(customer => customer.Token)
                .WithRequired(token => token.Customer);
        }

        private static void BuildIdentity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Identity>()
                .Property(p => p.Password)
                .HasMaxLength(256)
                .IsRequired();

        }

        private static void BuildToken(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Token>()
                .Property(p => p.ExpiredTime)
                .IsRequired();

            modelBuilder.Entity<Token>()
                .Property(p => p.GenerationTime)
                .IsRequired();

            modelBuilder.Entity<Token>()
                .Property(p => p.Value)
                .HasMaxLength(256)
                .IsRequired();
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