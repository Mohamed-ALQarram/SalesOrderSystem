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
    public class StockItemRepository : IStockItemRepository
    {
        readonly IDbContext _context;
        public StockItemRepository(IDbContext context) => _context = context;

        public void Add(StockItem entity)
        {
            _context.Set<StockItem>().Add(entity);
            _context.SaveChanges();

        }
        public void Delete(int Id) => _context.Set<StockItem>().Where(x => x.Id == Id).ExecuteDelete();
        public IEnumerable<StockItem> GetAll()=>_context.Set<StockItem>().AsNoTracking();

        public IEnumerable<StockItem> GetAllWithItems(int StockId)
        {
            var item = _context.Set<StockItem>().Where(x => x.StockId == StockId).Include(x => x.Product).AsNoTracking();
            return item;
        }
        public int Count()
        {
            return _context.Set<StockItem>().Count();
        }

        public IEnumerable<StockItem> GetAllWithPaging(int StockId, int Skip, int Take)=> _context.Set<StockItem>().Where(x=>x.StockId ==StockId)
            .AsNoTracking().Skip(Skip).Take(Take);

        public StockItem? GetById(int id)=> _context.Set<StockItem>().AsNoTracking().SingleOrDefault(x=>x.Id == id);
        public StockItem? GetById(int StockId, int ProductId) => _context.Set<StockItem>().AsNoTracking().SingleOrDefault(x => x.StockId == StockId && x.ProductId == ProductId);

        public int GetItemQuantity(int ProductId)
        {
            var items = _context.Set<StockItem>().AsNoTracking().Where(x =>x.ProductId == ProductId);
            if (items is null) throw new NullReferenceException("Item Not Found");
            int Quantity = 0;
            foreach (var item in items)
                Quantity += item.Quantity;
            return Quantity;
        }

        public void Update(StockItem entity)
        {
            var item = _context.Set<StockItem>().SingleOrDefault(x => x.Id == entity.Id);
            if (item is null) throw new NullReferenceException($"There is no Item with this Id {entity.Id}");
            item.Product = entity.Product;
            item.Quantity = entity.Quantity;
            item.Stock = entity.Stock;
            _context.SaveChanges();
        }

        public void UpdateQuantity(int ProductId, int StockId, int Quantity)
        {
            _context.Set<StockItem>()
                .Where(x => x.ProductId == ProductId && x.StockId == StockId)
                .ExecuteUpdate(x=>x.SetProperty(x=>x.Quantity , Quantity));
            _context.SaveChanges();
        }

        public IEnumerable<StockItem> GetLowStockAlerts(int NumberOfItems, int CriticalStockQuantity) 
            => _context.Set<StockItem>().Where(x=>x.Quantity<= CriticalStockQuantity).OrderBy(x=>x.Quantity).Take(NumberOfItems).Include(x=>x.Product);
    }
}
