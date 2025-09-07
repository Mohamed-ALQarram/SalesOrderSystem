using Models.Order_Classes;
using System.Security.Cryptography.X509Certificates;

namespace Core
{
    public interface IStockRepository: IRepository<Stock>
    {
        public IEnumerable<Stock> GetAllWithItems();

    }


}
