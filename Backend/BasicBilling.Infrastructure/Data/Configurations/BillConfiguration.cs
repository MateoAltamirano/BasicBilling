using System;
using BasicBilling.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicBilling.Infrastructure.Data.Configurations
{
	public class BillConfiguration : IEntityTypeConfiguration<Bill>
	{
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bill");

            builder.HasKey(b => b.Id);

            builder
            .Property(b => b.Id)
            .HasColumnName("id");

            builder
            .Property(b => b.Category)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("category");

            builder
            .Property(b => b.Period)
            .IsRequired()
            .HasColumnName("period");
        }
    }
}