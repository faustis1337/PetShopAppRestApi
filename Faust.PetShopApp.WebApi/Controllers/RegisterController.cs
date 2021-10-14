using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.MySecurity.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Faust.PetShopApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : Controller
    {
        private readonly IUserAuthenticator _userAuthenticator;
        private readonly ILogger<RegisterController> _logger;
        // GET
        public RegisterController(IUserAuthenticator userAuthenticator, ILogger<RegisterController> logger)
        {
            _userAuthenticator = userAuthenticator;
            _logger = logger;
        }

        // POST: api/Login
        [HttpPost]
        public IActionResult Post([FromBody] RegisterUserModel model)
        {
            string username = model.Username;
            string password = model.Password;

            if (_userAuthenticator.CreateUser(username, password))
            {
                //Authentication succesful
                return Ok();
            }
            else
            {
                return Problem("Could not create user with name: " + username);
            }
        }
    }
}