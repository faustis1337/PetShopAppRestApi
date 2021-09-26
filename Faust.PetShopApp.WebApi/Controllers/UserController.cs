using System.Collections.Generic;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Faust.PetShopApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public List<User> ReadAll()
        {
            return _userService.ReadUsers();
        }
        
        [HttpGet("id")]
        public User ReadById(int id)
        {
            return _userService.Read(id);
        }
        
        [HttpPost]
        public User Create(User user)
        {
            return _userService.Create(user);
        }
        
        [HttpDelete("id")]
        public User Delete(int id)
        {
            return _userService.Delete(id);
        }

        [HttpPut("id")]
        public User Update(User user)
        {
            return _userService.Update(user);
        }
    }
}