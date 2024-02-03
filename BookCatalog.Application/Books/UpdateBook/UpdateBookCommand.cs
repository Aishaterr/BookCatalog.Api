using BookCatalog.Application.Abstractions.Messaging;

namespace BookCatalog.Application.Books.UpdateBook;

public sealed record UpdateBookCommand(UpdateBookDTO UpdateBookDTO) : ICommand;
