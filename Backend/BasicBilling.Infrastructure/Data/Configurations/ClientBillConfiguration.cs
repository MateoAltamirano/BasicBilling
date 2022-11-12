using System;
using BasicBilling.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasicBilling.Infrastructure.Data.Configurations
{
	public class ClientBillConfiguration : IEntityTypeConfiguration<ClientBill>
    {
        public void Configure(EntityTypeBuilder<ClientBill> builder)
        {
            builder.ToTable("ClientBill");

            builder.HasKey(c => c.Id);

            builder
            .Property(c => c.Id)
            .HasColumnName("id");

            builder
            .Property(c => c.Status)
            .HasDefaultValue(BillStatus.Pending)
            .HasColumnName("status")
            .HasConversion<string>();

            builder
            .HasOne(c => c.Client)
            .WithMany(c => c.Bills)
            .HasForeignKey(c => c.ClientId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_ClientBill_Client");

            builder.Property(c => c.ClientId).HasColumnName("clientId");

            builder
            .HasOne(c => c.Bill)
            .WithMany(c => c.ClientBills)
            .HasForeignKey(c => c.BillId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_ClientBill_Bill");

            builder.Property(c => c.BillId).HasColumnName("billId");
        }
    }
}