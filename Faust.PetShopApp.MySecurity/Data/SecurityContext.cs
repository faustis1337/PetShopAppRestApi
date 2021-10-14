using Faust.PetShopApp.MySecurity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Faust.PetShopApp.MySecurity.Data
{
    public class SecurityContext:DbContext
    {
        public SecurityContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}