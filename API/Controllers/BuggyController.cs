using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// This is the BuggyController class.
    /// </summary>
    /// <remarks>
    /// This is the BuggyController class to create test of http request.
    /// </remarks>
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