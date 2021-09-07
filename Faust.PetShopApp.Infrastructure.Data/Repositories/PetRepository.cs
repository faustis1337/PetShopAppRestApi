using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;

namespace Faust.PetShopApp.Infrastructure.Repositories
{
    public class PetRepository : IPetRepository
    {
        private static int _ids;
        private static List<Pet> _pets = new List<Pet>();

        public PetRepository()
        {
            Create(new Pet()
            {
                Name = "Lol",
                Color = "red",
                Price = 71,
                Type = new PetType()
                {
                    Id = 1,
                    Name = "lolz"
                }
            });
            
            Create(new Pet()
            {
                Name = "Lol",
                Color = "red",
                Price = 31,
                Type = new PetType()
                {
                    Id = 1,
                    Name = "lolz"
                }
            });
            
            Create(new Pet()
            {
                Name = "Lol",
                Color = "red",
                Price = 35,
                Type = new PetType()
                {
                    Id = 1,
                    Name = "lolz"
                }
            });
            
            Create(new Pet()
            {
                Name = "Lol",
                Color = "red",
                Price = 28,
                Type = new PetType()
                {
                    Id = 1,
                    Name = "lolz"
                }
            });
            
            Create(new Pet()
            {
                Name = "Lol",
                Color = "red",
                Price = 20,
                Type = new PetType()
                {
                    Id = 1,
                    Name = "lolz"
                }
            });
            
            Create(new Pet()
            {
                Name = "Lol",
                Color = "red",
                Price = 16,
                Type = new PetType()
                {
                    Id = 1,
                    Name = "lolz"
                }
            });
            
            Create(new Pet()
            {
                Name = "Lol",
                Color = "red",
                Price = 11,
                Type = new PetType()
                {
                    Id = 1,
                    Name = "lolz"
                }
            });
            
            Create(new Pet()
            {
                Name = "Lol",
                Color = "red",
                Price = 8,
                Type = new PetType()
                {
                    Id = 1,
                    Name = "lolz"
                }
            });
            
            Create(new Pet()
            {
                Name = "Lol",
                Color = "red",
                Price = 7,
                Type = new PetType()
                {
                    Id = 1,
                    Name = "lolz"
                }
            });
            
            Create(new Pet()
            {
                Name = "Lol",
                Color = "red",
                Price = 1,
                Type = new PetType()
                {
                    Id = 5,
                    Name = "lolz"
                }
            });
        }
        
        public IEnumerable<Pet> ReadPets()
        {
            return _pets;
        }

        public Pet Create(Pet pet)
        {
            pet.Id = ++_ids;
            _pets.Add(pet);
            return pet;
        }

        public Pet Delete(int id)
        {
            Pet pet = _pets.Find(pet => pet.Id == id);
            if (pet != null)
            {
                _pets.Remove(pet);
            }

            return pet;
        }
        public Pet Update(Pet updatePet)
        {
            Pet pet = _pets.Find(pet => pet.Id == updatePet.Id);
            
            if (pet != null)
            {
                pet.Color = updatePet.Color;
                pet.Name = updatePet.Name;
                pet.Price = updatePet.Price;
                pet.Type = updatePet.Type;
                pet.BirthDate = updatePet.BirthDate;
                pet.PreviousOwner = updatePet.PreviousOwner;
                pet.SoldTime = updatePet.SoldTime;
                return pet;
            }

            return null;
        }
    }
}