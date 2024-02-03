using BookCatalog.Domain.Shared;

namespace BookCatalog.Application.Books.GetBooks;

public sealed record BookListRequestDTO(Filters Filters,Paging Paging);

