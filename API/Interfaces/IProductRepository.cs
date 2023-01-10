using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

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
        //TODO: Test & implement
       /*  Task<ActionResult<IEnumerable<Product>>> AddProductToList(string name, string category, string description, decimal price); */
    
    }
}