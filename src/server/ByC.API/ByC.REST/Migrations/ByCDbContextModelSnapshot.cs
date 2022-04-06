﻿// <auto-generated />
using System;
using ByC.REST.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ByC.REST.Migrations
{
    [DbContext(typeof(ByCDbContext))]
    partial class ByCDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ByC.Domain.Transactions.Entities.CnabRoot", b =>
                {
                    b.Property<string>("Value")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Value");

                    b.ToTable("Cnabs");
                });

            modelBuilder.Entity("ByC.Domain.Transactions.Entities.TransactionRoot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Card")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("CnabId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<TimeSpan?>("Hour")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("time(6)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("varchar(18)");

                    b.Property<string>("StoreOwnerName")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<int?>("Type")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("int");

                    b.Property<decimal?>("Value")
                        .IsRequired()
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.HasKey("Id");

                    b.HasIndex("CnabId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("ByC.Domain.Transactions.Entities.TransactionRoot", b =>
                {
                    b.HasOne("ByC.Domain.Transactions.Entities.CnabRoot", "Cnab")
                        .WithMany("TransactionRoots")
                        .HasForeignKey("CnabId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Cnab");
                });

            modelBuilder.Entity("ByC.Domain.Transactions.Entities.CnabRoot", b =>
                {
                    b.Navigation("TransactionRoots");
                });
#pragma warning restore 612, 618
        }
    }
}
