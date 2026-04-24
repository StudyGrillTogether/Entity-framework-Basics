using Microsoft.EntityFrameworkCore;
using StudentManagementEF.Models;

namespace StudentManagementEF.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; } //db set added
    }
}
