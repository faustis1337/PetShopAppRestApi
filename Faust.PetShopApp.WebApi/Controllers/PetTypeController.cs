using System.Collections.Generic;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Faust.PetShopApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetTypeController
    {
        private readonly IPetTypeService _petTypeService;

        public PetTypeController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }
        
        [HttpGet]
        public List<PetType> ReadAll()
        {
            return _petTypeService.GetPetTypes();
        }
        
        [HttpGet("id")]
        public PetType ReadById(int id)
        {
            return _petTypeService.ReadById(id);
        }
        
        [HttpPost]
        public PetType Create(PetType petType)
        {
            return _petTypeService.Create(petType);
        }
        
        [HttpDelete("id")]
        public PetType Delete(int id)
        {
            return _petTypeService.Delete(id);
        }

        [HttpPut("id")]
        public PetType Update(PetType type)
        {
            return _petTypeService.Update(type);
        }
    }
}