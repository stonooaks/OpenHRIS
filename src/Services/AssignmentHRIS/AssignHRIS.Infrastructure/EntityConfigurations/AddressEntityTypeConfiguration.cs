using EmpHRIS.Domain.AggregateModel.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpHRIS.Infrastructure.EntityConfigurations
{
    class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address", AssignContext.DEFAULT_SCHEMA);

            builder.HasKey(a => a.Id);

            builder.Ignore(a => a.DomainEvents);

            builder.Property(b => b.Id)
                .ForSqlServerUseSequenceHiLo("addrseq", AssignContext.DEFAULT_SCHEMA);

            builder.Property<int>("EmployeeId")
                .IsRequired();

            builder.Property<string>("StreetAddress1")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property<string>("StreetAddress2")
                .HasMaxLength(100)
                .HasDefaultValue("")
                .IsRequired();

            builder.Property<string>("City")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property<string>("State")
                .HasMaxLength(3)
                .IsRequired();

            builder.Property<string>("Country")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property<string>("ZipCode")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property<DateTime>("CreateDate")
                .IsRequired();

            builder.Property<DateTime>("UpdateDate")
                .IsRequired();

            builder.Property<int>("CreateBy")
                .IsRequired();

            builder.Property<int>("UpdateBy")
                .IsRequired();

            builder.Property<bool>("IsHome")
                .HasDefaultValue(false)
                .IsRequired();
                    
        }
    }
}
