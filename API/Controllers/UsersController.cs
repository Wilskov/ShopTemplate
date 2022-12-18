using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController] // attribute
    [Route("api/[controller]")] // route => /api/users

    public class UsersController : ControllerBase
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