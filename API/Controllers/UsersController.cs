using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{   
    [Authorize] /* A decorator that allows you to restrict access
    to a controller or method. */
    public class UsersController : BaseApiController
    {
        #region Properties
        private readonly DataContext _context;
        #endregion

        #region Controller
        public UsersController(DataContext context)
        {
            _context = context;
        }
        #endregion

        #region Méthodes
        /* It allows anonymous users to access the method. */
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        #endregion
    }
}