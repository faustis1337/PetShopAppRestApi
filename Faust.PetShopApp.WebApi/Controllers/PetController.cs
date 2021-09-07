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
        public Pet pet(int id)
        {
            return _petService.Find(id);
        }

        [HttpPost] //body there is a json that matches the pet
        public ActionResult<Pet> Create(Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name))
            {
                return BadRequest("You need to enter Pet Name");
            }
            return _petService.CreatePet(pet);
        }

        [HttpDelete("{id}")]
        public Pet Delete(int id)
        {
            return _petService.DeletePet(id);
        }

        [HttpPut("{id}")]
        public Pet updatePet(int id, Pet pet)
        {
            if (id != pet.Id)
            {
                return null;
            }

            return _petService.UpdatePet(pet);
        }
        
    }
}