using System;
using System.Collections.Generic;
using Faust.PetShopApp.Core.Models;

namespace Faust.PetShopApp.Infrastructure.Entities
{
    public class PetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldTime { get; set; }
        public Color Color { get; set; }
        public double Price { get; set; }
        public int PreviousOwnerId { get; set; }
        
        public int OwnerId { get; set; }
        public OwnerEntity Owner { get; set; }
    }
}