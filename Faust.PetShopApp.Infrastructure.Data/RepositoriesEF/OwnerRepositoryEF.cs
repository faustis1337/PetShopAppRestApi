using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;

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
            throw new System.NotImplementedException();
        }

        public IEnumerable<Owner> ReadAll()
        {
            throw new System.NotImplementedException();
        }

        public Owner Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public Owner Update(Owner owner)
        {
            throw new System.NotImplementedException();
        }

        public Owner Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}