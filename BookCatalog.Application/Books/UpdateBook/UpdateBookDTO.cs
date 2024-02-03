namespace BookCatalog.Application.Books.UpdateBook;

public sealed record UpdateBookDTO(
    long BookId,
    string BookTitle,
    string BookDescription,
    long CategoryId,
    DateTime ModifiedDateUtc);
