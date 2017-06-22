using System.Collections.Generic;

namespace SavingLittleSouls.Models
{
    public class Breed
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AnimalType AnimalType { get; set; }
        public int AnimalTypeId { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
