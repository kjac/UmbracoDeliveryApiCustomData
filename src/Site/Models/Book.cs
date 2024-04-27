namespace Site.Models;

public class Book
{
    public required Guid Id { get; set; }

    public required long Isbn13 { get; set; }

    public required string Title { get; set; }

    public required string Summary { get; set; }

    public required string Author { get; set; }

    public DateTime PublishDate { get; set; }
}
