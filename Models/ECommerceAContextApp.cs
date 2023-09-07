using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ITIProject.Models
{
    public class ECommerceAContextApp : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2SR000U\\SQLEXPRESS01;Database=ITIProject;Trusted_Connection=True;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Cart)
                .WithOne(c => c.Customer)
                .HasForeignKey<Customer>(c => c.CartId);


            //modelBuilder.Entity<Cart>()
            //    .HasMany(c => c.Orders)
            //    .WithMany(p => p.Carts)
            //    .UsingEntity<CartOrder>
            //    (
            //        co => co
            //                .HasOne(ci => ci.Order)
            //                .WithMany(p => p.CartOrders)
            //                .HasForeignKey(ci => ci.OrderId),
            //        co => co
            //                .HasOne(co => co.Cart)
            //                .WithMany(c => c.CartOrders)
            //                .HasForeignKey(co => co.CartId),
            //        ci => ci
            //                .HasKey(co => new { co.OrderId, co.CartId })
            //    );

            //modelBuilder.Entity<Cart>()
            //    .HasMany(c => c.ProductOrders)
            //    .WithOne(p => p.Cart)
            //    .HasForeignKey(p => p.CartId);

            modelBuilder.Entity<Order>().
                HasMany(o => o.Products)
                .WithMany(p => p.Orsders)
                .UsingEntity<ProductOrder>
                (
                    oi => oi
                            .HasOne(oi => oi.Product)
                            .WithMany(p => p.ProductOrders)
                            .HasForeignKey(oi => oi.ProductId),
                    oi => oi
                            .HasOne(oi => oi.Order)
                            .WithMany(o => o.ProductOrders)
                            .HasForeignKey(oi => oi.OrderId)
                    //oi => oi
                    //        .HasKey(oi => new { oi.OrderId, oi.ProductId })
                );

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Adminestrator> Adminestrator { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

    }

}
