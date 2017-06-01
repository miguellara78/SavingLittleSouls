namespace SavingLittleSouls.Models
{
    public class PetImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public Pet Pet { get; set; }
        public int PetId { get; set; }
    }
}
