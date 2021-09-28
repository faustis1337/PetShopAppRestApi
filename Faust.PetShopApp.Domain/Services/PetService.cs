using System;
using System.Collections.Generic;
using System.Linq;
using Faust.PetShopApp.Core.Filtering;
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

        public List<Pet> GetPets(Filter filter)
        {
            return _petRepository.ReadPets(filter).ToList();
        }

        public Pet CreatePet(string name, PetType type, DateTime birthDate, DateTime soldDate, Color color,
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
            return _petRepository.ReadPets(new Filter()).SingleOrDefault(pet => pet.Id == id);
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepository.Create(pet);
        }

        public int Count()
        {
            return _petRepository.Count();
        }

        public List<Pet> GetPetsByPrice(Filter filter)
        {
            var list = _petRepository.ReadPets(filter);
            return list.OrderBy(pet => pet.Price).ToList();
        }

        public List<Pet> GetCheapestFivePets(Filter filter)
        {
            var list = _petRepository.ReadPets(filter);
            return list.OrderBy(pet => pet.Price).Take(5).ToList();
        }
    }
}