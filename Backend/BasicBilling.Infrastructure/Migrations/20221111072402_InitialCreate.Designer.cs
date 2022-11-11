﻿// <auto-generated />
using BasicBilling.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BasicBilling.Infrastructure.Migrations
{
    [DbContext(typeof(BasicBillingContext))]
    [Migration("20221111072402_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("BasicBilling.Core.Entities.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("category");

                    b.Property<int>("Period")
                        .HasColumnType("INTEGER")
                        .HasColumnName("period");

                    b.HasKey("Id");

                    b.ToTable("Bill", (string)null);
                });

            modelBuilder.Entity("BasicBilling.Core.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("BasicBilling.Core.Entities.ClientBill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("BillId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("billId");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("clientId");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue("Pending")
                        .HasColumnName("status");

                    b.HasKey("Id");

                    b.HasIndex("BillId");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientBill", (string)null);
                });

            modelBuilder.Entity("BasicBilling.Core.Entities.ClientBill", b =>
                {
                    b.HasOne("BasicBilling.Core.Entities.Bill", "Bill")
                        .WithMany("ClientBills")
                        .HasForeignKey("BillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ClientBill_Bill");

                    b.HasOne("BasicBilling.Core.Entities.Client", "Client")
                        .WithMany("Bills")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ClientBill_Client");

                    b.Navigation("Bill");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("BasicBilling.Core.Entities.Bill", b =>
                {
                    b.Navigation("ClientBills");
                });

            modelBuilder.Entity("BasicBilling.Core.Entities.Client", b =>
                {
                    b.Navigation("Bills");
                });
#pragma warning restore 612, 618
        }
    }
}