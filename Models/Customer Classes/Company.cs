using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Customer_Classes
{
    public class Company : Customer
    {
        public string Location { get; set; } = null!;
        [Display(Name = "Company Name")]

        public string? CompanyName { get; set; }
        public override void CopyFrom(Customer source)
        {
            if(source is Company c)
            {
                Location = c.Location;
                CompanyName = c.CompanyName;
            }
            else throw new InvalidOperationException("Mismatched types");
        }
        public override string ToString()=> $" [{CustomerId}] Company name: {CompanyName} PhoneNo: {phone} Location: {Location}";
            
        

    }
}
