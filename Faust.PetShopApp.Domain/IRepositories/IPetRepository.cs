using System.Collections.Generic;
using Faust.PetShopApp.Core.Filtering;
using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Domain.IRepositories
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets(Filter filter);
        Pet Read(int id);
        Pet Create(Pet pet);
        Pet Delete(int id);
        Pet Update(Pet updatePet);
        int Count();
    }
}