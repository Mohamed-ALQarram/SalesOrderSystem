using System.Diagnostics;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesOrderSystemWebUI.Models;

namespace SalesOrderSystemWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CustomerService customerService;
        private readonly OrderService orderService;
        private readonly StockItemService stockItemService;
        private readonly TransactionService transactionService;

        public HomeController(ILogger<HomeController> logger, CustomerService customerService,
            OrderService orderService, StockItemService stockItemService,
            TransactionService transactionService)
        {
            _logger = logger;
            this.customerService = customerService;
            this.orderService = orderService;
            this.stockItemService = stockItemService;
            this.transactionService = transactionService;
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            DashboardStatistics statistics = new DashboardStatistics
            {
                customerNo = customerService.Count(),
                orderNo = orderService.Count(),
                stockItemNo = stockItemService.Count(),
                transactionNo = transactionService.Count(),
                RecentOrders = orderService.GetRecentOrders(),
                LowStockAlerts= stockItemService.GetLowStockAlerts()
            };
            return View(statistics);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
