using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{

    public class DataContext : DbContext
    {
        #region Properties
        public DbSet<User> Users { get; set; }
        #endregion

        #region Constructor
        public DataContext(DbContextOptions options) : base(options)
        {}
        #endregion
    }
}