using Core;
using Microsoft.EntityFrameworkCore;
using Models.Order_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderItemRepository: IRepository<OrderItem>
    {
        readonly IDbContext _context;
        public OrderItemRepository(IDbContext context)
        {
            _context = context;
        }

        public void Add(OrderItem entity)
        {
            _context.OrderItems.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int Id) => _context.OrderItems.Where(x => x.Id == Id).ExecuteDelete();

        public IEnumerable<OrderItem> GetAll() => _context.OrderItems.AsNoTracking();

        public OrderItem? GetById(int id)=>  _context.OrderItems.AsNoTracking().SingleOrDefault(x => x.Id == id);
        

        public void Update(OrderItem entity)
        {
            var OrderItem = _context.OrderItems.SingleOrDefault(x => x.Id == entity.Id);
            if (OrderItem is null)
                throw new NullReferenceException("There is no Order with this Id");
            OrderItem.SalePrice = entity.SalePrice;
            OrderItem.Order = entity.Order;
            OrderItem.Product = entity.Product;
            OrderItem.Quantity = entity.Quantity;

            _context.SaveChanges();
        }

    }
}
