using BookCatalog.Application.Abstractions.Messaging;
using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Errors.Book;
using BookCatalog.Domain.Repositories;
using BookCatalog.SharedKernel;

namespace BookCatalog.Application.Books.UpdateBook;

internal sealed class UpdateBookCommandHandler : ICommandHandler<UpdateBookCommand>
{
    private readonly IBookRepository _bookRepository;

    public UpdateBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Result> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        if (request.UpdateBookDTO == null) 
        {
            return Result.Failure<Book>(BookErrors.BookDTONull);
        }

        var book = await _bookRepository.GetBook(request.UpdateBookDTO.BookId, cancellationToken);

        if (book == null)
        {
            return Result.Failure<Book>(BookErrors.BookEntityNull);
        }

        book.Value.Title = request.UpdateBookDTO.BookTitle;
        book.Value.Description = request.UpdateBookDTO.BookDescription;
        book.Value.CategoryId = request.UpdateBookDTO.CategoryId;

        await _bookRepository.UpdateBook(book.Value, cancellationToken);

        return Result.Success(book.Value);
    }
}
