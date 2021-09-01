using System.Collections.Generic;
using System.Linq;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;

namespace Faust.PetShopApp.Domain.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public Owner Create(Owner owner)
        {
            return _ownerRepository.Create(owner);
        }

        public List<Owner> ReadAll()
        {
            return _ownerRepository.ReadAll().ToList();
        }

        public Owner Read(int id)
        {
            return _ownerRepository.Read(id);
        }

        public Owner Update(Owner owner)
        {
            return _ownerRepository.Update(owner);
        }

        public Owner Delete(int id)
        {
            return _ownerRepository.Delete(id);
        }
    }
}