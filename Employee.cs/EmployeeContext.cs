using Microsoft.EntityFrameworkCore;

namespace EmpHRIS.Entities
{
    public class EmployeeContext : DbContext
    {

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
               : base(options) { }

        public DbSet<Person> Person { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<CodeHeader> CodeHeaders { get; set; }
        public DbSet<CodeDetail> CodeDetails { get; set; }
    }
}
