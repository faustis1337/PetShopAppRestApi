using System.Collections.Generic;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Core.Models;
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
        public List<Pet> ReadAll()
        {
            return _petService.GetPets();
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> GetPet(int id)
        {
            if (id < 1)
            {
                return BadRequest("ID has to be 1 or above");
            }
            return Ok(_petService.Find(id));
        }

        [HttpPost] //body there is a json that matches the pet
        public ActionResult<Pet> Create(Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("ID has to be 1 or above");
            }
            return Ok(_petService.CreatePet(pet));
        }

        [HttpDelete("{id}")]
        public ActionResult<Pet> DeletePet(int id)
        {
            if (id < 1)
            {
                return BadRequest("ID has to be 1 or above");
            }
            return Ok(_petService.DeletePet(id));
        }

        [HttpPut("{id}")]
        public ActionResult<Pet> UpdatePet(int id, Pet pet)
        {
            if (id < 1)
            {
                return BadRequest("ID has to be above 1");
            }
            if(id != pet.Id)
            {
                return BadRequest("Pet ID must be the same or ID");

            }

            return Ok(_petService.UpdatePet(pet));
        }
        
    }
}