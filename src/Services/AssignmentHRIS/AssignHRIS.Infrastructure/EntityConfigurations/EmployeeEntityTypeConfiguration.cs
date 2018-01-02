using EmpHRIS.Domain.AggregateModel.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EmpHRIS.Infrastructure.EntityConfigurations
{
    class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> employeeConfiguration)
        {
            employeeConfiguration.ToTable("employee", AssignContext.DEFAULT_SCHEMA);
            employeeConfiguration.HasKey(e => e.Id);
            employeeConfiguration.Ignore(e => e.DomainEvents);
            employeeConfiguration.Property(b => b.Id)
                .ForSqlServerUseSequenceHiLo("empseq", AssignContext.DEFAULT_SCHEMA);

            employeeConfiguration.HasMany(e => e.PersonAddresses);

            employeeConfiguration.Property<string>("EmpId")
                .HasMaxLength(10)
                .IsRequired();

            employeeConfiguration.Property<string>("LastName")
                .HasMaxLength(50)
                .IsRequired();

            employeeConfiguration.Property<string>("MiddleName")
                .HasMaxLength(50)
                .HasDefaultValue("")
                .IsRequired();

            employeeConfiguration.Property<string>("FirstName")
                .HasMaxLength(50)
                .IsRequired();

            employeeConfiguration.Property<string>("NationalId")
                .HasMaxLength(12)
                .IsRequired();

            employeeConfiguration.Property<DateTime>("BirthDate")
                .IsRequired();

            employeeConfiguration.Property<DateTime>("ServiceDate")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            employeeConfiguration.Property<DateTime>("CreateDate")
                .IsRequired();

            employeeConfiguration.Property<DateTime>("UpdateDate")
                .IsRequired();

            employeeConfiguration.Property<int>("CreateBy")
                .IsRequired();

            employeeConfiguration.Property<int>("UpdateBy")
                .IsRequired();


            employeeConfiguration
                .HasMany(e => e.Codes);

        }    
    }
}
