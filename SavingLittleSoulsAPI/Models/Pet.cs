using System;
using System.Collections.Generic;

namespace SavingLittleSouls.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string IdTag { get; set; }
        public string Name { get; set; }
        public DateTime AdmitionDate { get; set; }
        public Status Status { get; set; }
        public int StatusId { get; set; }
        public string Notes { get; set; }
        public DateTime AdoptionDate { get; set; }
        public bool IsAdopted { get; set; }
        public Adopter Adopter { get; set; }
        public int? AdopterId { get; set; }
        public int Age { get; set; }
        public decimal Weight { get; set; }
        public string Color { get; set; }
        public Breed Breed { get; set; }
        public int BreedId { get; set; }
        public Gender Gender { get; set; }
        public int GenderId { get; set; }
        public ICollection<PetImage> PetImages { get; set; }
    }
}
