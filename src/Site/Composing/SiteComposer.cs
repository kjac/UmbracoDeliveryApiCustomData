using Site.DeliveryApi;
using Site.Services;
using Site.Services.Published;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DeliveryApi;

namespace Site.Composing;

public class SiteComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddSingleton<IBookService, BookService>();
        builder.Services.AddSingleton<IPublishedBookService, PublishedBookService>();
        builder.Services.AddSingleton<IApiContentPathProvider, BooksApiContentPathProvider>();
        builder.Services.AddSingleton<IApiContentPathResolver, BooksApiContentPathResolver>();
    }
}
