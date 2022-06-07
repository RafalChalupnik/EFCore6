// See https://aka.ms/new-console-template for more information

using PublisherData;
using PublisherDomain;

using (var context = new PubContext())
{
    context.Database.EnsureCreated(); 
}

GetAuthors();
AddAuthor();
GetAuthors();

void GetAuthors()
{
    using var context = new PubContext();
    var authors = context.Authors.ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
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
