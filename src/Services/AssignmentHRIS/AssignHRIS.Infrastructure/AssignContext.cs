using System;
using System.Threading;
using System.Threading.Tasks;
using AssignHRIS.Domain.SeedWork;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EmpHRIS.Infrastructure
{
    public class AssignContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        private AssignContext(DbContextOptions<AssignContext> options)
               : base(options) { }

        public AssignContext(DbContextOptions<AssignContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            System.Diagnostics.Debug.WriteLine("EmployeeContext::ctor ->" + this.GetHashCode());
        }

        public const string DEFAULT_SCHEMA = "employee";
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
        public DbSet<CostCenter> CostCenter { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Reporting> Reporting { get; set; }
        public DbSet<Entity> Entity { get; set; }
        public DbSet<SHACode> SHAcode { get; set; }
        public DbSet<CensusCode> CensusCode { get; set; }
        public DbSet<Employment> Employment { get; set; }
        public DbSet<EmpStatus> EmpStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
            builder.ApplyConfiguration(new AddressEntityTypeConfiguration());
            builder.ApplyConfiguration(new CodeEntityTypeConfiguration());
            builder.ApplyConfiguration(new CodeHeaderEntityTypeConfiguration());
            builder.ApplyConfiguration(new AccountEntityTypeConfiguration());
            builder.ApplyConfiguration(new EntityEntityTypeConfiguration());
            builder.ApplyConfiguration(new ProjectEntityTypeConfiguration());
            builder.ApplyConfiguration(new ReportingEntityTypeConfiguration());
            builder.ApplyConfiguration(new CostCenterEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //await _mediator.DispatchDomainEventsAsync(this);

            var result = await base.SaveChangesAsync();

            return true;
        }
    }

    public class EmployeeContextDesignFactory : IDesignTimeDbContextFactory<AssignContext>
    {
        public AssignContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AssignContext>()
                .UseSqlServer("");

            return new AssignContext(optionsBuilder.Options,new NoMediator());
        }
    
        class NoMediator : IMediator
        {
            Task IMediator.Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default(CancellationToken))
            {
                return Task.CompletedTask;
            }

            Task<TResponse> IMediator.Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
            {
                return Task.FromResult<TResponse>(default(TResponse));
            }

            Task IMediator.Send(IRequest request, CancellationToken cancellationToken = default(CancellationToken))
            {
                return Task.CompletedTask;
            }
        }
    }
}
