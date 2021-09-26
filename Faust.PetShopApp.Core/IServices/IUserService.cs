using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Core.IServices
{
    public interface IUserService
    {
        List<User> ReadUsers();
        User Read(int id);
        User Create(User pet);
        User Delete(int id);
        User Update(User updateUser);
    }
}