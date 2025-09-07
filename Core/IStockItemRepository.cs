using Models.Order_Classes;

namespace Core
{
    public interface IStockItemRepository : IRepository<StockItem>
    {
        public int GetItemQuantity(int ProductId);
        public void UpdateQuantity(int ProductId, int StockId, int Quantity);
        public StockItem? GetById(int StockId, int ProductId);
        public IEnumerable<StockItem> GetAllWithItems(int StockId);
        public IEnumerable<StockItem> GetAllWithPaging(int StockId, int Skip, int Take);
        public IEnumerable<StockItem> GetLowStockAlerts(int NumberOfItems, int CriticalStockQuantity);

        public int Count();

    }


}
