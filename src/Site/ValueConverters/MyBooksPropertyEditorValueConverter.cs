using Site.Services.Published;
using Umbraco.Cms.Core.DeliveryApi;
using Umbraco.Cms.Core.Models.DeliveryApi;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.PropertyEditors.DeliveryApi;
using Umbraco.Cms.Core.Serialization;

namespace Site.ValueConverters;

public class MyBooksPropertyEditorValueConverter : PropertyValueConverterBase, IDeliveryApiPropertyValueConverter
{
    private readonly IApiContentBuilder _apiContentBuilder;
    private readonly IPublishedBookService _publishedBookService;
    private readonly IJsonSerializer _jsonSerializer;
    private readonly ILogger<MyBooksPropertyEditorValueConverter> _logger;

    public MyBooksPropertyEditorValueConverter(
        IApiContentBuilder apiContentBuilder,
        IPublishedBookService publishedBookService,
        IJsonSerializer jsonSerializer,
        ILogger<MyBooksPropertyEditorValueConverter> logger)
    {
        _apiContentBuilder = apiContentBuilder;
        _publishedBookService = publishedBookService;
        _jsonSerializer = jsonSerializer;
        _logger = logger;
    }

    private IEnumerable<IPublishedContent> ConvertPropertyValueToBooks(object? propertyValue)
    {
        var propertyValueAsString = propertyValue?.ToString();
        if (propertyValueAsString.IsNullOrWhiteSpace())
        {
            return Enumerable.Empty<IPublishedContent>();
        }

        try
        {
            var isbn13Values = _jsonSerializer.Deserialize<long[]>(propertyValueAsString);
            return isbn13Values?.Select(_publishedBookService.Create).WhereNotNull()
                   ?? Enumerable.Empty<IPublishedContent>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Encountered an error while parsing the books property value");
            return Enumerable.Empty<IPublishedContent>();
        }
    }

    #region PropertyValueConverterBase implementation

    public override bool IsConverter(IPublishedPropertyType propertyType)
        => propertyType.EditorAlias.Equals("My.Books");

    public override PropertyCacheLevel GetPropertyCacheLevel(IPublishedPropertyType propertyType)
        => PropertyCacheLevel.Element;

    // NOTE: implementation is not strictly necessary for this demo
    public override Type GetPropertyValueType(IPublishedPropertyType propertyType)
        => typeof(IEnumerable<IPublishedContent>);

    // NOTE: implementation is not strictly necessary for this demo
    public override object? ConvertIntermediateToObject(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel referenceCacheLevel, object? inter, bool preview)
        => ConvertPropertyValueToBooks(inter);

    #endregion

    #region IDeliveryApiPropertyValueConverter implementation

    public PropertyCacheLevel GetDeliveryApiPropertyCacheLevel(IPublishedPropertyType propertyType)
        => PropertyCacheLevel.Element;

    public PropertyCacheLevel GetDeliveryApiPropertyCacheLevelForExpansion(IPublishedPropertyType propertyType)
        => PropertyCacheLevel.Snapshot;

    public Type GetDeliveryApiPropertyValueType(IPublishedPropertyType propertyType)
        => typeof(IEnumerable<IApiContent>);

    public object? ConvertIntermediateToDeliveryApiObject(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel referenceCacheLevel, object? inter, bool preview, bool expanding)
        => ConvertPropertyValueToBooks(inter).Select(_apiContentBuilder.Build).WhereNotNull().ToArray();

    #endregion
}
