using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Shared;
using BookCatalog.SharedKernel;

namespace BookCatalog.Domain.Repositories;

public interface IBookRepository
{
    Task<Result<Book>> GetBook(long id, CancellationToken cancellationToken);
    Task<List<Book>> GetBooks(Filters filters, Paging paging, CancellationToken cancellationToken);
    Task CreateBook(Book book, CancellationToken cancellationToken);
    Task UpdateBook(Book book, CancellationToken cancellationToken);
    Task DeleteBook(long id, CancellationToken cancellationToken);
}
