// See https://aka.ms/new-console-template for more information

using PublisherData;

var _context = new PubContext();
var authors = _context.Authors.ToList();
