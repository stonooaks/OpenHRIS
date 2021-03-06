﻿using EmpHRIS.Domain.AggregateModel.AccountAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmpHRIS.Infrastructure.EntityConfigurations
{
    class ReportingEntityTypeConfiguration : IEntityTypeConfiguration<Reporting>
    {
        public void Configure(EntityTypeBuilder<Reporting> builder)
        {
            builder.ToTable("reporting", AssignContext.DEFAULT_SCHEMA);

            builder.HasKey(a => a.Id);

            builder.Ignore(a => a.DomainEvents);

            builder.Property(b => b.Id)
                .ForSqlServerUseSequenceHiLo("reptseq", AssignContext.DEFAULT_SCHEMA);

            builder.Property<string>("Code")
                    .HasMaxLength(100)
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

