﻿using AppLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.Reflection.Emit;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace AppLibrary.Data
{
    public class  MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //lokal
            object value = optionsBuilder.UseSqlServer("Data Source=HUSEYN\\MSSQLSERVER02;Initial Catalog=StepApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
           
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LikedItem> LikedItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CreditCard> CreditCarts { get; set; }
        public DbSet<PhotoProduct> PhotoProducts { get; set; }
        public DbSet<PhotoUser> PhotoUsers { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             

            modelBuilder.Entity<PhotoProduct>()
                .Property(p => p.Size)
                .HasPrecision(18, 2);  
            modelBuilder.Entity<PhotoUser>()
                .Property(p => p.Size)
                .HasPrecision(18, 2);   

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
             

            modelBuilder.Entity<Admin>().HasData(
              new Admin
              {
                  Id=1,
                  Email = "mqul21810@gmail.com",
                  FirstName = "Miri",
                  LastName = "Emirli",
                  Password = PasswordHasher.HashPassword("admin12")  
              }
            );

            modelBuilder.Entity<Product>()
                .HasMany(p => p.CartItems)
                .WithOne(cp => cp.Product);

            modelBuilder.Entity<Cart>()
                .HasMany(p => p.Items)
                .WithOne(cp => cp.Cart);

            modelBuilder.Entity<Product>()
           .HasOne(p => p.Category)
           .WithMany(c => c.Products)
           .HasForeignKey(p => p.CategoryId);
             
           
        }

    }
}
