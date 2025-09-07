using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models.Order_Classes
{
    public class OrderItem
    {
        public int Id { get; set; }
        public decimal SalePrice { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;

        public override string ToString()
        {
            return $"Item: {Product.ProductName} Quantity: {Quantity}";
        }

    }
}
