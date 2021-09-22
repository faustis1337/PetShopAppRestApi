using System;
using System.Collections.Generic;
using System.Linq;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.WebApi.Dto.OwnerDto;
using Microsoft.AspNetCore.Mvc;

namespace Faust.PetShopApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        // GET
        [HttpPost]
        public ActionResult<OwnerDto> Create(Owner owner)
        {
            Owner o = _ownerService.Create(owner);
            return new OwnerDto{Id= o.Id,FirstName = o.FirstName,LastName = o.LastName};
        }

        [HttpGet]
        public ActionResult<OwnerDto> Read(int id)
        {
            Owner owner = _ownerService.Read(id);
            
            return new OwnerDto{Id= owner.Id,FirstName = owner.FirstName,LastName = owner.LastName};
        }
        
        [HttpGet("all")]
        public ActionResult<List<OwnerDto>> ReadAll()
        {
            return _ownerService.ReadAll().Select(owner => new OwnerDto{Id = owner.Id,FirstName = owner.FirstName,LastName = owner.LastName}).ToList();
        }
    

        [HttpDelete]
        public ActionResult<OwnerDto> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest("ID has to be 1 or above");
            }
            Owner owner = _ownerService.Delete(id);
            return new OwnerDto{Id= owner.Id,FirstName = owner.FirstName,LastName = owner.LastName};
        }

        [HttpPut("{id}")]
        public ActionResult<OwnerDto> Update(int id,Owner owner)
        {
            if (id < 1)
            {
                return BadRequest("ID has to be 1 or above");
            }
            if(id != owner.Id)
            {
                return BadRequest("Owner ID must be the same");

            }
            Owner o = _ownerService.Update(owner);
            return new OwnerDto{Id= o.Id,FirstName = o.FirstName,LastName = o.LastName};
        }
    }
}