using System.Collections.Generic;

namespace SavingLittleSouls.Models
{
    public class AnimalType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AnimalFamily AnimalFamily { get; set; }
        public int AnimalFamilyId { get; set; }
        public ICollection<Breed> Breeds { get; set; }
    }
}
