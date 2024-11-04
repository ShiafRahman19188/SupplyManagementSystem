using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyChainManagement.Migrations
{
    /// <inheritdoc />
    public partial class initialdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryUnits",
                columns: table => new
                {
                    DeliveryUnitId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryUnitName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryUnits", x => x.DeliveryUnitId);
                });

            migrationBuilder.CreateTable(
                name: "Merchandisers",
                columns: table => new
                {
                    MerchandiserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MerchandiserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merchandisers", x => x.MerchandiserId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseRequisitions",
                columns: table => new
                {
                    PRID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MerchandiserID = table.Column<long>(type: "bigint", nullable: false),
                    SupplierId = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryUnitId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequisitions", x => x.PRID);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitions_DeliveryUnits_DeliveryUnitId",
                        column: x => x.DeliveryUnitId,
                        principalTable: "DeliveryUnits",
                        principalColumn: "DeliveryUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitions_Merchandisers_MerchandiserID",
                        column: x => x.MerchandiserID,
                        principalTable: "Merchandisers",
                        principalColumn: "MerchandiserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequisitions_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemDetails",
                columns: table => new
                {
                    ItemDetailsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseRequisitionPRID = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDetails", x => x.ItemDetailsId);
                    table.ForeignKey(
                        name: "FK_ItemDetails_PurchaseRequisitions_PurchaseRequisitionPRID",
                        column: x => x.PurchaseRequisitionPRID,
                        principalTable: "PurchaseRequisitions",
                        principalColumn: "PRID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetails_PurchaseRequisitionPRID",
                table: "ItemDetails",
                column: "PurchaseRequisitionPRID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitions_DeliveryUnitId",
                table: "PurchaseRequisitions",
                column: "DeliveryUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitions_MerchandiserID",
                table: "PurchaseRequisitions",
                column: "MerchandiserID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequisitions_SupplierId",
                table: "PurchaseRequisitions",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDetails");

            migrationBuilder.DropTable(
                name: "PurchaseRequisitions");

            migrationBuilder.DropTable(
                name: "DeliveryUnits");

            migrationBuilder.DropTable(
                name: "Merchandisers");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
