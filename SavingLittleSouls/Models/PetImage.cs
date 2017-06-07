namespace SavingLittleSouls.Models
{
    public class PetImage
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public bool Featured { get; set; }
        public Pet Pet { get; set; }
        public int PetId { get; set; }
    }
}
