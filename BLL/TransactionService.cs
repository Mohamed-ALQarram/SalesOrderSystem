using Core;
using Models.Payments_Classes;

namespace BLL
{
    public class TransactionService
    {
        ITransactionRepository _TransRepo;
        public TransactionService(ITransactionRepository TransRepo)
        {
            _TransRepo = TransRepo;
        }

        public void CreateTransaction(int orderId, List<Payment> payments)
        {
            var transaction = new Transaction { OrderId = orderId, Payments = payments };
            _TransRepo.Add(transaction);
        }
        public void updateTransAction(Transaction transaction)
        {
            _TransRepo.Update(transaction);
        }
        public void ReomveTransAction(int Id)
        {
            _TransRepo.Delete(Id);
        }
        public int Count()
        {
            return _TransRepo.Count();
        }

        public Transaction GetTransactionById(int TransactionId)
        {
            var Trans= _TransRepo.GetById(TransactionId);
            if(Trans == null)
                throw new NullReferenceException($"There is No Transaction With this Id: {TransactionId}");
            return Trans;
        }

        public List<Transaction> GetTransactions()
        {
            return _TransRepo.GetAll().ToList();
        }
        public List<Transaction> GetTransactionsWithPayments()
        {
            return _TransRepo.GetAllWithPayments().ToList();
        }

    }
}
