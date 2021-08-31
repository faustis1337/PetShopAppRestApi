using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        IEnumerable<PetType> ReadPetTypes();
    }
}