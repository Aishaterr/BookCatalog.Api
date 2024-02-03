using BookCatalog.Application.Abstractions.Messaging;
using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Errors.Book;
using BookCatalog.Domain.Repositories;
using BookCatalog.SharedKernel;

namespace BookCatalog.Application.Books.DeleteBook;

internal sealed class DeleteBookCommandHandler : ICommandHandler<DeleteBookCommand>
{
    private readonly IBookRepository _bookRepository;

    public DeleteBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Result> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        if (request.BookId <= 0)
        {
            return Result.Failure<Book>(BookErrors.NullBookId);
        }

        await _bookRepository.DeleteBook(request.BookId, cancellationToken);

        return Result.Success();
    }
}
