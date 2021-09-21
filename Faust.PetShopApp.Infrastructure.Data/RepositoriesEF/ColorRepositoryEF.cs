using System.Collections.Generic;
using System.Linq;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;
using Faust.PetShopApp.Infrastructure.Entities;

namespace Faust.PetShopApp.Infrastructure.RepositoriesEF
{
    public class ColorRepositoryEF : IColorRepository
    {
        
        private readonly PetAppContext _ctx;

        public ColorRepositoryEF(PetAppContext ctx)
        {
            _ctx = ctx;
        }
        
        public Color Create(Color color)
        {
            var entity = new ColorEntity()
            {
                Id = color.Id,
                Name = color.Name
            };
            var savedEntity = _ctx.Colors.Add(entity).Entity;
            _ctx.SaveChanges();
            return new Color()
            {
                Id = savedEntity.Id,
                Name = savedEntity.Name
            };
        }

        public IEnumerable<Color> ReadAll()
        {
            return _ctx.Colors.Select(entity => new Color()
            {
                Id = entity.Id,
                Name = entity.Name
            });
        }

        public Color Read(int id)
        {
            return _ctx.Colors.Select(entity => new Color()
            {
                Id = entity.Id,
                Name = entity.Name
            }).FirstOrDefault(owner => owner.Id == id);
        }

        public Color Update(Color color)
        {
            var updatedEntity = _ctx.Update(new ColorEntity()
            {
                Id = color.Id,
                Name = color.Name

            }).Entity;
            _ctx.SaveChanges();
            return new Color()
            {
                Id = updatedEntity.Id,
                Name = updatedEntity.Name
            };
        }

        public Color Delete(int id)
        {
            var entity = _ctx.Colors.FirstOrDefault(owner => owner.Id == id);
            var deletedEntity = _ctx.Remove(entity).Entity;
            _ctx.SaveChanges();
            return new Color()
            {
                Id = deletedEntity.Id,
                Name = deletedEntity.Name
            };        
        }
    }
}