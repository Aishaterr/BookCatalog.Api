using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Domain.Entities;

public class Category
{
    public Category( string name)
    {
        Name = name;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Book> Books { get; set; }
}
