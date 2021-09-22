using System;

namespace Faust.PetShopApp.WebApi.Dto
{
    public class PetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String PreviousOwnerName { get; set; }
    }
}