using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Core.IServices
{
    public interface IOwnerService
    {
        Owner Create(Owner owner);
        List<Owner> ReadAll();
        Owner Read(int id);
        Owner Update(Owner owner);
        Owner Delete(int id);
    }
}