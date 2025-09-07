using Models.Customer_Classes;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Models.Order_Classes
{
    public class Stock
    {
        public int StockId { get; set; }
        public int count { get; set; }
        public virtual ICollection<StockItem> StockItems { get; set; } = new List<StockItem>();

        public override string ToString()
        {
            StringBuilder str = new();
            foreach (var item in StockItems)
                str.Append(item.ToString()+"\n");
            if (str.Length > 0)
                return $"StockId: {StockId,-10}\n " +
                                $"{"ProductId",-20} {"ProductName",-40} {"Type",-30} {"Quantity",-5}\n" +
                    $"{str}";
            else return $"[{StockId}] Count: {count}\n ";
;
        }
    }
}
