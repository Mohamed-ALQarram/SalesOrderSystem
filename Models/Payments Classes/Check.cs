using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Payments_Classes
{
    public class Check : Payment
    {

        public string BankName { get; set; } = null!;
        public string BankID { get; set; } = null!;
        public override void Copyfrom(Payment source)
        {
            if (source is Check c)
            {
                BankName = c.BankName;
                BankID = c.BankID;
            }
            else throw new InvalidOperationException("Mismatched types");
        }

    }
}
