using UsedBooks.Repository.BookRepository;
using UsedBooks.UnitOfWork;

namespace UsedBooks.Data;

public class UnitOfWork :IUnitOfWork, IDisposable
{
    public IBookRepository _bookRepository { get; }
    private readonly ILogger _logger;
    public ApplicationDbContext _context;
 
    public UnitOfWork(ApplicationDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        _logger = loggerFactory.CreateLogger("logs");
        _bookRepository = new BookRepository(_context,_logger);
    }


 

    public async  Task CompletedAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}