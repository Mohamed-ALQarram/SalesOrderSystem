using Core;
using Microsoft.EntityFrameworkCore;
using Models.Customer_Classes;

namespace BLL
{
    public class CustomerService
    {
        ICustomerRepository _customerRepo;
        public CustomerService(ICustomerRepository Repository)
        {
            _customerRepo = Repository;
        }
        public int Count()
        {
            return _customerRepo.Count();
        }

        public void AddCustomer(Customer customer)
        {
            _customerRepo.Add(customer);
        }
        public void RemoveCustomer(int Id)
        {
            _customerRepo.Delete(Id);
        }
        public void UpdateCustomer(Customer customer)
        {
            _customerRepo.Update(customer);
        }
        public List<Customer> GetAll() => _customerRepo.GetAll().ToList();
        public List<Customer> GetAllWithOrders() => _customerRepo.GetAllWithOrders().ToList();

        public Customer GetCustomerById(int CustomerId)
        {

            var Customer = _customerRepo.GetById(CustomerId);
            if (Customer is null)
                throw new NullReferenceException($"There is No Customer with this Id{CustomerId}");
            return Customer;
        }
    }
}
