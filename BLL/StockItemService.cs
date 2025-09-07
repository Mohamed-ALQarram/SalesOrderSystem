using Core;
using Models.Order_Classes;

namespace BLL
{
    public class StockItemService
    {
        IStockItemRepository _StockItemRepo;

        public StockItemService(IStockItemRepository StockItemRepo)
        {
            _StockItemRepo = StockItemRepo;

        }
        public void AddStockItem(int StockId, Product Product, int Quantity)
        {
            var Item= _StockItemRepo.GetById(StockId, Product.ProductId);
            if(Item is null)
            {
                Item = new StockItem { StockId = StockId, ProductId = Product.ProductId , Quantity = Quantity};
                _StockItemRepo.Add(Item);
            }
            else
            {
                Item.Quantity += Quantity;
                _StockItemRepo.Update(Item);
            }
        }
        public List<StockItem> GetLowStockAlerts(int NumberOfItems=5, int CriticalStockQuantity=10)
        {
            return _StockItemRepo.GetLowStockAlerts(NumberOfItems, CriticalStockQuantity).ToList();
        }
        public int Count()
        {
            return _StockItemRepo.Count();
        }


        public List<StockItem> GetAllStockItems(int StockId)
        {
            var item =_StockItemRepo.GetAllWithItems(StockId);
            return item.ToList();

        }
        public List<StockItem> GetAllStockItemsWithPaging(int StockId, int Skip, int Take) => _StockItemRepo.GetAllWithPaging(StockId, Skip, Take).ToList();
        public void RemoveStock(int Id) => _StockItemRepo.Delete(Id);
        public void UpdateStock(StockItem stock) => _StockItemRepo.Update(stock);
        public List<StockItem> GetAll() => _StockItemRepo.GetAll().ToList();
        public void UpdateQuantity(int ProductId, int StockId, int Quantity)
        {
             _StockItemRepo.UpdateQuantity(ProductId, StockId, Quantity);
        }

        public StockItem GetStockItemById(int ItemId)
        {
            var StockItem = _StockItemRepo.GetById(ItemId);
            if (StockItem == null) throw new NullReferenceException($"There is no Stock with this Id: {ItemId}");
            return StockItem;
        }
        public int GetItemQuantity(int ProductId) => _StockItemRepo.GetItemQuantity(ProductId);
    }
}
