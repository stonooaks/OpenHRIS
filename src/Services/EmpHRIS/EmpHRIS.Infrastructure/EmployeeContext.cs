using System;
using System.Threading;
using System.Threading.Tasks;
using empHRIS.Domain.SeedWork;
using EmpHRIS.Domain.AggregateModel.EmployeeAggregate;
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
        public DbSet<Gender> Gender { get; set; }
        public DbSet<EEOCodes> EEOCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
            builder.ApplyConfiguration(new AddressEntityTypeConfiguration());
            builder.ApplyConfiguration(new GenderEntityTypeConfiguration());
            builder.ApplyConfiguration(new EEOCodeEntityTypeConfiguration());
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
