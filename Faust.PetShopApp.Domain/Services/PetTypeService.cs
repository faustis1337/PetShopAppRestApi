using System.Collections.Generic;
using System.Linq;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;

namespace Faust.PetShopApp.Domain.Services
{
    public class PetTypeService:IPetTypeService
    {
        private IPetTypeRepository _petTypeRepository;
        public PetTypeService(IPetTypeRepository petTypeRepository)
        {
            _petTypeRepository = petTypeRepository;
        }
        public PetType Find(string type)
        {
            var list = _petTypeRepository.ReadPetTypes();
            var result = list.SingleOrDefault(petType => petType.Name == type);
            
            return result;
        }

        public List<PetType> GetPetTypes()
        {
            return _petTypeRepository.ReadPetTypes().ToList();
        }
        
        public string GetAvailableTypesString()
        {
            var list = GetPetTypes();
            string types;
            types = "(";
            for (int i = 0; i < list.Capacity; i++)
            {
                if (i < list.Capacity && i+1 !=list.Capacity)
                {
                    types += list[i].Name+ ",";
                }
                else
                {
                    types += list[i].Name;
                }
            }
            types += ")";
            return types;
        }
    }
}