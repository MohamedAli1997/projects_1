using UsedBooks.Data;
using UsedBooks.Model;

namespace UsedBooks.Repository.BookRepository;

public class BookRepository:IBookRepository
{

    private readonly ApplicationDbContext _context;
    public BookRepository( ApplicationDbContext context)
    {
        _context = context;
    }
    public void Register(Books applicant)
    {
       
        
        _context.Books.Add(applicant);
        _context.SaveChanges();
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