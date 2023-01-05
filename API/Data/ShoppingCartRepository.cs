using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{

    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly DataContext _context;

        public ShoppingCartRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ShoppingCart> GetShoppingCartById(int id)
        {
            return await _context.ShoppingCarts.FindAsync(id);
        }
        public async Task<ShoppingCart> AddProduct(int id, Product product)
        {
            var shoppingCart = new ShoppingCart();
            var existingProduct = await _context.ShoppingCarts.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (product == null || product.Quantity == 0)
            {
                return null;
            }
            if (existingProduct != null)
            {
                existingProduct.Quantity += product.Quantity;
                await _context.SaveChangesAsync();
                return shoppingCart;
            }

            shoppingCart.Products.Add(product);
            shoppingCart.TotalCost += product.Price;
            await _context.SaveChangesAsync();
            return shoppingCart;
        }

        public IEnumerable<ShoppingCart> GetShoppingCarts()
        {
            return _context.ShoppingCarts;
        }
        public async Task<ShoppingCart> RemoveProduct(int id, Product product)
        {
            var shoppingCart = await GetShoppingCartById(id);
            var existingProduct = await _context.ShoppingCarts.FirstOrDefaultAsync(p => p.Id == product.Id);
            if (product == null || product.Quantity == 0)
            {
                return null;
            }
            if (existingProduct != null)
            {
                existingProduct.Quantity -= product.Quantity;
                await _context.SaveChangesAsync();
                return shoppingCart;
            }

            shoppingCart.Products.Remove(product);
            shoppingCart.TotalCost -= product.Price;
            await _context.SaveChangesAsync();
            return shoppingCart;
        }

        public async Task<ShoppingCart> ClearShoppingCart(int id)
        {
            var shoppingCart = await GetShoppingCartById(id);
            shoppingCart.Products.Clear();
            shoppingCart.TotalCost = 0;
            await _context.SaveChangesAsync();
            return shoppingCart;
        }

        public async Task<ShoppingCart> GetTotal(decimal total, int id)
        {
            var shoppingCart = await GetShoppingCartById(id);

            foreach (var product in shoppingCart.Products)
            {
                total += product.Price;
            }
            shoppingCart.TotalCost = total;
            await _context.SaveChangesAsync();
            return shoppingCart;
        }
    }
}