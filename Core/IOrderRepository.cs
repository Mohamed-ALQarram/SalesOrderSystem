using Models.Customer_Classes;
using Models.Enums;
using Models.Order_Classes;

namespace Core
{
    public interface IOrderRepository: IRepository<Order>
    {
        public void UpdateOrderStatus(int OrderId, OrderStatus status);
        public IEnumerable<Order> GetOrderByCustoemrId(int customerId);
        public IEnumerable<Order> GetRecentOrders(int numberOfOrders);

        public int Count();

    }

}
