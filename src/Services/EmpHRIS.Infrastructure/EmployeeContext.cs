using System;
using System.Threading;
using System.Threading.Tasks;
using empHRIS.Domain.SeedWork;
using EmpHRIS.Domain.AggregateModel.AssignmentAggregate;
using EmpHRIS.Domain.AggregateModel.EmployeeAggregate;
using EmpHRIS.Domain.AggregateModel.EmploymentAggregate;
using EmpHRIS.Domain.AggregateModel.PositionAggregate;
using EmpHRIS.Domain.AggregateModel.StatusAggregate;
using EmpHRIS.Domain.AggregateModel.AccountAggregate;
using EmpHRIS.Infrastructure.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EmpHRIS.Infrastructure
{
    public class EmployeeContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        private EmployeeContext(DbContextOptions<EmployeeContext> options)
               : base(options) { }

        public EmployeeContext(DbContextOptions<EmployeeContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

            System.Diagnostics.Debug.WriteLine("EmployeeContext::ctor ->" + this.GetHashCode());
        }

        public const string DEFAULT_SCHEMA = "employee";
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<CodeHeader> CodeHeaders { get; set; }
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
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            //await _mediator.DispatchDomainEventsAsync(this);

            var result = await base.SaveChangesAsync();

            return true;
        }
    }

    public class EmployeeContextDesignFactory : IDesignTimeDbContextFactory<EmployeeContext>
    {
        public EmployeeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeContext>()
                .UseSqlServer("");

            return new EmployeeContext(optionsBuilder.Options,new NoMediator());
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
