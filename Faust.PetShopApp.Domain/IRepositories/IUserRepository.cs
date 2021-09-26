using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Domain.IRepositories
{
    public interface IUserRepository
    {
        IEnumerable<User> ReadUsers();
        User Read(int id);
        User Create(User pet);
        User Delete(int id);
        User Update(User updateUser);
    }
}