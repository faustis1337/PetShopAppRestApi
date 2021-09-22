using System.Collections.Generic;
using System.Linq;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.WebApi.Dto.ColorDto;
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
        public ActionResult<ColorDto> Create(Color color)
        {
            Color c = _colorService.Create(color);
            return new ColorDto {Id = c.Id, Name = c.Name};
        }

        [HttpGet]
        public ActionResult<ColorDto> Read(int id)
        {
            Color c = _colorService.Read(id);
            return new ColorDto{Id = c.Id,Name = c.Name};
        }
        
        [HttpGet("all")]
        public ActionResult<List<ColorDto>> ReadAll()
        {
            return _colorService.ReadAll().Select(c =>new ColorDto{Id = c.Id,Name = c.Name} ).ToList();
        }
    

        [HttpDelete]
        public ActionResult<ColorDto> Delete(int id)
        {
            if (id < 1)
            {
                return BadRequest("ID has to be 1 or above");
            }
            Color c = _colorService.Delete(id);
            return new ColorDto{Id = c.Id,Name = c.Name};
        }

        [HttpPut("{id}")]
        public ActionResult<ColorDto> Update(int id,Color color)
        {
            if (id < 1)
            {
                return BadRequest("ID has to be 1 or above");
            }
            if(id != color.Id)
            {
                return BadRequest("Owner ID must be the same");

            }
            Color c = _colorService.Update(color);
            return new ColorDto{Id = c.Id,Name = c.Name};
        }
    }
    }