using System.Collections.ObjectModel;

namespace UsedBooks.Model;

public class Faculty
{
   
        
        public Faculty(){}
        public Faculty(string name)
        {
                Name = name;
                Departments = new List<Department>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        
        //Inplement a dropdown menu and track the Id and register it here.
        //the same for faculty
        public List<Department> Departments { get; set; }




}