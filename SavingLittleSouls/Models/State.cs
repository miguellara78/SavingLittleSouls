using System.Collections.Generic;

namespace SavingLittleSouls.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abreviation { get; set; }
        public ICollection<Adopter> Adopters { get; set; }
    }
}
