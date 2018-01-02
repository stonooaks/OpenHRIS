using EmpHRIS.Domain.AggregateModel.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpHRIS.Infrastructure.EntityConfigurations
{
    class EEOCodeEntityTypeConfiguration : IEntityTypeConfiguration<EEOCodes>
    {
        public void Configure(EntityTypeBuilder<EEOCodes> builder)
        {
            builder.ToTable("eeoCode", EmployeeContext.DEFAULT_SCHEMA);

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
