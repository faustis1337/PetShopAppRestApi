using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Faust.PetShopApp.Infrastructure
{
    public class PetAppContext:DbContext
    {
        public PetAppContext(DbContextOptions<PetAppContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OwnerEntity>().HasData(new OwnerEntity()
            {
                Id = 1,
                FirstName = "Faustas"
            });
            for (int i = 1; i < 501; i++)
            {
                modelBuilder.Entity<PetEntity>().HasData(new PetEntity
                {
                    Id = i,
                    Name = "Dog",
                    OwnerId = 1
                });
            }
        }

        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<PetTypeEntity> PetTypes { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
        public DbSet<ColorEntity> Colors { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
    }
}