using EmpHRIS.Domain.AggregateModel.AccountAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpHRIS.Infrastructure.EntityConfigurations
{
    class AccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("account", AssignContext.DEFAULT_SCHEMA);

            builder.HasKey(a => a.Id);

            builder.Ignore(a => a.DomainEvents);

            builder.Property(b => b.Id)
                .ForSqlServerUseSequenceHiLo("acctseq", AssignContext.DEFAULT_SCHEMA);

            builder.Property<string>("AccountNumber")
                    .HasMaxLength(100)
                    .IsRequired();

            builder.Property<int>("CostCenterId")
                    .HasMaxLength(100)
                    .HasDefaultValue("")
                    .IsRequired();

            builder.Property<int>("EntityId")
                    .HasMaxLength(50)
                    .IsRequired();

            builder.Property<string>("ProjectId")
                    .HasMaxLength(3)
                    .IsRequired();

            builder.Property<string>("ReportingId")
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

            builder.HasOne(a => a.CostCenter)
                .WithMany()
                .HasForeignKey("CostCenterId");

            builder.HasOne(a => a.Project)
                .WithMany()
                .HasForeignKey("ProjectId");

            builder.HasOne(a => a.Reporting)
                .WithMany()
                .HasForeignKey("ReportingId");

            builder.HasOne(a => a.Entity)
                .WithMany()
                .HasForeignKey("EntityId");
        }
    }
}

