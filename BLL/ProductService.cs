using Core;
using Models.Order_Classes;

namespace BLL
{
    public class ProductService
    {
        IRepository<Product> _ProductRepo;
        public ProductService(IRepository<Product> ProductRepo)
        {
            _ProductRepo = ProductRepo;
        }
        public void AddProduct(Product product)
        {
            _ProductRepo.Add(product);
        }
        public void RemoveProduct(int Id) =>_ProductRepo.Delete(Id);
        public void UpdateProduct(Product Product)=>_ProductRepo.Update(Product);
        public List<Product> GetAll() => _ProductRepo.GetAll().ToList();

        public Product GetProductById(int ProductId)
        {
            var product = _ProductRepo.GetById(ProductId);
            if (product is null)
                throw new NullReferenceException($"There is no Product with this Id: {ProductId}");
            return product;
        }

    }
}
