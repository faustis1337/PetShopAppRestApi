﻿using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Faust.PetShopApp.Infrastructure
{
    public class PetAppContext:DbContext
    {
        public PetAppContext(DbContextOptions<PetAppContext> opt) : base(opt)
        {
            
        }
        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<PetTypeEntity> PetTypes { get; set; }
        public DbSet<OwnerEntity> Owners { get; set; }
    }
}