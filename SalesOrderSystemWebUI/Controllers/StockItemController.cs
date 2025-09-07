using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Order_Classes;
using System.ComponentModel.DataAnnotations;

namespace SalesOrderSystemWebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class StockItemController : Controller
    {
        ProductService _productService;
        StockItemService _stockItemService;
        public StockItemController(StockItemService stockItemService, ProductService ProductService) 
        { 
            _stockItemService = stockItemService;
            _productService = ProductService;
        }
        public IActionResult GetAllItems()
        {
            var Items = _stockItemService.GetAllStockItems(1000);
            return View("GetAllItems", Items);
        }
        public IActionResult AddItem(StockItem Item, Product product)
        {
            if (Item == null || product == null || product.ProductId==0 ) return NotFound();
            _productService.AddProduct(product);
            _stockItemService.AddStockItem(Item.StockId, product, Item.Quantity);
            return RedirectToAction("GetAllStocksWithItems","Stock");
        }

        public IActionResult EditItem(StockItem Item)
        {
            return View("EditItem", Item);
        }
        [HttpPost]
        public IActionResult SaveEditedItem(StockItem Item)
        {
            _stockItemService.UpdateStock(Item);
            return RedirectToAction("GetAllStocksWithItems","Stock");
        }
        public IActionResult RemoveItem(int Id)
        {
            _stockItemService.RemoveStock(Id);
            return RedirectToAction("GetAllStocksWithItems", "Stock");
        }


    }
}
