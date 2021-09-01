using System.Collections.Generic;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;

namespace Faust.PetShopApp.Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private static int _id;
        private static List<Owner> _owners = new List<Owner>();
        
        public Owner Create(Owner owner)
        {
            owner.Id = ++_id;
            _owners.Add(owner);
            return owner;
        }

        public IEnumerable<Owner> ReadAll()
        {
            return _owners;
        }

        public Owner Read(int id)
        {
            return _owners.Find(owner => owner.Id == id);
        }

        public Owner Update(Owner owner)
        {
            Owner own = _owners.Find(o => o.Id == owner.Id);
            if (own != null)
            {
                own.Address = owner.Address;
                own.Email = owner.Email;
                own.FirstName = owner.FirstName;
                own.LastName = owner.LastName;
                own.PhoneNumber = owner.PhoneNumber;
            }

            return own;
        }

        public Owner Delete(int id)
        {
            Owner owner = _owners.Find(o => o.Id == id);
            if (owner != null)
            {
                _owners.Remove(owner);
            }
            return owner;
        }
    }
}