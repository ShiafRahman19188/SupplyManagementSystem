using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyChainManagement.Migrations
{
    /// <inheritdoc />
    public partial class poModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemPODetail",
                columns: table => new
                {
                    YPOChildID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YPOMasterID = table.Column<int>(type: "int", nullable: false),
                    ItemMasterID = table.Column<int>(type: "int", nullable: false),
                    UnitName = table.Column<int>(type: "int", nullable: false),
                    PoQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PIValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    YarnLotNo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    HSCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    YarnShade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BookingNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReceivedCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPODetail", x => x.YPOChildID);
                });

            migrationBuilder.CreateTable(
                name: "ItemPOMaster",
                columns: table => new
                {
                    YPOMasterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PONo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PODate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Charges = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransShipmentAllow = table.Column<bool>(type: "bit", nullable: false),
                    ShippingTolerance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PortofLoading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortofDischarge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipmentMode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    ApprovedBy = table.Column<int>(type: "int", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AddedBy = table.Column<int>(type: "int", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    QuotationRefNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    QuotationRefDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupplierAcknowledge = table.Column<bool>(type: "bit", nullable: false),
                    SupplierAcknowledgeBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierAcknowledgeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupplierReject = table.Column<bool>(type: "bit", nullable: false),
                    SupplierRejectBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierRejectReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPOMaster", x => x.YPOMasterID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPODetail");

            migrationBuilder.DropTable(
                name: "ItemPOMaster");
        }
    }
}
