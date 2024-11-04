﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupplyChainManagement.Db;

#nullable disable

namespace SupplyChainManagement.Migrations
{
    [DbContext(typeof(SCMDbContext))]
    partial class SCMDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SupplyChainManagement.Models.DeliveryUnit", b =>
                {
                    b.Property<long>("DeliveryUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DeliveryUnitId"));

                    b.Property<string>("DeliveryUnitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeliveryUnitId");

                    b.ToTable("DeliveryUnits");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.Merchandiser", b =>
                {
                    b.Property<long>("MerchandiserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("MerchandiserId"));

                    b.Property<string>("MerchandiserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MerchandiserId");

                    b.ToTable("Merchandisers");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.PRDetails", b =>
                {
                    b.Property<long>("PRDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PRDetailsId"));

                    b.Property<int>("ItemMasterID")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeadTime")
                        .HasColumnType("int");

                    b.Property<decimal>("PRQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("PurchaseRequisitionPRID")
                        .HasColumnType("bigint");

                    b.Property<string>("ShadeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UOM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PRDetailsId");

                    b.HasIndex("PurchaseRequisitionPRID");

                    b.ToTable("ItemDetails");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.PurchaseRequisition", b =>
                {
                    b.Property<long>("PRID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PRID"));

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeliveryUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PRDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PRNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requisitionar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Supplier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PRID");

                    b.ToTable("PurchaseRequisitions");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.Supplier", b =>
                {
                    b.Property<long>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SupplierId"));

                    b.Property<long>("SupplierName")
                        .HasColumnType("bigint");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.PRDetails", b =>
                {
                    b.HasOne("SupplyChainManagement.Models.PurchaseRequisition", null)
                        .WithMany("ItemDetails")
                        .HasForeignKey("PurchaseRequisitionPRID");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.PurchaseRequisition", b =>
                {
                    b.Navigation("ItemDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
