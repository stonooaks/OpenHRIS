using EmpHRIS.Domain.AggregateModel.EmployeeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpHRIS.Infrastructure.EntityConfigurations
{
    class CodeEntityTypeConfiguration : IEntityTypeConfiguration<Code>
    {
        public void Configure(EntityTypeBuilder<Code> builder)
        {
            builder.ToTable("coder", EmployeeContext.DEFAULT_SCHEMA);

            builder.HasKey(a => a.Id);

            builder.Ignore(a => a.DomainEvents);

            builder.Property(b => b.Id)
                .ForSqlServerUseSequenceHiLo("codeseq", EmployeeContext.DEFAULT_SCHEMA);

            builder.Property<int>("CodeHeadId")
                .IsRequired();


            builder.Property<string>("Detail")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property<DateTime>("CreateDate")
                .IsRequired();

            builder.Property<DateTime>("UpdateDate")
                .IsRequired();

            builder.Property<int>("CreateBy")
                .IsRequired();

            builder.Property<int>("UpdateBy")
                .IsRequired();

            builder.HasOne(a => a.CodeHeader)
                .WithMany()
                .HasForeignKey("CodeHeaderId");
        }
    }
}
