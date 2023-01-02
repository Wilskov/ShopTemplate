using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;

        public BuggyController(DataContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        /// <summary>
        /// If the user is not found, return a 404
        /// </summary>
        /// <returns>
        /// A User object
        /// </returns>
        [HttpGet("not-found")]
        public ActionResult<User> GetNotFound()
        {
            try
            {
                var thing = _context.Users.Find(-1);

                if (thing == null) return NotFound();

                return thing;
            }
            catch (Exception)
            {
                return StatusCode(500, "Computer says no!");
            }

        }

        /// <summary>
        /// It's a function that returns a string, and it's a GET request
        /// </summary>
        /// <returns>
        /// The thingToReturn is being returned.
        /// </returns>
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = _context.Users.Find(-1);
            var thingToReturn = thing.ToString();

            return thingToReturn;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }
    }
}