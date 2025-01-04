namespace Lesson_5;

public class BookCollection
{
    private List<Book> _books;

    public BookCollection()
    {
        _books = new List<Book>();
    }

    public Book AddBook(Book newBook)
    {
        _books.Add(newBook);

        return newBook;
    }
    public List<Book> GetBookByAuthor(string Author)
    {
        var booksByAuthor = new List<Book>();
        foreach (var book in _books)
        {
            if (book.Author == Author)
            {
                booksByAuthor.Add(book);
            }
        }
        return booksByAuthor;
    }

}


