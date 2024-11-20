using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketplaceService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceService.Infrastructure.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {

        }
         public DbSet<Commande> commandes { get; set; }
         public DbSet<Cart> carts { get; set; }
         public DbSet<Customer> customers { get; set; }
         public DbSet<Category> categories { get; set; }
         public DbSet<Product> products { get; set; }
         public DbSet<CommandeProduct> commandeProducts { get; set; }
         public DbSet<CartProduct> cartProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CommandeProduct>(x => x.HasKey(p => new { p.CommandeId, p.ProductId }));
            builder.Entity<CommandeProduct>()
            .HasOne(u => u.Commande)
            .WithMany(u => u.CommandeProducts)
            .HasForeignKey(p => p.CommandeId);
            builder.Entity<CommandeProduct>()
            .HasOne(u => u.Product)
            .WithMany(u => u.CommandeProducts)
            .HasForeignKey(p => p.ProductId);
            //***************************************************************************
            builder.Entity<CartProduct>(x => x.HasKey(p => new { p.CartId, p.ProductId }));
            builder.Entity<CartProduct>()
            .HasOne(u => u.Cart)
            .WithMany(u => u.CartProducts)
            .HasForeignKey(p => p.CartId);
            builder.Entity<CartProduct>()
            .HasOne(u => u.Product)
            .WithMany(u => u.CartProducts)
            .HasForeignKey(p => p.ProductId);
        }


    }
}