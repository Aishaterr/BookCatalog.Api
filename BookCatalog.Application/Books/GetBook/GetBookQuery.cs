using BookCatalog.Application.Abstractions.Messaging;
using BookCatalog.SharedKernel;

namespace BookCatalog.Application.Books.GetBook;

public sealed record GetBookQuery(long BookId) : IQuery<Result<BookResponseDTO>>;
