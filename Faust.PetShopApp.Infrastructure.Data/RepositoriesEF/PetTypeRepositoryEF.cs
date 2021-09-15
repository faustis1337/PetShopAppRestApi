using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;

namespace Faust.PetShopApp.Infrastructure.EFRepositories
{
    public class EFPetTypeRepository:IPetTypeRepository
    {
        private readonly PetAppContext _ctx;

        public EFPetTypeRepository(PetAppContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<PetType> ReadPetTypes()
        {
            throw new System.NotImplementedException();
        }
    }
}