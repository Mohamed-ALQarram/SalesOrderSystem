using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Payments_Classes
{
    public abstract class Payment
    {
        public int PaymentId { get; set; }
        public DateTime PaiedDate { get; set; }= DateTime.UtcNow;
        public decimal Amount {  get; set; }

        public abstract void Copyfrom(Payment source);
        public override string ToString()
        {
            return $"[{PaymentId}] Date: {PaiedDate} Amount: {Amount}";
        }

    }
}
