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
            return _ownerService.Create(owner);
        }

        [HttpGet]
        public ActionResult<Owner> Read(int id)
        {
            return _ownerService.Read(id);
        }
        
        [HttpGet("all")]
        public ActionResult<List<Owner>> ReadAll()
        {
            return _ownerService.ReadAll();
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