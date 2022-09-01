using Microsoft.AspNetCore.Identity;
using UsedBooks.Model;

namespace UsedBooks.Features.User;

public class ApplicationUser:IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public ICollection<Books> UserBooks { get; set; }
    public string Role { get; set; }

}