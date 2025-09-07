using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Order_Classes;
using Models.Payments_Classes;
using Models.Customer_Classes;
using Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>, IDbContext
    {
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public AppDbContext():base()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // var config = new ConfigurationBuilder().AddJsonFile("")
            optionsBuilder.UseSqlServer("Server=Mohamed-Ibrahim\\MSSQLSERVER01;Database=SalesOrderSystem;Integrated Security=SSPI;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
