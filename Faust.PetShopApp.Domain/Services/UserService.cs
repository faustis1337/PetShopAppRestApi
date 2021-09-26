using System.Collections.Generic;
using System.Linq;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;

namespace Faust.PetShopApp.Domain.Services
{
    public class UserService :IUserService
    {
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> ReadUsers()
        {
            return _userRepository.ReadUsers().ToList();
        }

        public User Read(int id)
        {
            return _userRepository.Read(id);
        }

        public User Create(User pet)
        {
            return _userRepository.Create(pet);
        }

        public User Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public User Update(User updateUser)
        {
            return _userRepository.Update(updateUser);
        }
    }
}