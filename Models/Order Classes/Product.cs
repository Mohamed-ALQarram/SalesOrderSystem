using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums; 
namespace Models.Order_Classes
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public ProductType? Type { get; set; } 

        public virtual ICollection<StockItem>? StockItems { get; set; } = new List<StockItem>();

        public virtual ICollection<OrderItem>? OrderItems { get; set; } = new List<OrderItem>();
    }
}
