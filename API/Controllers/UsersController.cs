using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]/*  A decorator that allows you to restrict access
    to a controller or method. */
    public class UsersController : BaseApiController
    {
        #region Properties

        private readonly IUserRepository _userRepository;
        /* private readonly IMapper _mapper;*/
                                                
        #endregion
       

        #region Controller
        public UsersController(IUserRepository userRepository /*, IMapper mapper */)
        {
            _userRepository = userRepository;
            /* _mapper = mapper; */
        }
        #endregion

        #region Méthodes
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return Ok( await _userRepository.GetUsersAsync());
        }
        
        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetUser(string username)
        {
            return await _userRepository.GetUserByUserNameAsync(username);
        }
      
       /* [HttpGet("{id}")]
         public async Task<ActionResult<User>> GetUserId(int id)
        {
            return await _userRepository.GetUserById(id);
        } */

        #endregion
    }
}