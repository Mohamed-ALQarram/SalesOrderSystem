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
    public  class ProductRepository: IRepository<Product>
    {
        readonly IDbContext _context;
        public ProductRepository(IDbContext context)
        {
            _context = context;
        }

        public void Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int Id) => _context.Products.Where(x => x.ProductId == Id).ExecuteDelete();

        public IEnumerable<Product> GetAll() => _context.Products.AsNoTracking();

        public Product? GetById(int id)=> _context.Products.AsNoTracking().SingleOrDefault(x => x.ProductId == id);

        public void Update(Product entity)
        {
            var Product = _context.Products.SingleOrDefault(x => x.ProductId == entity.ProductId);
            if (Product is null)
                throw new NullReferenceException("There is no Order with this Id");
            Product.ProductName = entity.ProductName;
            Product.Price = entity.Price;
            Product.OrderItems = entity.OrderItems;
            _context.SaveChanges();
        }
    }
}
