using Models.Order_Classes;
using Models.Payments_Classes;

namespace BLL
{
    public class PaymentValidatorService
    {
        public static bool PaymentValidator(Order order, List<Payment> payMethods)
        {
            decimal TotalPaid = 0;
            foreach (Payment payment in payMethods)
            {
                if (payment is Cash cash)
                {
                    cash.Change = cash.CashValue - cash.Amount;
                }
                TotalPaid += payment.Amount;
            }
            return TotalPaid >= order.TotalPrice;
        }
    }
}
