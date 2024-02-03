using BookCatalog.Domain.Entities;
using BookCatalog.Domain.Errors.Book;
using BookCatalog.Domain.Repositories;
using BookCatalog.Domain.Shared;
using BookCatalog.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Persistence.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookCatalogDbContext _context;

    public BookRepository(BookCatalogDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Book>> GetBook(long id, CancellationToken cancellationToken)
    {
        var book = await _context.Books
            .Where(b => b.Id == id)
            .FirstOrDefaultAsync(cancellationToken);

        if (book is null)
        {
            return Result.Failure<Book>(BookErrors.NullBook);
        }

        return Result.Success(book);
    }

    public async Task CreateBook(Book book, CancellationToken cancellationToken)
    {
        _context.Add(book);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteBook(long id, CancellationToken cancellationToken)
    {
        var book = await _context.Books.FindAsync(id);

        if (book is not null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

    public async Task<List<Book>> GetBooks(Filters filters, Paging paging, CancellationToken cancellationToken)
    {
        IQueryable<Book> query = _context.Books.AsNoTracking();

        if (filters.CategoryId is not null)
        {
            query = query.Where(x => x.CategoryId == filters.CategoryId);
        }

        if (!string.IsNullOrWhiteSpace(filters.Title))
        {
            query = query.Where(x => x.Title.Contains(filters.Title, StringComparison.OrdinalIgnoreCase));
        }

        return await query
            .Skip((paging.Page - 1) * paging.PageSize)
            .Take(paging.PageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task UpdateBook(Book book, CancellationToken cancellationToken)
    {
        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
    }
}
