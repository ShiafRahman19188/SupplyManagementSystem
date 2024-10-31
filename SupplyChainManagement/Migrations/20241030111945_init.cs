using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyChainManagement.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "deliveryUnits",
                columns: table => new
                {
                    deliveryUnitId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deliveryUnitName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveryUnits", x => x.deliveryUnitId);
                });

            migrationBuilder.CreateTable(
                name: "merchandisers",
                columns: table => new
                {
                    merchandiserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    merchandiserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_merchandisers", x => x.merchandiserId);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    supplierId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplierName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.supplierId);
                });

            migrationBuilder.CreateTable(
                name: "purchaseRequisitions",
                columns: table => new
                {
                    pr_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pr_no = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pr_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    delivery_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    merchandiserId = table.Column<long>(type: "bigint", nullable: false),
                    supplierId = table.Column<long>(type: "bigint", nullable: false),
                    deliveryUnitId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseRequisitions", x => x.pr_id);
                    table.ForeignKey(
                        name: "FK_purchaseRequisitions_deliveryUnits_deliveryUnitId",
                        column: x => x.deliveryUnitId,
                        principalTable: "deliveryUnits",
                        principalColumn: "deliveryUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchaseRequisitions_merchandisers_merchandiserId",
                        column: x => x.merchandiserId,
                        principalTable: "merchandisers",
                        principalColumn: "merchandiserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchaseRequisitions_suppliers_supplierId",
                        column: x => x.supplierId,
                        principalTable: "suppliers",
                        principalColumn: "supplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "itemDetails",
                columns: table => new
                {
                    itemDetailsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    purchaseRequisitionpr_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemDetails", x => x.itemDetailsId);
                    table.ForeignKey(
                        name: "FK_itemDetails_purchaseRequisitions_purchaseRequisitionpr_id",
                        column: x => x.purchaseRequisitionpr_id,
                        principalTable: "purchaseRequisitions",
                        principalColumn: "pr_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_itemDetails_purchaseRequisitionpr_id",
                table: "itemDetails",
                column: "purchaseRequisitionpr_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseRequisitions_deliveryUnitId",
                table: "purchaseRequisitions",
                column: "deliveryUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseRequisitions_merchandiserId",
                table: "purchaseRequisitions",
                column: "merchandiserId");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseRequisitions_supplierId",
                table: "purchaseRequisitions",
                column: "supplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itemDetails");

            migrationBuilder.DropTable(
                name: "purchaseRequisitions");

            migrationBuilder.DropTable(
                name: "deliveryUnits");

            migrationBuilder.DropTable(
                name: "merchandisers");

            migrationBuilder.DropTable(
                name: "suppliers");
        }
    }
}
