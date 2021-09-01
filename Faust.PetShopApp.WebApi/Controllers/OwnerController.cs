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

            return null;
        }

        [HttpGet]
        public ActionResult<Owner> Read(int id)
        {
            return _ownerService.Read(id);
        }
        
        [HttpGet("all")]
        public List<Owner> ReadAll()
        {
            return _ownerService.ReadAll();
        }
    

        [HttpDelete]
        public ActionResult<Owner> Delete(int id)
        {
            return _ownerService.Delete(id);
        }

        [HttpPut]
        public ActionResult<Owner> Update(Owner owner)
        {
            return _ownerService.Update(owner);
        }
    }
}