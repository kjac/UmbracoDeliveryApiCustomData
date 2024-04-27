using Umbraco.Cms.Core.Models.PublishedContent;

namespace Site.Models.Published;

public class PublishedBook : IPublishedContent
{
    private readonly Book _book;
    private readonly IPublishedContent _parent;

    public PublishedBook(Book book, IPublishedContent parent)
    {
        _book = book;
        _parent = parent;
        Properties = new[]
        {
            new PublishedBookProperty("summary", book.Summary),
            new PublishedBookProperty("isbn13", book.Isbn13),
            new PublishedBookProperty("author", book.Author),
        };
    }

    public long Isbn13 => _book.Isbn13;

    public IPublishedContentType ContentType => new PublishedBookContentType();

    public Guid Key => _book.Id;

    public IEnumerable<IPublishedProperty> Properties { get; }

    public IPublishedProperty? GetProperty(string alias)
        => Properties.FirstOrDefault(p => p.Alias == alias);


    public int Level => _parent.Level + 1;

    public string Path => $"{_parent.Path},-1";

    public string Name => _book.Title;

    public DateTime CreateDate => _book.PublishDate;

    public DateTime UpdateDate => _book.PublishDate;

    public PublishedItemType ItemType => PublishedItemType.Content;

    public IPublishedContent? Parent => _parent;

    public IReadOnlyDictionary<string, PublishedCultureInfo> Cultures => new Dictionary<string, PublishedCultureInfo>();

    #region IPublishedContent implementation not required for the Delivery API (at least not for this demo)

    public int Id => throw new NotImplementedException(nameof(Id));

    public string? UrlSegment => throw new NotImplementedException(nameof(UrlSegment));

    public int SortOrder => throw new NotImplementedException(nameof(SortOrder));

    public int? TemplateId => throw new NotImplementedException(nameof(TemplateId));

    public int CreatorId => throw new NotImplementedException(nameof(CreatorId));

    public int WriterId => throw new NotImplementedException(nameof(WriterId));

    public bool IsDraft(string? culture = null) => throw new NotImplementedException(nameof(IsDraft));

    public bool IsPublished(string? culture = null) => throw new NotImplementedException(nameof(IsPublished));

    public IEnumerable<IPublishedContent> Children => throw new NotImplementedException(nameof(Children));

    public IEnumerable<IPublishedContent> ChildrenForAllCultures => throw new NotImplementedException(nameof(ChildrenForAllCultures));

    #endregion
}
