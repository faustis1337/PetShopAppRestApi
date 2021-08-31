using System;
using System.Collections.Generic;
using System.Linq;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;

namespace Faust.PetShopApp.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public List<Pet> GetPets()
        {
            return _petRepository.ReadPets().ToList();
        }

        public List<Pet> GetPetsByType(string type)
        {
            var list = _petRepository.ReadPets();
            var query = list.Where(pet => pet.Type.Name.Equals(type));
            return query.ToList();
        }

        public Pet CreatePet(string name, PetType type, DateTime birthDate, DateTime soldDate, string color,
            double price)
        {
            return _petRepository.Create(new Pet()
            {
                Name = name,
                BirthDate = birthDate,
                Color = color,
                Price = price,
                SoldTime = soldDate,
                Type = type
            });
        }

        public Pet DeletePet(int id)
        {
            return _petRepository.Delete(id);
        }

        public Pet UpdatePet(Pet pet)
        {
            return _petRepository.Update(pet);
        }

        public Pet Find(int id)
        {
            return _petRepository.ReadPets().SingleOrDefault(pet => pet.Id == id);
        }
    }
}