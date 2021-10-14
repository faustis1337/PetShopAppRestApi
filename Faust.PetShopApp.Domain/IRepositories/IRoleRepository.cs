using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Domain.IRepositories
{
    public interface IRoleRepository
    {
        Role Create(Role role);
        IEnumerable<Role> ReadAll();
        Role Read(int id);
        Role Update(Role role);
        Role Delete(int id);
    }
}