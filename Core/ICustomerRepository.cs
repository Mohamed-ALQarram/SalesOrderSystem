using Models.Customer_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface ICustomerRepository:IRepository<Customer>
    {
        public IEnumerable<Customer> GetAllWithOrders();

        public int Count();
    }
}
