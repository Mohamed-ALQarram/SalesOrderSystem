using Models.Order_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Customer_Classes
{
    public abstract class Customer
    {
        [Display(Name = "Customer Id")]

        public int CustomerId { get; set; }
        public string phone { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public override string ToString()
        {
            return $"[{CustomerId} Phone: {phone}]";
        }
        public abstract void CopyFrom(Customer source);
    }
}
