using Site.Models;

namespace Site.Services;

public class BookService : IBookService
{
    private readonly Book[] _books =
    [
        new Book
        {
            Id = Guid.Parse("5FF9012D-DB72-4BE9-9AD0-6FB35E404535"),
            Isbn13 = 9781401310301,
            Author = "Eoin Colfer",
            Summary = """
                      And Another Thing... is the sixth novel in the increasingly inaccurately named Hitchhiker’s Guide to the Galaxy trilogy.
                      Eight years after the death of its creator, Douglas Adams, widow Jane Belson sanctioned the project to be written by the international number-one bestselling children’s writer Eoin Colfer, author of the Artemis Fowl novels.
                      Belson said of Eoin Colfer, “I love his books and could not think of a better person to transport Arthur, Zaphod, and Marvin to pastures new.”
                      Colfer, a fan of Hitchhiker since his school days, said, “Being given the chance to write this book is like suddenly being offered the superpower of your choice. For years I have been finishing this incredible story in my head and now I have the opportunity to do it in the real world.” Prepare to be amazed...
                      """,
            Title = "And Another Thing...",
            PublishDate = new DateTime(2009, 10, 12)
        },
        new Book
        {
            Id = Guid.Parse("552923F6-F7B4-4545-AA8E-7BCB047F506C"),
            Isbn13 = 9780552137034,
            Author = "Terry Pratchett",
            Summary = """
                      “Armageddon only happens once, you know. They don’t let you go around again until you get it right.”
                      According to the Nice and Accurate Prophecies of Agnes Nutter, Witch – the world’s only totally reliable guide to the future, written in 1655, before she exploded – the world will end on a Saturday. Next Saturday, in fact. Just after tea…
                      People have been predicting the end of the world almost from its very beginning, so it’s only natural to be sceptical when a new date is set for Judgement Day. This time though, the armies of Good and Evil really do appear to be massing. The four Bikers of the Apocalypse are hitting the road. But both the angels and demons – well, one fast-living demon and a somewhat fussy angel – would quite like the Rapture not to happen.
                      And someone seems to have misplaced the Antichrist...
                      """,
            Title = "Good Omens",
            PublishDate = new DateTime(1990, 05, 10)
        },
        new Book
        {
            Id = Guid.Parse("7DB405AC-2349-4C25-A956-5CA0020862F1"),
            Isbn13 = 9780553575385,
            Author = "Connie Willis",
            Summary = """
                      Ned Henry is badly in need of a rest. He’s been shuttling between the twenty-first century and the 1940s in search of a hideous Victorian vase called “the bishop’s bird stump” as part of a project to restore the famed Coventry Cathedral, destroyed in an air raid.
                      But then Verity Kindle, a fellow time traveler, inadvertently brings back something from the past. Now Ned must jump to the Victorian era to help Verity put things right—not only to save the project but also to prevent altering history itself.
                      """,
            Title = "To Say Nothing of the Dog",
            PublishDate = new DateTime(1997, 12, 01)
        }
    ];

    public Book? GetByIsbn13(long isbn13) => _books.FirstOrDefault(book => book.Isbn13 == isbn13);
}