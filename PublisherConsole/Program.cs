// See https://aka.ms/new-console-template for more information

using PublisherData;

var _context = new PubContext();

var name = "Ozeki";
var authors = _context.Authors
    .Where(author => author.LastName == name)
    .ToList();

