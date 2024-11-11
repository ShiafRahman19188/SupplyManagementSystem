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
    [Migration("20241111085733_hgg")]
    partial class hgg
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SupplyChainManagement.Models.BookingChild", b =>
                {
                    b.Property<int>("BookingChildId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingChildId"));

                    b.Property<int>("BookingMasterId")
                        .HasColumnType("int");

                    b.Property<int>("ItemMasterId")
                        .HasColumnType("int");

                    b.HasKey("BookingChildId");

                    b.HasIndex("BookingMasterId");

                    b.HasIndex("ItemMasterId");

                    b.ToTable("BookingChild");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.BookingMaster", b =>
                {
                    b.Property<int>("BookingMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingMasterId"));

                    b.Property<string>("BookingMasterNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExportWorkOrder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StyleNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("SupplierId")
                        .HasColumnType("bigint");

                    b.HasKey("BookingMasterId");

                    b.HasIndex("SupplierId");

                    b.ToTable("BookingMasters");
                });

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

            modelBuilder.Entity("SupplyChainManagement.Models.FabricYarn", b =>
                {
                    b.Property<int>("FabricYarnId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FabricYarnId"));

                    b.Property<int>("FabricId")
                        .HasColumnType("int");

                    b.Property<int>("YarnId")
                        .HasColumnType("int");

                    b.HasKey("FabricYarnId");

                    b.ToTable("FabricYarns");
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

            modelBuilder.Entity("SupplyChainManagement.Models.PurchaseRequisitionMaster", b =>
                {
                    b.Property<int>("PurchaseRequisitionMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PurchaseRequisitionMasterId"));

                    b.Property<int>("ItemYarnId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PRDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PRNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("YarnBookingMasterId")
                        .HasColumnType("int");

                    b.HasKey("PurchaseRequisitionMasterId");

                    b.ToTable("PurchaseRequisitionMasters");
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

            modelBuilder.Entity("SupplyChainManagement.Models.YarnBookingChild", b =>
                {
                    b.Property<int>("YarnBookingChildId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("YarnBookingChildId"));

                    b.Property<int>("ItemMasterId")
                        .HasColumnType("int");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<int>("YarnBookingMasterId")
                        .HasColumnType("int");

                    b.HasKey("YarnBookingChildId");

                    b.HasIndex("YarnBookingMasterId");

                    b.ToTable("YarnBookingChilds");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.YarnBookingMaster", b =>
                {
                    b.Property<int>("YarnBookingMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("YarnBookingMasterId"));

                    b.Property<int>("IsAcknowledge")
                        .HasColumnType("int");

                    b.Property<string>("YarnBookingMasterNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("YarnBookingMasterId");

                    b.ToTable("YarnBookingMasters");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.YarnPOChild", b =>
                {
                    b.Property<int>("YPOChildID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("YPOChildID"));

                    b.Property<string>("BookingNo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("HSCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ItemMasterID")
                        .HasColumnType("int");

                    b.Property<decimal>("PIValue")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("PoQty")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("ReceivedCompleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ReceivedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Remarks")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("UnitName")
                        .HasColumnType("int");

                    b.Property<int>("YPOMasterID")
                        .HasColumnType("int");

                    b.Property<string>("YarnLotNo")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int?>("YarnPOMasterYPOMasterID")
                        .HasColumnType("int");

                    b.Property<string>("YarnShade")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("YPOChildID");

                    b.HasIndex("YarnPOMasterYPOMasterID");

                    b.ToTable("ItemPODetail");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.YarnPOMaster", b =>
                {
                    b.Property<int>("YPOMasterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("YPOMasterID"));

                    b.Property<int>("AddedBy")
                        .HasColumnType("int");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<int>("ApprovedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ApprovedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Charges")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryOfOrigin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeliveryEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeliveryStartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PODate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PONo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PortofDischarge")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PortofLoading")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("QuotationRefDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("QuotationRefNo")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Remarks")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ShipmentMode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ShippingTolerance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("SupplierAcknowledge")
                        .HasColumnType("bit");

                    b.Property<string>("SupplierAcknowledgeBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SupplierAcknowledgeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SupplierReject")
                        .HasColumnType("bit");

                    b.Property<string>("SupplierRejectBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierRejectReason")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("TransShipmentAllow")
                        .HasColumnType("bit");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("YPOMasterID");

                    b.ToTable("ItemPOMaster");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.BookingChild", b =>
                {
                    b.HasOne("SupplyChainManagement.Models.BookingMaster", "BookingMaster")
                        .WithMany("BookingChild")
                        .HasForeignKey("BookingMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SupplyChainManagement.Models.ItemMaster", "ItemMaster")
                        .WithMany()
                        .HasForeignKey("ItemMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingMaster");

                    b.Navigation("ItemMaster");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.BookingMaster", b =>
                {
                    b.HasOne("SupplyChainManagement.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
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

            modelBuilder.Entity("SupplyChainManagement.Models.YarnBookingChild", b =>
                {
                    b.HasOne("SupplyChainManagement.Models.YarnBookingMaster", "YarnBookingMaster")
                        .WithMany("yarnBookingChildren")
                        .HasForeignKey("YarnBookingMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("YarnBookingMaster");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.YarnPOChild", b =>
                {
                    b.HasOne("SupplyChainManagement.Models.YarnPOMaster", null)
                        .WithMany("ItemDetails")
                        .HasForeignKey("YarnPOMasterYPOMasterID");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.BookingMaster", b =>
                {
                    b.Navigation("BookingChild");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.PurchaseRequisition", b =>
                {
                    b.Navigation("ItemDetails");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.YarnBookingMaster", b =>
                {
                    b.Navigation("yarnBookingChildren");
                });

            modelBuilder.Entity("SupplyChainManagement.Models.YarnPOMaster", b =>
                {
                    b.Navigation("ItemDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
