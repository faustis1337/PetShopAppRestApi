﻿using System;
using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;

namespace Faust.PetShopApp.Infrastructure.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private static List<PetType> petTypes = new List<PetType>();
        
        public PetTypeRepository()
        {
            petTypes.Add(new PetType()
            {
                Id = 1,
                Name = "Cat"
            });
            petTypes.Add(new PetType()
            {
                Id = 2,
                Name = "Dog"
            });
            petTypes.Add(new PetType()
            {
                Id = 3,
                Name = "Goat"
            });
        }

        public IEnumerable<PetType> ReadPetTypes()
        {
            return petTypes;
        }

        public PetType ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public PetType Create(PetType petType)
        {
            throw new NotImplementedException();
        }

        public PetType Delete(int id)
        {
            throw new NotImplementedException();
        }

        public PetType Update(PetType type)
        {
            throw new NotImplementedException();
        }
    }
}