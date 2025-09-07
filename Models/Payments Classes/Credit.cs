using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Models.Payments_Classes
{
    public class Credit : Payment
    {
        public string CardNo { get; set; } = null!;
        public DateTime ExpiredDate { get; set; }
        public CreditType Type { get; set; }
        public override void Copyfrom(Payment source)
        {
            if (source is Credit c)
            {
                CardNo = c.CardNo;
                ExpiredDate = c.ExpiredDate;
                Type = c.Type;

            }
            else throw new InvalidOperationException("Mismatched types");
        }

    }
}
