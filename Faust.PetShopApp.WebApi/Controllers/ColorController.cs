using System.Collections.Generic;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Faust.PetShopApp.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColorController:Controller
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }
        
        [HttpPost]
        public ActionResult<Color> Create(Color owner)
        {
            return _colorService.Create(owner);
        }

        [HttpGet]
        public ActionResult<Color> Read(int id)
        {
            return _colorService.Read(id);
        }
        
        [HttpGet("all")]
        public ActionResult<List<Color>> ReadAll()
        {
            return _colorService.ReadAll();
        }
    

        [HttpDelete]
        public ActionResult<Color> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest("ID has to be 1 or above");
            }
            return _colorService.Delete(id);
        }

        [HttpPut("{id}")]
        public ActionResult<Color> Update(int id,Color color)
        {
            if (id < 1)
            {
                return BadRequest("ID has to be 1 or above");
            }
            if(id != color.Id)
            {
                return BadRequest("Owner ID must be the same");

            }
            
            return _colorService.Update(color);
        }
    }
    }