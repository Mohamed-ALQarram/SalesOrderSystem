using BLL;
using Models.Order_Classes;

namespace SalesOrderSystemWebUI.Models
{
    public class DashboardStatistics
    {
        public int customerNo {  get; set; }
        public int orderNo { get; set; }
        public int stockItemNo { get; set; }
        public int transactionNo { get; set; }

        public List<Order>? RecentOrders { get; set; }
        public List<StockItem>? LowStockAlerts { get; set; }
    }
}
