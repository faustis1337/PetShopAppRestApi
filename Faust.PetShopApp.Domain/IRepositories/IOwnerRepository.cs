using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Domain.IRepositories
{
    public interface IOwnerRepository
    {
        Owner Create(Owner owner);
        IEnumerable<Owner> ReadAll();
        Owner Read(int id);
        Owner Update(Owner owner);
        Owner Delete(int id);
    }
}