// See https://aka.ms/new-console-template for more information

using PublisherData;
using PublisherDomain;

var _context = new PetContext();

var dogs = _context.Pets.OfType<Dog>().ToList();

foreach (var dog in dogs)
{
    Console.WriteLine($"-\tName: {dog.Name}");
    Console.WriteLine($"\tDOB: {dog.DateOfBirth}");
    Console.WriteLine($"\tSound: {dog.MakeSound()}");
}
