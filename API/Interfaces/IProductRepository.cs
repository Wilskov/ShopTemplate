using API.Entities;

namespace API.Interfaces
{
     public interface IProductRepository
    {
        Task<Product> AddNewProduct(string name, string category, string description, decimal price);
        Task<Product> Delete(int id);
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync();
        void UpdateProduct(Product product);
        Task<bool> SaveAllAsync();
    }
}