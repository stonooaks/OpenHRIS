using EmpHRIS.Domain.AggregateModel.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpHRIS.Infrastructure.EntityConfigurations
{
    class GenderEntityTypeConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("gender", EmployeeContext.DEFAULT_SCHEMA);

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property<string>("Name")
                .HasMaxLength(100)
                .IsRequired();

            
        }
    }
}
