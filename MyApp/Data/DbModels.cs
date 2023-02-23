using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Data
{
    public class Employee
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage ="First name is required!!")]
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; }= default!;
        [Required(ErrorMessage = "Email is required!!")]
        public string Email { get; set; } = default!;
        public string Mobile { get; set; } = default!;
        public string Password { get; set; } = default!;

    }
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options):base(options) 
        { 

        }
        public DbSet<Employee> Employees { get; set; } = default!;
    }
}
