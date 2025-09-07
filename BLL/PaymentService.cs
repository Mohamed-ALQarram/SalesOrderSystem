using Core;
using Models.Enums;
using Models.Order_Classes;
using Models.Payments_Classes;

namespace BLL
{
    public class PaymentService
    {
        IRepository<Payment> _payRepo;
        OrderService _orderService;
        TransactionService _transactionService;
        StockItemService _stockItemService;
        public PaymentService(IRepository<Payment> PayRepo, TransactionService Transaction, OrderService Order, StockItemService stockItemService)
        {
            _payRepo = PayRepo;
            _transactionService = Transaction;
            _orderService = Order;
            _stockItemService = stockItemService;
        }
        public void PayOrder(int orderId, List<Payment> payMethods)
        {
            var Order = _orderService.GetOrderById(orderId);
            foreach (var Item in Order.OrderItems)
                if(/*!_stockItemService.UpdateQuantity(Item.ProductId, Item.Quantity)*/true)
                {
                    _orderService.updateOrderState(Order.OrderId, OrderStatus.CANCELED);
                    throw new InvalidOperationException("Stock Items Quantity Not enough to fulfill the order.");
                }
            if (PaymentValidatorService.PaymentValidator(Order, payMethods))
            {
                _orderService.updateOrderState(Order.OrderId, OrderStatus.PAID);
                _transactionService.CreateTransaction(orderId, payMethods);
            }
            else
            {
                throw new InvalidOperationException("Invalid PayMethod");
            }
        }
        public void PayOrders(List<Order> Orders, List<Payment> payMethods)
        {
            foreach (var Order in Orders)
            {
                PayOrder(Order.OrderId, payMethods);
            }
        }

        public List<Payment> GetPayments()
        {
            return _payRepo.GetAll().ToList();
        }


    }
}
