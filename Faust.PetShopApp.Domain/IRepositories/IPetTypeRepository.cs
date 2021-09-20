using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        IEnumerable<PetType> ReadPetTypes();
        PetType ReadById(int id);
        PetType Create(PetType petType);
        PetType Delete(int id);
        PetType Update(PetType type);
    }
}