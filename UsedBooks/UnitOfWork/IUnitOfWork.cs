using UsedBooks.Repository.BookRepository;

namespace UsedBooks.UnitOfWork;

public interface IUnitOfWork
{
    IBookRepository _bookRepository { get; }
    Task CompletedAsync();
}