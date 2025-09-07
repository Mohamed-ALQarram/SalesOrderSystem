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
    public class StockRepository : IStockRepository
    {
        readonly IDbContext _context;
        public StockRepository(IDbContext context)
        {
            _context = context;
        }

        public void Add(Stock entity)
        {
            _context.Stocks.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int Id) => _context.Stocks.Where(x => x.StockId == Id).ExecuteDelete();

        public IEnumerable<Stock> GetAll() => _context.Stocks.AsNoTracking();

        public Stock? GetById(int id)=> _context.Stocks.AsNoTracking().SingleOrDefault(x => x.StockId == id);
          
        public void Update(Stock entity)
        {
            var Stock = _context.Stocks.SingleOrDefault(x => x.StockId == entity.StockId);
            if (Stock is null)
                throw new NullReferenceException("There is no Stock with this Id");
            Stock.count = entity.count;
            Stock.StockItems = entity.StockItems;
            _context.SaveChanges();
        }

        public IEnumerable<Stock> GetAllWithItems()=> _context.Stocks.Include(x=>x.StockItems).ThenInclude(x=>x.Product).AsNoTracking();

    }

}
