using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Domain.Entities;

public class Book
{
    public Book()
    {
            
    }
    public Book(long categoryId, string title, string description, DateTime dateTime)
    {
        CategoryId = categoryId;
        Title = title;
        Description = description;
        PublishDateUtc = dateTime;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public long CategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime PublishDateUtc { get; set; }

    public virtual Category Category { get; set; }
}
