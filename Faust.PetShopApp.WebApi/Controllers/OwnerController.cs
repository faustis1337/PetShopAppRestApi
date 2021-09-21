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
        public ActionResult<Owner> Create(Owner owner)
        {
            return _ownerService.Create(owner);
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
        public ActionResult<Owner> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest("ID has to be 1 or above");
            }
            return _ownerService.Delete(id);
        }

        [HttpPut("{id}")]
        public ActionResult<Owner> Update(int id,Owner owner)
        {
            if (id < 1)
            {
                return BadRequest("ID has to be 1 or above");
            }
            if(id != owner.Id)
            {
                return BadRequest("Owner ID must be the same");

            }
            
            return _ownerService.Update(owner);
        }
    }
}