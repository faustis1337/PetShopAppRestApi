using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Core.IServices
{
    public interface IPetTypeService
    {
        PetType Find(string type);
        List<PetType> GetPetTypes();

        string GetAvailableTypesString();
    }
}