using BookCatalog.Domain.Entities;

namespace BookCatalog.Persistence;

public class DataSeeder
{
    private readonly BookCatalogDbContext _dataContext;

    public DataSeeder(BookCatalogDbContext dataContext)
    {
        this._dataContext = dataContext;
    }

    public void Seed()
    {
        var categories = new Category[]
        {
            new Category("Mystery"),
            new Category("Thriller"),
            new Category("Fantasy"),
            new Category("Science Fiction"),
            new Category("Horror"),
            new Category("Romance"),
            new Category("Historical Fiction")
        };

        foreach (var category in categories)
            _dataContext.Add(category);

        var books = new Book[]
        {
            new Book(1, "Gone Girl", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", DateTime.UtcNow),
            new Book(1, "Rebecca", "Nam quis tortor eu ante ultricies tempus ut sit amet nulla", DateTime.UtcNow),
            new Book(1, "Murder on the Orient Express", "Proin lacinia, massa eget interdum bibendum.", DateTime.UtcNow),
            new Book(2, "The Girl on the Train", "Nullam in nisl nec lectus pretium malesuada", DateTime.UtcNow),
            new Book(2, "My Sister, the Serial Killer", "Suspendisse non ligula est.", DateTime.UtcNow),
            new Book(3, "A Wizard of Earthsea", "Nam euismod varius lectus sit amet eleifend.", DateTime.UtcNow),
            new Book(4, "Dune", "Pellentesque lacus tortor, suscipit sit amet aliquet et.", DateTime.UtcNow),
            new Book(4, "Neuromancer", "Maecenas cursus nulla a lorem aliquet.", DateTime.UtcNow),
            new Book(5, "The Shining", "Maecenas tempus dapibus est, et.", DateTime.UtcNow),
            new Book(5, "Let the Right One In", "Duis fringilla leo sed mi viverra feugiat.", DateTime.UtcNow),
            new Book(6, "It Ends with Us", "Aliquam non molestie tellus.", DateTime.UtcNow),
            new Book(7, "All the Light We Cannot See", "Nam hendrerit lacus orci, sit amet.", DateTime.UtcNow)
        };

        foreach (var book in books)
            _dataContext.Add(book);

        _dataContext.SaveChanges();
    }
}
