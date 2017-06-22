using System.Collections.Generic;

namespace SavingLittleSouls.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
