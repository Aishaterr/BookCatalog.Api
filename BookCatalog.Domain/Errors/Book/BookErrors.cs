using BookCatalog.SharedKernel;

namespace BookCatalog.Domain.Errors.Book;

public static class BookErrors
{
    public static readonly Error EmptyTitle = new("Title.Empty", "The title is empty.");
    public static readonly Error NullBookId = new("BookId.Null", "The book ID is null.");
    public static readonly Error BookDTONull = new("Book.DTO.Null", "The book DTO is null.");
    public static readonly Error BookEntityNull = new("Book.Entity.Null", "The book is non-existent.");
    public static readonly Error NullBook = new("Book.Null", "Book is not existing.");
}
