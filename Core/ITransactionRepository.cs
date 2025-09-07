using Models.Payments_Classes;

namespace Core
{
    public interface ITransactionRepository: IRepository<Transaction>
    {
        IEnumerable<Transaction> GetAllWithPayments();
        public int Count();

    }

}
