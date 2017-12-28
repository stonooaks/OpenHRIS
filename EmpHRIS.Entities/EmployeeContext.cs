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
        public DbSet<Distribution> Distribution { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<PosClass> PosClass { get; set; }
        public DbSet<WorkComp> WorkComp { get; set; }
        public DbSet<WorkPeriod> WorkPeriod { get; set; }
        public DbSet<OvertimeStatus> Overtime { get; set; }
        public DbSet<SalaryChange> SalaryChange { get; set; }
        public DbSet<SalaryStruct> SalaryStruct { get; set; }
        public DbSet<PayGrade> PayGrade { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Reporting> Reporting { get; set; }
        public DbSet<Entity> Entity { get; set; }
        public DbSet<SHACode> SHAcode { get; set; }
        public DbSet<CensusCode> CensusCode { get; set; }
        public DbSet<Employment> Employment { get; set; }
        public DbSet<EmpStatus> EmpStatus { get; set; }
    }
}
