using BookCatalog.Application.Abstractions.Messaging;

namespace BookCatalog.Application.Books.DeleteBook;

public sealed record DeleteBookCommand(long BookId) : ICommand;
