using Models.Customer_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Payments_Classes
{
    public class Cash : Payment
    {
        public string? CasherName { get; set; }
        public decimal CashValue { get; set; }
        public decimal Change { get; set; } = 0;
        public override void Copyfrom(Payment source)
        {
            if (source is Cash c)
            {
                CasherName = c.CasherName;
                CashValue = c.CashValue;
            }
            else throw new InvalidOperationException("Mismatched types");
        }
    }
}
