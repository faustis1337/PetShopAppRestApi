using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Core.IServices
{
    public interface IPetTypeService
    {
        PetType Find(string type);
        List<PetType> GetPetTypes();
        PetType ReadById(int id);
        PetType Create(PetType petType);
        PetType Delete(int id);

        string GetAvailableTypesString();
        PetType Update(PetType type);
    }
}