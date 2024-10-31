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
    [Migration("20241030111945_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SupplyChainManagement.Models.deliveryUnit", b =>
                {
                    b.Property<long>("deliveryUnitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("deliveryUnitId"));

                    b.Property<string>("deliveryUnitName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("deliveryUnitId");

                    b.ToTable("deliveryUnits");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.itemDetails", b =>
                {
                    b.Property<long>("itemDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("itemDetailsId"));

                    b.Property<string>("itemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("purchaseRequisitionpr_id")
                        .HasColumnType("bigint");

                    b.HasKey("itemDetailsId");

                    b.HasIndex("purchaseRequisitionpr_id");

                    b.ToTable("itemDetails");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.merchandiser", b =>
                {
                    b.Property<long>("merchandiserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("merchandiserId"));

                    b.Property<string>("merchandiserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("merchandiserId");

                    b.ToTable("merchandisers");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.purchaseRequisition", b =>
                {
                    b.Property<long>("pr_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("pr_id"));

                    b.Property<long>("deliveryUnitId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("delivery_date")
                        .HasColumnType("datetime2");

                    b.Property<long>("merchandiserId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("pr_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("pr_no")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("supplierId")
                        .HasColumnType("bigint");

                    b.HasKey("pr_id");

                    b.HasIndex("deliveryUnitId");

                    b.HasIndex("merchandiserId");

                    b.HasIndex("supplierId");

                    b.ToTable("purchaseRequisitions");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.supplier", b =>
                {
                    b.Property<long>("supplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("supplierId"));

                    b.Property<string>("supplierName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("supplierId");

                    b.ToTable("suppliers");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.itemDetails", b =>
                {
                    b.HasOne("SupplyChainManagement.Models.purchaseRequisition", "purchaseRequisition")
                        .WithMany("itemDetails")
                        .HasForeignKey("purchaseRequisitionpr_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("purchaseRequisition");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.purchaseRequisition", b =>
                {
                    b.HasOne("SupplyChainManagement.Models.deliveryUnit", "deliveryUnit")
                        .WithMany()
                        .HasForeignKey("deliveryUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SupplyChainManagement.Models.merchandiser", "merchandiser")
                        .WithMany()
                        .HasForeignKey("merchandiserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SupplyChainManagement.Models.supplier", "supplier")
                        .WithMany()
                        .HasForeignKey("supplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("deliveryUnit");

                    b.Navigation("merchandiser");

                    b.Navigation("supplier");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.purchaseRequisition", b =>
                {
                    b.Navigation("itemDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
