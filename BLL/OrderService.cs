using Core;
using Models.Enums;
using Models.Order_Classes;

namespace BLL
{
    public class OrderService
    {
        IOrderRepository _OrderRepo;
        CustomerService _CustomerService;
        public OrderService(IOrderRepository OrderRepo, CustomerService CustomerService)
        {
            _OrderRepo = OrderRepo;
            _CustomerService = CustomerService;
        }
        public void cretaeOrder(int CustomerId, List<OrderItem> Items)
        {
            var Customer = _CustomerService.GetCustomerById(CustomerId);
            decimal TotalPrice = 0;
            foreach (var Item in Items)
                TotalPrice += Item.SalePrice;
            var Order = new Order { CustomerId = Customer.CustomerId, OrderItems = Items, TotalPrice = TotalPrice, Date = DateTime.UtcNow, OrderStatus = OrderStatus.Pending };
            _OrderRepo.Add(Order);
        }
        public int Count()
        {
            return _OrderRepo.Count();
        }

        public List<Order> GetRecentOrders(int NumberOfOrders=4)
        {
            return _OrderRepo.GetRecentOrders(NumberOfOrders).ToList();
        }
        public void updateOrderState(int OrderId, OrderStatus status)
        {
            var Order = _OrderRepo.GetById(OrderId);
            if (Order is null)
                throw new NullReferenceException($"There is No Order With this Id: {OrderId}");

            Order.OrderStatus = status;
            _OrderRepo.Update(Order);
        }
        public Order GetOrderById(int OrderId)
        {
            var Order = _OrderRepo.GetById(OrderId);
            if (Order is null)
                throw new NullReferenceException($"There is No Order With this Id: {OrderId}");
            return Order;
        }
        public List<Order> GetOrderByCustoemrId(int customerId)
        {
            return _OrderRepo.GetOrderByCustoemrId(customerId).ToList();
        }

        public List<Order> GetOrders()
        {
            return _OrderRepo.GetAll().ToList();
        }


    }
}
