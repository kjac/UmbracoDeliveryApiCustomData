using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Site.Models.Published;

public class PublishedBookContentType : IPublishedContentType
{
    public string Alias => "book";

    #region IPublishedContentType implementation not required for the Delivery API (at least not for this demo)

    public Guid Key => throw new NotImplementedException(nameof(Key));

    public int Id => throw new NotImplementedException(nameof(Id));

    public PublishedItemType ItemType => throw new NotImplementedException(nameof(ItemType));

    public HashSet<string> CompositionAliases => throw new NotImplementedException(nameof(CompositionAliases));

    public ContentVariation Variations => throw new NotImplementedException(nameof(Variations));

    public bool IsElement => throw new NotImplementedException(nameof(IsElement));

    public IEnumerable<IPublishedPropertyType> PropertyTypes => throw new NotImplementedException(nameof(PropertyTypes));

    public int GetPropertyIndex(string alias) => throw new NotImplementedException(nameof(GetPropertyIndex));

    public IPublishedPropertyType? GetPropertyType(string alias) => throw new NotImplementedException(nameof(GetPropertyType));

    public IPublishedPropertyType? GetPropertyType(int index) => throw new NotImplementedException(nameof(GetPropertyType));

    #endregion
}
