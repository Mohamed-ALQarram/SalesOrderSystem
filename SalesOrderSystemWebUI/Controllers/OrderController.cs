using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Models.Order_Classes;

namespace SalesOrderSystemWebUI.Controllers
{
    [Authorize(Roles ="Admin, Casher")]
    public class OrderController : Controller
    {
        private readonly OrderService orderService;
        private readonly ProductService prodductService;

        public OrderController(OrderService orderService, ProductService prodductService)
        {
            this.orderService = orderService;
            this.prodductService = prodductService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var Orders = orderService.GetOrders();
            return View(Orders);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CreateOrder()
        {
            var products = prodductService.GetAll();
            return View(products);
        }
        
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateOrder(List<OrderItem> Items, int CustomerId)
        {
            orderService.cretaeOrder(CustomerId, Items);
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult EditOrder(int Id)
        {
            var order =orderService.GetOrderById(Id);   
            return View(order);
        }
        public IActionResult ViewOrder(int Id)
        {
            var order = orderService.GetOrderById(Id);
            return View(order);
        }


    }

}
