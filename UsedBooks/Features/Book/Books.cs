using System.Collections.ObjectModel;
using UsedBooks.Features.User;

namespace UsedBooks.Model;

public class Books
{
   
    public int Id { get; set; }
        
    
    public string Title { get; set; }
        
    
    public string Summary { get; set; }

    public string Posted { get; set; } = DateTime.Now.ToString("g")/*("dd.MM.yyyy")*/;

    
    public decimal Price { get; set; }

    public string Description { get; set; }
    // image variable

   
    public string ImageUrl { get; set; }
         
      /**/
  
    //owner
    public ApplicationUser ApplicationUser { get; set; }
       
    public string ApplicationUserId { get; set; }
        
    public  Department Department { get; set; }
       
    public  int DepartmentId { get; set; }
    // Departments this book belongs
    public ICollection<DepartmentsBooks> DepartmentsBooks { get; set; }

}