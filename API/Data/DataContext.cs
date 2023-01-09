using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{

    public class DataContext : DbContext
    {
        #region Properties
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
/*         public DbSet<ShoppingCart> ShoppingCarts { get; set; }
 */
        #endregion
        #region Constructor
        public DataContext(DbContextOptions options) : base(options)
        {}
        #endregion
    }
}