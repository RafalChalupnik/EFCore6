using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PublisherDomain;

namespace PublisherData;

public class PubContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Server=localhost; Database=PubDatabase; User Id=SA; Password=MyP@ssw0rd;")
            .LogTo(
                Console.WriteLine, 
                new [] {DbLoggerCategory.Database.Command.Name},
                LogLevel.Information)
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(
            new Author { AuthorId = 1, FirstName = "Rafal", LastName = "Chalupnik" },
            new Author { AuthorId = 2, FirstName = "Beza", LastName = "the Cat" });
    }
}
