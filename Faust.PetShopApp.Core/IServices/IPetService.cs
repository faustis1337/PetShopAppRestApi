using System;
using System.Collections.Generic;
using Faust.PetShopApp.Core.Filtering;
using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Core.IServices
{
    public interface IPetService
    {
        List<Pet> GetPets(Filter filter);
        Pet CreatePet(string name, PetType type, DateTime birthDate, DateTime soldDate, Color  color, double price);
        Pet DeletePet(int id);

        Pet UpdatePet(Pet pet);
        Pet Find(int id);
        Pet CreatePet(Pet pet);
        int Count();
        List<Pet> GetPetsByPrice(Filter filter);
        List<Pet> GetCheapestFivePets(Filter filter);

    }
}