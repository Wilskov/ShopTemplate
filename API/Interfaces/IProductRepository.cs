using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
     public interface IProductRepository
    {
        Task<Product> AddNewProduct(string name, string category, string description, decimal price);
        Task<Product> DeleteProduct(int id);
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync();
        void UpdateProduct(Product product);
        Task<bool> SaveAllAsync();
        /* Task<IEnumerable<ProductDto>> GetProductsDtoListAsync(string name, string category, string description, decimal price);
        Task<ProductDto> GetProductDtoAsync(string name, string category, string description, decimal price); */
    }
}