using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UsedBooks.Features.User;
using UsedBooks.Model;

namespace UsedBooks.Data;

public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public  DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Books> Books { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<DepartmentsBooks> DepartmentBooks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<DepartmentsBooks>()
            .HasKey(db => new {db.BookId , db.DepartmentId });
    }


}