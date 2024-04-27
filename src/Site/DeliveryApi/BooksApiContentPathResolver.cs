using System.Text.RegularExpressions;
using Site.Services.Published;
using Umbraco.Cms.Core.DeliveryApi;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Site.DeliveryApi;

public partial class BooksApiContentPathResolver : ApiContentPathResolver
{
    private readonly IPublishedBookService _publishedBookService;

    public BooksApiContentPathResolver(
        IRequestRoutingService requestRoutingService,
        IApiPublishedContentCache apiPublishedContentCache,
        IPublishedBookService publishedBookService)
        : base(requestRoutingService, apiPublishedContentCache) =>
        _publishedBookService = publishedBookService;

    public override IPublishedContent? ResolveContentPath(string path)
    {
        // is it a book path (ends with an ISBN)?
        Match match = IsbnUrlPattern().Match(path);
        if (match.Success is false)
        {
            // nope - pass it on to the core resolver.
            return base.ResolveContentPath(path);
        }

        // yep - grab the ISBN and create the corresponding book content
        var isbn13 = long.Parse(match.Groups["isbn13"].Value);
        return _publishedBookService.Create(isbn13);
    }

    [GeneratedRegex("(?<isbn13>\\d{13})/?$")]
    private static partial Regex IsbnUrlPattern();
}
