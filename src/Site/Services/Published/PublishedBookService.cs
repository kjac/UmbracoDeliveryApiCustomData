using Site.Models;
using Site.Models.Published;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Site.Services.Published;

public class PublishedBookService : IPublishedBookService
{
    private readonly IBookService _bookService;
    private readonly IPublishedSnapshotAccessor _publishedSnapshotAccessor;
    private readonly ILogger<IPublishedBookService> _logger;

    public PublishedBookService(IBookService bookService, IPublishedSnapshotAccessor publishedSnapshotAccessor, ILogger<IPublishedBookService> logger)
    {
        _bookService = bookService;
        _publishedSnapshotAccessor = publishedSnapshotAccessor;
        _logger = logger;
    }

    public PublishedBook? Create(long isbn13)
    {
        Book? book = _bookService.GetByIsbn13(isbn13);
        if (book is null)
        {
            return null;
        }

        // get the "books" root content, which is to serve as the book parent in the API response
        IPublishedContent? parent = _publishedSnapshotAccessor
            .GetRequiredPublishedSnapshot()
            .Content?
            .GetAtRoot()
            .FirstOrDefault(c => c.ContentType.Alias == "books");

        if (parent is not null)
        {
            return new PublishedBook(book, parent);
        }

        _logger.LogError("Could not find a \"books\" root node");
        return null;
    }
}
