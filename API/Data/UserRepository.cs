using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUserNameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

      /// <summary>
      /// Save all changes to the database and return true if at least one row was affected.
      /// </summary>
      /// <returns>
      /// The return value is a boolean value.
      /// </returns>
        public async Task<bool> SaveAllAsync()
        {
           return await _context.SaveChangesAsync() > 0;
        }

        public void Update(User user)
        {
            /* Telling the context that the user object has been modified and needs to be updated in
            the database. */
            _context.Entry(user).State = EntityState.Modified;
        }
    }
}