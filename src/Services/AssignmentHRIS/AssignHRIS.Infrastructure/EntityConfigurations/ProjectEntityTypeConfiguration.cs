using EmpHRIS.Domain.AggregateModel.AccountAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpHRIS.Infrastructure.EntityConfigurations
{
    class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("project", AssignContext.DEFAULT_SCHEMA);

            builder.HasKey(a => a.Id);

            builder.Ignore(a => a.DomainEvents);

            builder.Property(b => b.Id)
                .ForSqlServerUseSequenceHiLo("projseq", AssignContext.DEFAULT_SCHEMA);

            builder.Property<string>("Code")
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property<string>("Year")
                .HasMaxLength(10)
                .HasDefaultValue("")
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

