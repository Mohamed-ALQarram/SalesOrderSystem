using Core;
using Microsoft.EntityFrameworkCore;
using Models.Payments_Classes;

namespace DAL.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        readonly IDbContext _context;
        public TransactionRepository(IDbContext context)
        {
            _context = context;
        }

        public void Add(Transaction entity)
        {
            _context.Transactions.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int Id) => _context.Transactions.Where(x => x.TransactionId == Id).ExecuteDelete();


        public IEnumerable<Transaction> GetAll() => _context.Transactions.AsNoTracking();

        public IEnumerable<Transaction> GetAllWithPayments() => _context.Transactions.Include(x => x.Payments).AsNoTracking();
        public int Count()
        {
            return _context.Transactions.Count();
        }

        public Transaction? GetById(int id)=> _context.Transactions.AsNoTracking().SingleOrDefault(x => x.TransactionId == id);
        public void Update(Transaction entity)
        {
            var Transaction = _context.Transactions.SingleOrDefault(x => x.TransactionId == entity.TransactionId);
            if (Transaction is null)
                throw new NullReferenceException("There is no Stock with this Id");
            Transaction.Order = entity.Order;
            Transaction.Payments = entity.Payments;
            _context.SaveChanges();
        }


    }

}
