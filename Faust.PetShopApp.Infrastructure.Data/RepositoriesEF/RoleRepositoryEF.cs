using System.Collections.Generic;
using System.Linq;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;
using Faust.PetShopApp.Infrastructure.Entities;

namespace Faust.PetShopApp.Infrastructure.RepositoriesEF
{
    public class RoleRepositoryEF : IRoleRepository
    {
        public PetAppContext _ctx;

        public RoleRepositoryEF(PetAppContext petAppContext)
        {
            _ctx = petAppContext;
        }

        public Role Create(Role role)
        {
            var entity = new RoleEntity
            {
                Name = role.Name
            };
            var addedRole = _ctx.Roles.Add(entity).Entity;
            return new Role
            {
                Id = addedRole.Id,
                Name = addedRole.Name
            };
        }

        public IEnumerable<Role> ReadAll()
        {
            return _ctx.Roles.Select(entity => new Role
            {
                Id = entity.Id,
                Name = entity.Name
            }).ToList();
        }

        public Role Read(int id)
        {
            return _ctx.Roles.Select(entity => new Role
            {
                Id = entity.Id,
                Name = entity.Name
            }).FirstOrDefault(role => role.Id == id);
        }

        public Role Update(Role role)
        {
            var updatedRole = _ctx.Roles.Update(new RoleEntity
            {
                Id = role.Id,
                Name = role.Name
            }).Entity;
            _ctx.SaveChanges();
            return new Role
            {
                Id = updatedRole.Id,
                Name = updatedRole.Name
            };
        }

        public Role Delete(int id)
        {
            var entity = _ctx.Roles.FirstOrDefault(re => re.Id == id);
            var deletedEntity = _ctx.Remove(entity).Entity;
            _ctx.SaveChanges();
            return new Role
            {
                Id = deletedEntity.Id,
                Name = deletedEntity.Name
            };
        }
    }
}