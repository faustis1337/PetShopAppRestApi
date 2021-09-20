using System.Collections.Generic;
using System.Linq;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;
using Faust.PetShopApp.Infrastructure.Entities;

namespace Faust.PetShopApp.Infrastructure.EFRepositories
{
    public class PetTypeRepositoryEF:IPetTypeRepository
    {
        private readonly PetAppContext _ctx;

        public PetTypeRepositoryEF(PetAppContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<PetType> ReadPetTypes()
        {
            return _ctx.PetTypes.Select(entity => new PetType
            {
                Id = entity.Id,
                Name = entity.Name
            });
        }

        public PetType ReadById(int id)
        {
            return _ctx.PetTypes.Select(entity => new PetType()
            {
                Id = entity.Id,
                Name = entity.Name,
            }).FirstOrDefault(petType => petType.Id == id);
        }

        public PetType Create(PetType petType)
        {
            var entity = new PetTypeEntity()
            {
                Name = petType.Name,
            };
            var savedEntity = _ctx.PetTypes.Add(entity).Entity;
            _ctx.SaveChanges();
            return new PetType()
            {
                Id = savedEntity.Id,
                Name = savedEntity.Name,
            };
        }

        public PetType Delete(int id)
        {
            var entity = _ctx.PetTypes.FirstOrDefault(petType => petType.Id == id);
            var deletedEntity = _ctx.Remove(entity).Entity;
            _ctx.SaveChanges();
            return new PetType()
            {
                Id = deletedEntity.Id,
                Name = deletedEntity.Name
            };
        }

        public PetType Update(PetType type)
        {
            var entity = _ctx.PetTypes.Select(typeEntity => new PetTypeEntity
            {
                Id = typeEntity.Id,
                Name = type.Name
            }).FirstOrDefault(typeEntity => typeEntity.Id == type.Id);
            
            var updatedEntity = _ctx.Update(entity).Entity;
            _ctx.SaveChanges();
            return new PetType()
            {
                Id = updatedEntity.Id,
                Name = updatedEntity.Name
            };
        }
    }
}