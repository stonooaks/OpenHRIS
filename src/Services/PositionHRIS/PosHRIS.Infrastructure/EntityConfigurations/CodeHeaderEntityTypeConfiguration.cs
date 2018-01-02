using EmpHRIS.Domain.AggregateModel.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpHRIS.Infrastructure.EntityConfigurations
{
    class CodeHeaderEntityTypeConfiguration : IEntityTypeConfiguration<CodeHeader>
    {
        public void Configure(EntityTypeBuilder<CodeHeader> builder)
        {
            builder.ToTable("codeheader", EmployeeContext.DEFAULT_SCHEMA);

            builder.HasKey(a => a.Id);

            builder.Ignore(a => a.DomainEvents);

            builder.Property(b => b.Id)
                .ForSqlServerUseSequenceHiLo("codeheadseq", EmployeeContext.DEFAULT_SCHEMA);

            builder.Property<int>("CodeHead")
                .IsRequired();

            builder.Property<DateTime>("CreateDate")
                .IsRequired();

            builder.Property<DateTime>("UpdateDate")
                .IsRequired();

            builder.Property<int>("CreateBy")
                .IsRequired();

            builder.Property<int>("UpdateBy")
                .IsRequired();
        }
    }
}
