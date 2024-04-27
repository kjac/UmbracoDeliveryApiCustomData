using Umbraco.Cms.Core.Models.PublishedContent;

namespace Site.Models.Published;

public class PublishedBookProperty : IPublishedProperty
{
    private readonly object? _value;

    public PublishedBookProperty(string alias, object? value)
    {
        _value = value;
        Alias = alias;
    }

    public string Alias { get; }

    public bool HasValue(string? culture = null, string? segment = null) => _value is not null;

    public object? GetSourceValue(string? culture = null, string? segment = null) => _value;

    public object? GetValue(string? culture = null, string? segment = null) => _value;

    public object? GetDeliveryApiValue(bool expanding, string? culture = null, string? segment = null) => _value;

    #region IPublishedProperty implementation not required for the Delivery API (at least not for this demo)

    public IPublishedPropertyType PropertyType => throw new NotImplementedException(nameof(PropertyType));

    public object? GetXPathValue(string? culture = null, string? segment = null) => throw new NotImplementedException(nameof(GetXPathValue));

    #endregion
}
