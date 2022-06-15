﻿// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

var _context = new PetContext();

var human = _context.Humans
    .Include(human => human.Pets)
    .FirstOrDefault();

Console.WriteLine($"Name: {human.Name}");
Console.WriteLine("Pets:");

foreach (var pet in human.Pets)
{
    Console.WriteLine($"-\tName: {pet.Name}");
    Console.WriteLine($"\tDOB: {pet.DateOfBirth}");
    Console.WriteLine($"\tSound: {pet.MakeSound()}");
}

_context.Pets.Add(new Cat
{
    HumanId = 1,
    Name = "Test"
});

_context.SaveChanges();