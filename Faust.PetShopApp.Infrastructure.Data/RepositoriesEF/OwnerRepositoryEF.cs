using System.Collections.Generic;
using System.Linq;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;
using Faust.PetShopApp.Infrastructure.Entities;

namespace Faust.PetShopApp.Infrastructure.EFRepositories
{
    public class OwnerRepositoryEF:IOwnerRepository
    {
        private readonly PetAppContext _ctx;

        public OwnerRepositoryEF(PetAppContext ctx)
        {
            _ctx = ctx;
        }
        public Owner Create(Owner owner)
        {
            var entity = new OwnerEntity()
            {
                Id = owner.Id,
                Address = owner.Address,
                Email = owner.Email,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                PhoneNumber = owner.PhoneNumber
            };
            var savedEntity = _ctx.Owners.Add(entity).Entity;
            _ctx.SaveChanges();
            return new Owner()
            {
                Id = savedEntity.Id,
                Address = savedEntity.Address,
                Email = savedEntity.Email,
                FirstName = savedEntity.FirstName,
                LastName = savedEntity.LastName,
                PhoneNumber = savedEntity.PhoneNumber
            };
        }

        public IEnumerable<Owner> ReadAll()
        {
            return _ctx.Owners.Select(entity => new Owner
            {
                Id = entity.Id,
                Address = entity.Address,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber
            });
        }

        public Owner Read(int id)
        {
            return _ctx.Owners.Select(entity => new Owner()
            {
                Id = entity.Id,
                Address = entity.Address,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber
            }).FirstOrDefault(owner => owner.Id == id);
        }

        public Owner Update(Owner owner)
        {
            var updatedEntity = _ctx.Update(new OwnerEntity
            {
                Id = owner.Id,
                Address = owner.Address,
                Email = owner.Email,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                PhoneNumber = owner.PhoneNumber
            }).Entity;
            _ctx.SaveChanges();
            return new Owner()
            {
                Id = updatedEntity.Id,
                Address = updatedEntity.Address,
                Email = updatedEntity.Email,
                FirstName = updatedEntity.FirstName,
                LastName = updatedEntity.LastName,
                PhoneNumber = updatedEntity.PhoneNumber
            };
        }

        public Owner Delete(int id)
        {
            var entity = _ctx.Owners.FirstOrDefault(owner => owner.Id == id);
            var deletedEntity = _ctx.Remove(entity).Entity;
            _ctx.SaveChanges();
            return new Owner()
            {
                Id = deletedEntity.Id,
                Address = deletedEntity.Address,
                Email = deletedEntity.Email,
                FirstName = deletedEntity.FirstName,
                LastName = deletedEntity.LastName,
                PhoneNumber = deletedEntity.PhoneNumber
            };
        }
    }
}