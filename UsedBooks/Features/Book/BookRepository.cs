using UsedBooks.Data;
using UsedBooks.Model;

namespace UsedBooks.Repository.BookRepository;

public class BookRepository:IBookRepository
{

    public ApplicationDbContext _context;
    private readonly ILogger _logger;
    public BookRepository( ApplicationDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }
    public void  Register(Books book)
    {
          _context.Books.Add(book);
    }

    public DepartmentsBooks GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<DepartmentsBooks> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Update(DepartmentsBooks applicant)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
}