using System;
using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Infrastructure.Entities
{
    public class PetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PetType Type { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldTime { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public Owner PreviousOwner { get; set; }
    }
}