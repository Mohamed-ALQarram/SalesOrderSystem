using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Customer_Classes
{
    public class Person : Customer
    {
        [Display(Name = "Billing Address")]

        public string BillingAddress { get; set; } = null!;
        [Display(Name="Full Name")]
        public string? FullName { get; set; }

        public override void CopyFrom(Customer source)
        {
            if (source is Person p)
            {
                BillingAddress = p.BillingAddress;
                FullName = p.FullName;
            }
            else throw new InvalidOperationException("Mismatched types");
        }

        public override string ToString() => $" [{CustomerId}] Full Name: {FullName} PhoneNo: {phone} Billing Address: {BillingAddress}";

        
    }
}
