using Core;
using Microsoft.EntityFrameworkCore;
using Models.Payments_Classes;

namespace DAL.Repositories
{
    public class PaymentRepository: IRepository<Payment>
    {
        readonly IDbContext _context;
        public PaymentRepository(IDbContext context)
        {
            _context = context;
        }

        public void Add(Payment entity)
        {
            _context.Payments.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int Id) => _context.Payments.Where(x => x.PaymentId == Id).ExecuteDelete();
        public IEnumerable<Payment> GetAll() => _context.Payments.AsNoTracking();

        public Payment? GetById(int id)=> _context.Payments.AsNoTracking().SingleOrDefault(x => x.PaymentId == id);

        public void Update(Payment entity)
        {
            var Payment = _context.Payments.SingleOrDefault(x => x.PaymentId == entity.PaymentId);
            if (Payment is null)
                throw new NullReferenceException("There is no Stock with this Id");
            Payment.PaiedDate = entity.PaiedDate;
            Payment.Amount = entity.Amount;
            Payment.Copyfrom(entity);
            _context.SaveChanges();
        }

    }

}
