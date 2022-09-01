namespace UsedBooks.Model;

public class DepartmentsBooks
{
    
    public int DepartmentId { get; set; }
    public Department Department { get; set; }
        
    public int BookId { get; set; }
    public Books Books { get; set; }

}