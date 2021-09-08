using System;
using System.Collections.Generic;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Core.Models;
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
            Owner o = _ownerService.Create(owner);
            if (o != null)
            {
                return Ok(o);
            }

            return BadRequest("Owner could not be created");
        }

        [HttpGet]
        public ActionResult<Owner> Read(int id)
        {
            Owner owner = _ownerService.Read(id);
            if (owner != null)
            {
                return Ok(owner);
            }

            return BadRequest("Owner could not be found");
        }
        
        [HttpGet("all")]
        public ActionResult<List<Owner>> ReadAll()
        {
            List<Owner> owners = _ownerService.ReadAll();
            if (owners != null && owners.Capacity > 0)
            {
                return _ownerService.ReadAll();
            }

            BadRequest("Owner list is empty or null");
        }
    

        [HttpDelete]
        public ActionResult<Owner> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest("id is less than 1");
            }

            Owner owner = _ownerService.Delete(id);
            if (owner != null)
            {
                return Ok(owner);
            }

            return BadRequest("Owner could not be deleted!");
        }

        [HttpPut("{id}")]
        public ActionResult<Owner> Update(int id,Owner owner)
        {
            if (id < 1)
            {
                return BadRequest("ID has to be above 1");
            }
            if(id != owner.Id)
            {
                return BadRequest("Owner ID must be the same");

            }

            Owner o = _ownerService.Update(owner);
            if (o != null)
            {
                return Ok(o);

            }

            return BadRequest("Owner could not be updated!");
        }
    }
}