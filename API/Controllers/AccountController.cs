/* The above code is a controller that is responsible for handling the user registration and login. */

using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {   
        #region  Properties
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        #endregion
        public AccountController(DataContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
            
        }
        #region Public Methodes
    /// <summary>
    /// The function takes in a RegisterDto object, checks if the user already exists, if not, it
    /// creates a new user object, hashes the password, and saves the user to the database
    /// </summary>
    /// <param name="RegisterDto">This is a class that contains the parameters that we want to pass to
    /// the API.</param>
    /// <returns>
    /// The user object is being returned.
    /// </returns>
        [HttpPost("register")] // POST: api/account/register
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExist(registerDto.Username)) 
            return BadRequest("User already exists");
            
            using var hmac = new HMACSHA512();
            
            var user = new User
            {
                UserName = registerDto.Username.ToLower(),
                LastName = registerDto.Lastname.ToLower(),
                Email = registerDto.Email.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

 /// <summary>
 /// We're checking if the user exists, if not, we return an unauthorized response. If the user does
 /// exist, we're using the password salt to create a hash of the password. We then compare the hash of
 /// the password to the hash of the password stored in the database. If they match, we return the user.
 /// If they don't match, we return an unauthorized response
 /// </summary>
 /// <param name="LoginDto">This is a class that contains the username and password that the user will
 /// enter.</param>
 /// <returns>
 /// The user object is being returned.
 /// </returns>
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => 
                x.UserName == loginDto.UserName
            );
            if (user == null) 
            return Unauthorized();

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) 
                    return Unauthorized("Invalid password");
            }

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        #endregion
        
        #region Private Methodes
     /// <summary>
     /// > This function checks if the user exists in the database
     /// </summary>
     /// <param name="UserName">The first name of the user.</param>
        private async Task<bool> UserExist(string username)
        {
            /* boucle sur toute la table Users */
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower()); 
        }
        // TODO => UserExist method compare the email and the UserName?

        #endregion
    }
}