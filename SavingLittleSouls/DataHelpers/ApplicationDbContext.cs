using Microsoft.EntityFrameworkCore;
using SavingLittleSouls.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;

namespace SavingLittleSouls.DataHelpers
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalFamily>().HasKey(a => a.Id);
            modelBuilder.Entity<AnimalFamily>().Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<AnimalFamily>().Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(250);

            modelBuilder.Entity<AnimalType>().HasKey(a => a.Id);
            modelBuilder.Entity<AnimalType>().Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<AnimalType>().Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder.Entity<AnimalType>().HasOne(a => a.AnimalFamily)
                .WithMany(b => b.AnimalTypes)
                .HasForeignKey(c => c.AnimalFamilyId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Breed>().HasKey(a => a.Id);
            modelBuilder.Entity<Breed>().Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Breed>().Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(250);
            modelBuilder.Entity<Breed>().HasOne(a => a.AnimalType)
                .WithMany(b => b.Breeds)
                .HasForeignKey(c => c.AnimalTypeId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Pet>().HasKey(a => a.Id);
            modelBuilder.Entity<Pet>().Property(a => a.Name)
               .IsRequired()
               .HasMaxLength(50);
            modelBuilder.Entity<Pet>().Property(a => a.IdTag)
               .IsRequired()
               .HasMaxLength(12);
            modelBuilder.Entity<Pet>().Property(a => a.AdmitionDate)
               .IsRequired();
            modelBuilder.Entity<Pet>().Property(a => a.Notes)
               .HasMaxLength(300);
            modelBuilder.Entity<Pet>().Property(a => a.IsAdopted)
               .IsRequired();
            modelBuilder.Entity<Pet>().Property(a => a.AdmitionDate)
               .IsRequired();
            modelBuilder.Entity<Pet>().Property(a => a.Color)
               .IsRequired()
               .HasMaxLength(50);
            modelBuilder.Entity<Pet>().Property(a => a.Weight)
               .IsRequired();
            modelBuilder.Entity<Pet>().Property(a => a.Age)
              .IsRequired();
            modelBuilder.Entity<Pet>().HasOne(a => a.Status)
               .WithMany(b => b.Pets)
               .HasForeignKey(c => c.StatusId)
               .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Pet>().HasOne(a => a.Adopter)
              .WithMany(b => b.Pets)
              .HasForeignKey(c => c.AdopterId);
            modelBuilder.Entity<Pet>().HasOne(a => a.Gender)
              .WithMany(b => b.Pets)
              .HasForeignKey(c => c.GenderId)
              .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Pet>().HasOne(a => a.Breed)
              .WithMany(b => b.Pets)
              .HasForeignKey(c => c.BreedId)
              .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Status>().HasKey(a => a.Id);
            modelBuilder.Entity<Status>().Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Status>().Property(a => a.Description)
                .IsRequired()
                .HasMaxLength(250);

            modelBuilder.Entity<Gender>().HasKey(a => a.Id);
            modelBuilder.Entity<Gender>().Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<State>().HasKey(a => a.Id);
            modelBuilder.Entity<State>().Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<State>().Property(a => a.Abreviation)
                .IsRequired()
                .HasMaxLength(2);


            modelBuilder.Entity<PetImage>().HasKey(a => a.Id);
            modelBuilder.Entity<PetImage>().Property(a => a.Image)
                .IsRequired()
                .HasColumnType("image");
            modelBuilder.Entity<PetImage>().HasOne(a => a.Pet)
               .WithMany(b => b.PetImages)
               .HasForeignKey(c => c.PetId)
               .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Adopter>().HasKey(a => a.Id);
            modelBuilder.Entity<Adopter>().Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Adopter>().Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Adopter>().Property(a => a.Address)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Adopter>().Property(a => a.Address2)
                .HasMaxLength(50);
            modelBuilder.Entity<Adopter>().Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Adopter>().Property(a => a.Zip)
                .IsRequired()
                .HasMaxLength(5);
            modelBuilder.Entity<Adopter>().Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Adopter>().Property(a => a.Phone)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<Adopter>().Property(a => a.Fax)
                .HasMaxLength(20);
            modelBuilder.Entity<Adopter>().HasOne(a => a.State)
              .WithMany(b => b.Adopters)
              .HasForeignKey(c => c.StateId)
              .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Role>().HasKey(a => a.Id);
            modelBuilder.Entity<Role>().Property(a => a.RoleName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<User>().HasKey(a => a.Id);
            modelBuilder.Entity<User>().Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<User>().Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<User>().Property(a => a.UserName)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<User>().Property(a => a.Email)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<User>().Property(a => a.Phone)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<User>().Property(a => a.Password)
               .IsRequired()
               .HasMaxLength(20);
            modelBuilder.Entity<User>().HasOne(a => a.Role)
              .WithMany(b => b.Users)
              .HasForeignKey(c => c.RoleId)
              .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AnimalFamily> AnimalFamilies { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Adopter> Adopters { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetImage> PetImages { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
