using ClothingStoreWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreWeb.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Size>().ToTable("Sizes");
            builder.Entity<Stock>().ToTable("Stocks");
            builder.Entity<Order>().ToTable("Orders");
            builder.Entity<OrderItem>().ToTable("OrderItems");
            builder.Entity<Employee>().ToTable("Employees");

            builder.Entity<Order>()
                .Property(o => o.Order_TotalAmount)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Order>()
                .Property(o => o.Order_DeliveryAmount)
                .HasColumnType("decimal(18,2)");

            builder.Entity<OrderItem>()
                .Property(oi => oi.OrderItem_Price)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Product>()
                .Property(p => p.Product_Price)
                .HasColumnType("decimal(18,2)");
            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.Category_Id);

            builder.Entity<Stock>()
                .HasOne(s => s.Product)
                .WithMany(p => p.Stocks)
                .HasForeignKey(s => s.Product_Id);

            builder.Entity<Stock>()
                .HasOne(s => s.Size)
                .WithMany(sz => sz.Stocks)
                .HasForeignKey(s => s.Size_Id);

            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.User_Id);

            builder.Entity<Employee>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.User_Id);

            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.Order_Id);

            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.Product_Id);

            builder.Entity<OrderItem>()
                .HasOne(oi => oi.Size)
                .WithMany(sz => sz.OrderItems)
                .HasForeignKey(oi => oi.Size_Id);

            builder.Entity<Stock>()
                .HasIndex(s => new { s.Product_Id, s.Size_Id })
                .IsUnique();

            builder.Entity<Employee>()
                .HasIndex(e => e.User_Id)
                .IsUnique();
        }
    }
}