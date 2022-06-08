// See https://aka.ms/new-console-template for more information

using PublisherData;

var _context = new PubContext();

QueryFilters();

void QueryFilters()
{
    var authors = _context.Authors
        .Where(author => author.LastName.StartsWith("t"))
        .ToList();
}
