using Microsoft.EntityFrameworkCore;
using PublisherDomain;

namespace PublisherData;

public class PetContext : DbContext
{
    public DbSet<Human> Humans { get; set; }
    
    public DbSet<Pet> Pets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Server=localhost; Database=PetDatabase; User Id=SA; Password=MyP@ssw0rd;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cat>().ToTable("Cats");
        modelBuilder.Entity<Dog>().ToTable("Dogs");
        
        modelBuilder.Entity<Human>().HasData(
            new Human
            {
                HumanId = 1,
                Name = "Rafał"
            });

        modelBuilder.Entity<Dog>().HasData(
            new Dog
            {
                PetId = 1,
                HumanId = 1,
                Name = "Bessi",
                DateOfBirth = new DateTime(year: 2010, month: 4, day: 1),
                BarkDecibels = 70.3m
            }
        );
        
        modelBuilder.Entity<Cat>().HasData(
            new Cat
            {
                PetId = 2,
                HumanId = 1,
                Name = "Lily",
                DateOfBirth = new DateTime(year: 2019, month: 6, day: 1),
                Meows = 3
            },
            new Cat
            {
                PetId = 3,
                HumanId = 1,
                Name = "Beza",
                DateOfBirth = new DateTime(year: 2021, month: 6, day: 1),
                Meows = 2
            }
        );
    }
}
