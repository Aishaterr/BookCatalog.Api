using BookCatalog.Application.Abstractions.Messaging;
using BookCatalog.Domain.Repositories;

namespace BookCatalog.Application.Books.GetBooks;

internal sealed class GetBooksQueryHandler : IQueryHandler<GetBooksQuery, List<BookResponseDTO>>
{
    private readonly IBookRepository _bookRepository;

    public GetBooksQueryHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<BookResponseDTO>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetBooks(request.Filter, request.Paging, cancellationToken);

        return books.Select(b => new BookResponseDTO(b.Title, b.Description)).ToList();
    }
}
