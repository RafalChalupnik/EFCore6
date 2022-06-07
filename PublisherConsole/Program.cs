// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

using (var context = new PubContext())
{
    context.Database.EnsureCreated(); 
}

// GetAuthors();
// AddAuthor();
// GetAuthors();
AddAuthorWithBooks();
GetAuthorsWithBooks();

void GetAuthors()
{
    using var context = new PubContext();
    var authors = context.Authors.ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}

void GetAuthorsWithBooks()
{
    using var context = new PubContext();
    var authors = context.Authors.Include(author => author.Books).ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
        foreach (var book in author.Books)
        {
            Console.WriteLine("*" + book.Title);
        }
    }
}

void AddAuthor()
{
    using var context = new PubContext();
    context.Authors.Add(new Author
    {
        FirstName = "Beza",
        LastName = "the Cat"
    });
    context.SaveChanges();
}

void AddAuthorWithBooks()
{
    var author = new Author
    {
        FirstName = "Rafal",
        LastName = "Chalupnik"
    };
    
    author.Books.Add(new Book
    {
        Title = "Angry Hamsters",
        PublishDate = new DateTime(year: 2022, month: 6, day: 7)
    });
    
    author.Books.Add(new Book
    {
        Title = "Return of Angry Hamsters",
        PublishDate = new DateTime(year: 2023, month: 7, day: 8)
    });
    
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}
