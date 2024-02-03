namespace BookCatalog.Application.Books.CreateBooks;

public sealed record CreateBookDTO(string Title, string Description, long CategoryId);
