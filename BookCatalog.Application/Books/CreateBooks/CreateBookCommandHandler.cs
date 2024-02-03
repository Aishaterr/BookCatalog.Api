using BookCatalog.Application.Abstractions.Messaging;
using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Errors.Book;
using BookCatalog.Domain.Repositories;
using BookCatalog.SharedKernel;

namespace BookCatalog.Application.Books.CreateBooks;

internal sealed class CreateBookCommandHandler : ICommandHandler<CreateBookCommand>
{
    private readonly IBookRepository _bookRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Result> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(command.Title))
        {
            return Result.Failure<Book>(BookErrors.EmptyTitle);
        }

        await _bookRepository.CreateBook(
            new Book(command.CategoryId, command.Title, command.Description, command.UtcDateNow), 
            cancellationToken);

        return Result.Success();
    }
}