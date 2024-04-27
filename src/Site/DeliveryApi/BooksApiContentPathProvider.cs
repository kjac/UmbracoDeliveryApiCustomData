using Site.Models.Published;
using Umbraco.Cms.Core.DeliveryApi;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Strings;

namespace Site.DeliveryApi;

public class BooksApiContentPathProvider : ApiContentPathProvider
{
    private readonly IShortStringHelper _shortStringHelper;

    public BooksApiContentPathProvider(IPublishedUrlProvider publishedUrlProvider, IShortStringHelper shortStringHelper)
        : base(publishedUrlProvider)
        => _shortStringHelper = shortStringHelper;

    public override string? GetContentPath(IPublishedContent content, string? culture)
        => content is PublishedBook publishedBook
            // NOTE: the books are routed beneath a root item ("Books"), so the API path should not include any parent URL segments
            ? $"/{publishedBook.Name.ToLowerInvariant().ToUrlSegment(_shortStringHelper)}-{publishedBook.Isbn13}/"
            : base.GetContentPath(content, culture);
}
