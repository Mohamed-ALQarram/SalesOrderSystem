using Models.Customer_Classes;
using Models.Enums;
using System.Text;
using System.Transactions;

namespace Models.Order_Classes
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus? OrderStatus { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; } = null!;
       
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public override string ToString()
        {
            StringBuilder str = new();
            foreach (var item in OrderItems) 
                str.Append(item.ToString());
            if(str.Length > 0 )
            return $"[{OrderId}] CustomerId: {CustomerId} Date: {Date} Price: {TotalPrice} Status: {OrderStatus}\n " +
                $"Items: \n{str}";
            else return $"[{OrderId}] CustomerId: {CustomerId} Date: {Date} Price: {TotalPrice} Status: {OrderStatus}";
        }
    }
}
