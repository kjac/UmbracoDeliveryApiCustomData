using Site.Models;

namespace Site.Services;

public interface IBookService
{
    Book? GetByIsbn13(long isbn13);
}