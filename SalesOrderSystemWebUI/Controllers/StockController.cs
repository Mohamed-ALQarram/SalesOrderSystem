using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SalesOrderSystemWebUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class StockController : Controller
    {
        StockService _stockService;

        public StockController(StockService StockService) { _stockService = StockService; }
        public IActionResult GetAllStocksWithItems()
        {
            var Stocks =_stockService.GetAllWithItems();
            return View("GetAllStocksWithItems", Stocks);
        }
        public IActionResult AddItemToStock()
        {
            return View("AddItemToStock", _stockService.GetAll());
        }
    }
}
