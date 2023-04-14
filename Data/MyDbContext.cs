using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SampleAPI.Models;
using System.Numerics;
using System.Text.RegularExpressions;

namespace sample_app.Data

{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TShirt> TShirts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID);
                entity.Property(e => e.UserID).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TShirt>(entity =>
            {
                entity.HasKey(e => e.TShirtID);
                entity.HasOne(e => e.Category)
                    .WithMany(c => c.TShirts)
                    .HasForeignKey(e => e.CategoryID);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CategoryID);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderID);
                entity.HasOne(e => e.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(e => e.UserID);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderDetailID);
                entity.HasOne(e => e.Order)
                    .WithMany(o => o.OrderDetails)
                    .HasForeignKey(e => e.OrderID);
                entity.HasOne(e => e.TShirt)
                    .WithMany(t => t.OrderDetails)
                    .HasForeignKey(e => e.TShirtID);
            });

        }

       
        }


    }
