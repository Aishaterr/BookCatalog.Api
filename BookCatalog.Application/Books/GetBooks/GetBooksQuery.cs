using BookCatalog.Application.Abstractions.Messaging;
using BookCatalog.Domain.Shared;

namespace BookCatalog.Application.Books.GetBooks;

public sealed record GetBooksQuery(Filters Filter, Paging Paging) : IQuery<List<BookResponseDTO>>;
