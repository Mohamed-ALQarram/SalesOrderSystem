using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Order_Classes
{
    public class StockItem
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Stock Stock { get; set; } = null!;
        public Product Product { get; set; } = null!;

        public override string ToString()
        {
            return $"{ProductId,-25} {Product.ProductName,-30} {Product.Type,-20} {Quantity,-5}"
;
        }

    }
}
