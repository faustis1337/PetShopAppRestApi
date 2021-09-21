using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Core.IServices
{
    public interface IColorService
    {
        Color Create(Color color);
        List<Color> ReadAll();
        Color Read(int id);
        Color Update(Color owner);
        Color Delete(int id);
    }
}