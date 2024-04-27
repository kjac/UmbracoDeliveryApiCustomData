using Site.Models.Published;

namespace Site.Services.Published;

public interface IPublishedBookService
{
    PublishedBook? Create(long isbn13);
}
