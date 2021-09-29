using System.Collections.Generic;

namespace Faust.PetShopApp.WebApi.Dto
{
    public class GetAllPetDto
    {
        public List<PetDto> List { get; set; }
        public int TotalCount { get; set; }
    }
}