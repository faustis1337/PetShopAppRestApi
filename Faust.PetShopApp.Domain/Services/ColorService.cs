using System.Collections.Generic;
using System.Linq;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;

namespace Faust.PetShopApp.Domain.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        
        public Color Create(Color color)
        {
            return _colorRepository.Create(color);
        }

        public List<Color> ReadAll()
        {
            return _colorRepository.ReadAll().ToList();
        }

        public Color Read(int id)
        {
            return _colorRepository.Read(id);
        }

        public Color Update(Color color)
        {
            return _colorRepository.Update(color);
        }

        public Color Delete(int id)
        {
            return _colorRepository.Delete(id);
        }
    }
}