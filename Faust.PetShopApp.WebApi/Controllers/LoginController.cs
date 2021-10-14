using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.MySecurity.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Faust.PetShopApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserAuthenticator _userAuthenticator;

        public LoginController(IUserAuthenticator userAuthenticator)
        {
            _userAuthenticator = userAuthenticator;
        }
        // GET
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] LoginInput model)
        {
            string userToken;
            if (_userAuthenticator.Login(model.Username, model.Password, out userToken))
            {
                //Authentication successful
                return Ok(new
                {
                    username = model.Username,
                    token = userToken
                });
            }
            return Unauthorized("Unknown username and password combination");
        }
    }
}