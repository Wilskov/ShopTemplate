using API.Entities;

namespace API.Interfaces
{
       public interface IShoppingCartRepository
    {
        Task<ShoppingCart> AddProduct(int id, Product product);
        Task<ShoppingCart> ClearShoppingCart(int id);
        Task<ShoppingCart> GetShoppingCartById(int id);
        IEnumerable<ShoppingCart> GetShoppingCarts();
        Task<ShoppingCart> GetTotal(decimal total, int id);
        Task<ShoppingCart> RemoveProduct(int id, Product product);
    }
}