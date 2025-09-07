using Models.Order_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Models.Payments_Classes
{
    public class Transaction
    {
        public int TransactionId { get; private set; }
        public DateTime TransDate { get; private set; } = DateTime.UtcNow;
        public virtual ICollection<Payment>? Payments { get; set; } = new List<Payment>();
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Payments)
            {
                sb.Append($"Order Id: {OrderId} Payment Type: {item.GetType().Name} Amount: {item.Amount}" );
            }
            if(sb.Length > 0)
            {
            return $"[{TransactionId}] Date: {TransDate}" +
                    $"\nDetails:\n {sb}";

            }
            else
                return $"[{TransactionId}] Date: {TransDate}";

        }
    }
}

