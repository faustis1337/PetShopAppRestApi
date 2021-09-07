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

            return BadRequest();
        }

        [HttpGet]
        public ActionResult<Owner> Read(int id)
        {
            Owner owner = _ownerService.Read(id);
            if (owner != null)
            {
                return Ok(_ownerService.Read(id));
            }

            return BadRequest();
        }
        
        [HttpGet("all")]
        public ActionResult<List<Owner>> ReadAll()
        {
            List<Owner> owners = _ownerService.ReadAll();
            if (owners != null && owners.Capacity > 0)
            {
                return _ownerService.ReadAll();
            }
            return _ownerService.ReadAll();
        }
    

        [HttpDelete]
        public ActionResult<Owner> Delete(int id)
        {
            return Ok(_ownerService.Delete(id));
        }

        [HttpPut]
        public ActionResult<Owner> Update(Owner owner)
        {
            return Ok(_ownerService.Update(owner));
        }
    }
}