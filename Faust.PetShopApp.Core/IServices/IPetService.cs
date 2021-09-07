using System;
using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Core.IServices
{
    public interface IPetService
    {
        List<Pet> GetPets();
        List<Pet> GetPetsByType(string type);
        Pet CreatePet(string name, PetType type, DateTime birthDate, DateTime soldDate, string  color, double price);
        Pet DeletePet(int id);

        Pet UpdatePet(Pet pet);
        Pet Find(int id);
        Pet CreatePet(Pet pet);
        List<Pet> GetPetsByPrice();
        List<Pet> GetCheapestFivePets();
        
    }
}