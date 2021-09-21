using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Domain.IRepositories
{
    public interface IColorRepository
    {
        Color Create(Color color);
        IEnumerable<Color> ReadAll();
        Color Read(int id);
        Color Update(Color color);
        Color Delete(int id);
    }
}