using Core;
using Microsoft.EntityFrameworkCore;
using Models.Customer_Classes;
using Models.Enums;
using Models.Order_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        readonly IDbContext _context;
        public OrderRepository(IDbContext context)
        {
            _context = context;
        }

        public void Add(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }
        public int Count()
        {
            return _context.Orders.Count();
        }

        public void Delete(int Id) 
            => _context.Orders.Where(x => x.OrderId == Id).ExecuteDelete();
        public IEnumerable<Order> GetAll()
            => _context.Orders.Include(x=>x.OrderItems).ThenInclude(x=>x.Product).AsNoTracking();

        public Order? GetById(int id)
            => _context.Orders.Include(x=>x.OrderItems).AsNoTracking().SingleOrDefault(x => x.OrderId == id);

        public IEnumerable<Order> GetOrderByCustoemrId(int customerId)
            => _context.Orders.Where(x=>x.CustomerId == customerId).Include(x=>x.OrderItems).ThenInclude(x=>x.Product).AsNoTracking();
        

        public IEnumerable<Order> GetRecentOrders(int numberOfOrders)
            => _context.Orders.OrderByDescending(x=>x.Date).Include(x=>x.Customer).Take(numberOfOrders).AsNoTracking();
        

        public void Update(Order entity)
        {
            var order = _context.Orders.SingleOrDefault(x => x.OrderId == entity.OrderId);
            if (order is null)
                throw new NullReferenceException("There is no Order with this Id");
            order.OrderStatus = entity.OrderStatus;
            order.TotalPrice = entity.TotalPrice;
            order.OrderItems = entity.OrderItems;
            order.Customer = entity.Customer;
            _context.SaveChanges();

        }

        public void UpdateOrderStatus(int OrderId, OrderStatus status)
        {
            var order = _context.Orders.SingleOrDefault(x=>x.OrderId == OrderId);
            if (order is null)
                throw new NullReferenceException("There is no Order with this Id");
            order.OrderStatus = status;
            _context.SaveChanges();

        }

        IEnumerable<Order> IOrderRepository.GetOrderByCustoemrId(int customerId)
        {
            return GetOrderByCustoemrId(customerId);
        }
    }
}
