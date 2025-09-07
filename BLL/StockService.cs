using Core;
using Models.Order_Classes;

namespace BLL
{
    public class StockService
    {
        IStockRepository _StockRepo;

        public StockService(IStockRepository StockRepo)
        {
            _StockRepo = StockRepo;

        }
        public void AddStock(Stock stock)
        {
            _StockRepo.Add(stock);
        }
        public void RemoveStock(int Id) => _StockRepo.Delete(Id);
        public void UpdateStock(Stock stock) => _StockRepo.Update(stock);
        public List<Stock> GetAllWithItems() => _StockRepo.GetAllWithItems().ToList();
        public List<Stock> GetAll() => _StockRepo.GetAll().ToList();

        public Stock GetStockById(int StockId)
        {
            var Stock = _StockRepo.GetById(StockId);
            if (Stock == null) throw new NullReferenceException($"There is no Stock with this Id: {StockId}");
            return Stock;
        }
    }
}
