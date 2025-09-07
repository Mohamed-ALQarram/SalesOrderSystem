using Core;
using Microsoft.EntityFrameworkCore;
using Models.Customer_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly IDbContext _context;
        public CustomerRepository(IDbContext context) 
        {
            _context= context;
        }
        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Customers.Count();
        }

        public void Delete(int Id)=>_context.Customers.Where(x=>x.CustomerId == Id).ExecuteDelete();

        public IEnumerable<Customer> GetAll()=> _context.Customers.AsNoTracking();

        public IEnumerable<Customer> GetAllWithOrders() => _context.Customers.Include(x=>x.Orders).AsNoTracking();

        public Customer? GetById(int id)=>  _context.Customers.Include(x=>x.Orders).ThenInclude(x=>x.OrderItems).ThenInclude(x=>x.Product).AsNoTracking().SingleOrDefault(x=>x.CustomerId == id);
        public void Update(Customer entity)
        {
            var customer = _context.Customers?.SingleOrDefault(x => x.CustomerId == entity.CustomerId);
            if (customer is not null)
            {
                customer.phone =  entity.phone;
                customer.Orders = entity.Orders;
                customer.CopyFrom(entity);
                _context.SaveChanges();

            }
            else throw new NullReferenceException("there is No Customer With this Id");

        }
    }
}
