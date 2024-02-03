using BookCatalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookCatalog.Persistence;

public class BookCatalogDbContext : DbContext
{
    public BookCatalogDbContext(DbContextOptions<BookCatalogDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasKey(x => x.Id);

        modelBuilder.Entity<Book>()
            .HasOne(e => e.Category)
            .WithMany(b => b.Books)
            .HasForeignKey(x => x.CategoryId);
    }
}
