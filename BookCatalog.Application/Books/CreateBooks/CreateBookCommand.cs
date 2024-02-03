using BookCatalog.Application.Abstractions.Messaging;

namespace BookCatalog.Application.Books.CreateBooks;

public sealed record CreateBookCommand (
    string Title, 
    string Description, 
    DateTime UtcDateNow, 
    long CategoryId) : ICommand;
