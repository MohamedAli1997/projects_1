namespace UsedBooks.Features.Book;

public class BooksDao
{


    public int Id { get; set; }


    public string Title { get; set; }


    public string Summary { get; set; }

    public string Posted { get; set; } = DateTime.Now.ToString("g") /*("dd.MM.yyyy")*/;


    public decimal Price { get; set; }

    public string Description { get; set; }
// image variable


    public string ImageUrl { get; set; }

/**/
    public byte[] Content { get; set; }
}