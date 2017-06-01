using System.Collections.Generic;

namespace SavingLittleSouls.Models
{
    public class AnimalFamily
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<AnimalType> AnimalTypes { get; set; }
    }
}
