using System.Collections.Generic;
using System.Linq;
using Faust.PetShopApp.Core.Filtering;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.WebApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Faust.PetShopApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : Controller
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }
        
        [HttpGet]
        public ActionResult<PetDto> ReadAll([FromQuery]Filter filter)
        {
            int totalCount = _petService.Count();
            var list = _petService.GetPets(filter);
            return Ok(new GetAllPetDto
            {
                List = list.Select(pet => new PetDto
                {
                    Id = pet.Id,
                    Name = pet.Name,
                    PreviousOwnerName = pet.Name
                }).ToList(),
                TotalCount = totalCount
            });
        }

        [HttpGet("{id}")]
        public ActionResult<PetDto> GetPet(int id)
        {
            if (id < 1)
            {
                return BadRequest("ID has to be 1 or above");
            }
            Pet pet = _petService.Find(id);
            return new PetDto {Id = pet.Id, Name = pet.Name, PreviousOwnerName = pet.Name};
        }

        [HttpPost] //body there is a json that matches the pet
        public ActionResult<PetDto> Create(Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("ID has to be 1 or above");
            }
            Pet p = _petService.CreatePet(pet);
            return new PetDto {Id = p.Id, Name = p.Name, PreviousOwnerName = p.Name};
        }

        [HttpDelete("{id}")]
        public ActionResult<PetDto> DeletePet(int id)
        {
            if (id < 1)
            {
                return BadRequest("ID has to be 1 or above");
            }
            
            var pet = _petService.DeletePet(id);
            return new PetDto {Id = pet.Id, Name = pet.Name, PreviousOwnerName = pet.Name};
        }

        [HttpPut("{id}")]
        public ActionResult<PetDto> UpdatePet(int id, Pet pet)
        {
            if (id < 1)
            {
                return BadRequest("ID has to be 1 or above");
            }
            if(id != pet.Id)
            {
                return BadRequest("Pet ID must be the same or ID");

            }
            
            var p = _petService.UpdatePet(pet);
            return new PetDto {Id = p.Id, Name = p.Name, PreviousOwnerName = p.Name};
        }
        
    }
}