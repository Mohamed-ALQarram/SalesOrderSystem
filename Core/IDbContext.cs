using Microsoft.EntityFrameworkCore;
using Models.Customer_Classes;
using Models.Order_Classes;
using Models.Payments_Classes;

namespace Core
{
    public interface IDbContext
    {
        // ... existing DbSet properties ...

        public DbSet<T> Set<T>() where T : class;
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Payment> Payments { get; set; }
        int SaveChanges();
    }
}
