using System.Collections.ObjectModel;

namespace UsedBooks.Model;

public class Department
{
        public Department(){}
        public Department(string name)
        {
                Name = name;
                DepartmentBooks = new List<DepartmentsBooks>();
        }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        
        public List<DepartmentsBooks> DepartmentBooks { get; set; } = new List<DepartmentsBooks>();
        
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }


}