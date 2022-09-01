using evisa.api.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UsedBooks.Data;
using UsedBooks.Features.Book;
using UsedBooks.Features.User;
using UsedBooks.Model;
using UsedBooks.Repository.BookRepository;

namespace UsedBooks.Controllers;

[Route("api/v1")]
public class BooksController:Controller
{
    private readonly IBookRepository _booksRepository;
    private readonly AppSettings _appSettings;
    private readonly UserManager<ApplicationUser> _userManager;
    public BooksController( IBookRepository booksRepository,        IOptions<AppSettings> appSettings, UserManager<ApplicationUser> userManager)
    {
        _booksRepository = booksRepository;
        _userManager = userManager;
        _appSettings = appSettings.Value;
    }
    
    [HttpPost("Books/")]
    public IActionResult Register([FromBody] Books books)
    {
        Console.Write("Hello world !");
       _booksRepository.Register(books);
        return Ok();
    }
    
}