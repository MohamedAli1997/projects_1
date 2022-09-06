using evisa.api.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UsedBooks.Data;
using UsedBooks.Features.Book;
using UsedBooks.Features.User;
using UsedBooks.Model;
using UsedBooks.Repository.BookRepository;
using UsedBooks.UnitOfWork;

namespace UsedBooks.Controllers;

[Route("api/v1")]
public class BooksController:Controller
{
    private readonly IUnitOfWork _unitRepository;
    private readonly AppSettings _appSettings;
    private readonly UserManager<ApplicationUser> _userManager;
    public BooksController( IUnitOfWork unitRepository, IOptions<AppSettings> appSettings, UserManager<ApplicationUser> userManager)
    {
        _unitRepository = unitRepository;
        _userManager = userManager;
        _appSettings = appSettings.Value;
    }
    
    [HttpPost("Books/")]
    public async Task<IActionResult> Register([FromBody]Books books)
    {
        var owner = _userManager.FindByIdAsync(books.ApplicationUserId);
      
    
        
       _unitRepository._bookRepository.Register(books);
       await  _unitRepository.CompletedAsync();
        return Ok();
    }
    
}