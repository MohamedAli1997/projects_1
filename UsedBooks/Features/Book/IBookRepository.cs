using UsedBooks.Model;

namespace UsedBooks.Repository.BookRepository;

public interface IBookRepository
{
    public void Register(Books applicant);
    public DepartmentsBooks GetById(int id);
    public IEnumerable<DepartmentsBooks> GetAll();
    public void Update(DepartmentsBooks applicant);
    public void Delete(int id);
}