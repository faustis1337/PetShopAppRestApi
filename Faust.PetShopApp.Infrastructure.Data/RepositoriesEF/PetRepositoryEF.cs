﻿using System.Collections.Generic;
using System.Linq;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;
using Faust.PetShopApp.Infrastructure.Entities;

namespace Faust.PetShopApp.Infrastructure.EFRepositories
{
    public class EFPetRepository : IPetRepository
    {
        private readonly PetAppContext _ctx;

        public EFPetRepository(PetAppContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _ctx.Pets.Select(entity => new Pet
            {
                Id = entity.Id,
                Name = entity.Name,
                Color = entity.Color,
                Price = entity.Price,
                BirthDate = entity.BirthDate,
                SoldTime = entity.SoldTime,
                PreviousOwner = new Owner()
                {
                    Id = entity.PreviousOwnerID
                },
                Type = new PetType()
                {
                    Id = entity.TypeID
                }
            }).ToList();
        }

        public Pet Read(int id)
        {
            return _ctx.Pets.Select(entity => new Pet
            {
                Id = entity.Id,
                Name = entity.Name,
                Color = entity.Color,
                Price = entity.Price,
                BirthDate = entity.BirthDate,
                SoldTime = entity.SoldTime,
                PreviousOwner = new Owner()
                {
                    Id = entity.PreviousOwnerID
                },
                Type = new PetType()
                {
                    Id = entity.TypeID
                }
            }).FirstOrDefault(pet => pet.Id == id);
        }

        public Pet Create(Pet pet)
        {
            var entity = new PetEntity
            {
                Name = pet.Name,
                Color = pet.Color,
                Price = pet.Price,
                BirthDate = pet.BirthDate,
                SoldTime = pet.SoldTime,
                PreviousOwnerID = pet.Id,
                TypeID = pet.Type.Id
            };
            var savedEntity = _ctx.Pets.Add(entity).Entity;
            _ctx.SaveChanges();
            return new Pet
            {
                Id = savedEntity.Id,
                Name = savedEntity.Name,
                Color = savedEntity.Color,
                Price = savedEntity.Price,
                BirthDate = savedEntity.BirthDate,
                SoldTime = savedEntity.SoldTime,
                PreviousOwner = new Owner
                {
                    Id = savedEntity.PreviousOwnerID
                },
                Type = new PetType
                {
                    Id = savedEntity.TypeID
                }
            };
        }

        public Pet Delete(int id)
        {
            var entity = _ctx.Pets.FirstOrDefault(pet => pet.Id == id);
            var deletedEntity = _ctx.Remove(entity).Entity;
            _ctx.SaveChanges();
            return new Pet
            {
                Id = deletedEntity.Id,
                Name = deletedEntity.Name,
                Color = deletedEntity.Color,
                Price = deletedEntity.Price,
                BirthDate = deletedEntity.BirthDate,
                SoldTime = deletedEntity.SoldTime,
                PreviousOwner = new Owner
                {
                    Id = deletedEntity.Id
                },
                Type = new PetType
                {
                    Id = deletedEntity.TypeID
                }
            };
        }

        public Pet Update(Pet updatePet)
        {
            var updatedEntity = _ctx.Update(_ctx.Pets.Select(typeEntity => new PetEntity()
            {
                Id = updatePet.Id,
                Name = updatePet.Name,
                Color = updatePet.Color,
                Price = updatePet.Price,
                BirthDate = updatePet.BirthDate,
                SoldTime = updatePet.SoldTime,
                PreviousOwnerID = updatePet.Id,
                TypeID = updatePet.Type.Id
            }).FirstOrDefault(petEntity => petEntity.Id == petEntity.Id)).Entity;
            
            _ctx.SaveChanges();
            
            return new Pet
            {
                Id = updatedEntity.Id,
                Name = updatedEntity.Name,
                Color = updatedEntity.Color,
                Price = updatedEntity.Price,
                BirthDate = updatedEntity.BirthDate,
                SoldTime = updatedEntity.SoldTime,
                PreviousOwner = new Owner
                {
                    Id = updatedEntity.PreviousOwnerID
                },
                Type = new PetType
                {
                    Id = updatedEntity.TypeID
                }
            };
        }
    }
}