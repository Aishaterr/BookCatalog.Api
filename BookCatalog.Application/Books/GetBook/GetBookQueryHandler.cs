using BookCatalog.Application.Abstractions.Messaging;
using BookCatalog.Domain.Repositories;
using BookCatalog.SharedKernel;

namespace BookCatalog.Application.Books.GetBook;

internal sealed class GetBookQueryHandler : IQueryHandler<GetBookQuery, Result<BookResponseDTO>>
{
    private readonly IBookRepository _bookRepository;

    public GetBookQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<Result<BookResponseDTO>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetBook(request.BookId, cancellationToken);

        if (book.Value == null)
        {
            return Result.Failure<BookResponseDTO>(new Error("Book.None", "Book Not found."));
        }

        var bookDTO = new BookResponseDTO(book.Value.Title, book.Value.Description);

        return Result.Success(bookDTO);
    }
}
