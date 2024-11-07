﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupplyChainManagement.Db;

#nullable disable

namespace SupplyChainManagement.Migrations
{
    [DbContext(typeof(SCMDbContext))]
    [Migration("20241106053617_SubGroupModified")]
    partial class SubGroupModified
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("SupplyChainManagement.Models.ItemGroup", b =>
                {
                    b.Property<int>("ItemGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemGroupId"));

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemGroupId");

                    b.ToTable("ItemGroups");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.ItemMaster", b =>
                {
                    b.Property<int>("ItemMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemMasterId"));

                    b.Property<string>("DisplayItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemGroupId")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemSubGroupId")
                        .HasColumnType("int");

                    b.HasKey("ItemMasterId");

                    b.HasIndex("ItemGroupId");

                    b.HasIndex("ItemSubGroupId");

                    b.ToTable("ItemMasters");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.ItemSubGroup", b =>
                {
                    b.Property<int>("ItemSubGroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemSubGroupId"));

                    b.Property<string>("SubGroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ItemSubGroupId");

                    b.ToTable("ItemSubGroups");
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

                    b.Property<long?>("PurchaseRequisitionPRID1")
                        .HasColumnType("bigint");

                    b.Property<string>("ShadeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UOM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("YBookingNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PRDetailsId");

                    b.HasIndex("PurchaseRequisitionPRID");

                    b.HasIndex("PurchaseRequisitionPRID1");

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

                    b.Property<string>("ContactDisplayCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.Yarn", b =>
                {
                    b.Property<int>("YarnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("YarnId"));

                    b.Property<string>("HSCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YarnCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YarnShade")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("YarnId");

                    b.ToTable("Yarns");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.ItemMaster", b =>
                {
                    b.HasOne("SupplyChainManagement.Models.ItemGroup", "ItemGroup")
                        .WithMany()
                        .HasForeignKey("ItemGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SupplyChainManagement.Models.ItemSubGroup", "ItemSubGroup")
                        .WithMany()
                        .HasForeignKey("ItemSubGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemGroup");

                    b.Navigation("ItemSubGroup");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.PRDetails", b =>
                {
                    b.HasOne("SupplyChainManagement.Models.PurchaseRequisition", "PurchaseRequisition")
                        .WithMany()
                        .HasForeignKey("PurchaseRequisitionPRID");

                    b.HasOne("SupplyChainManagement.Models.PurchaseRequisition", null)
                        .WithMany("ItemDetails")
                        .HasForeignKey("PurchaseRequisitionPRID1");

                    b.Navigation("PurchaseRequisition");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.PurchaseRequisition", b =>
                {
                    b.Navigation("ItemDetails");
                });
#pragma warning restore 612, 618
        }
    }
}