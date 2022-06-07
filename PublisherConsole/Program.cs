// See https://aka.ms/new-console-template for more information

using PublisherData;

using var context = new PubContext();
context.Database.EnsureCreated(); 

var authors = context.Authors.ToList();
foreach (var author in authors)
{
    Console.WriteLine(author.FirstName + " " + author.LastName);
}
