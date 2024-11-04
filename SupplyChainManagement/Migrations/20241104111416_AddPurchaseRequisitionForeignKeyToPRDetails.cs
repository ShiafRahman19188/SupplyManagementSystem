using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyChainManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddPurchaseRequisitionForeignKeyToPRDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PurchaseRequisitionPRID1",
                table: "ItemDetails",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetails_PurchaseRequisitionPRID1",
                table: "ItemDetails",
                column: "PurchaseRequisitionPRID1");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDetails_PurchaseRequisitions_PurchaseRequisitionPRID1",
                table: "ItemDetails",
                column: "PurchaseRequisitionPRID1",
                principalTable: "PurchaseRequisitions",
                principalColumn: "PRID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemDetails_PurchaseRequisitions_PurchaseRequisitionPRID1",
                table: "ItemDetails");

            migrationBuilder.DropIndex(
                name: "IX_ItemDetails_PurchaseRequisitionPRID1",
                table: "ItemDetails");

            migrationBuilder.DropColumn(
                name: "PurchaseRequisitionPRID1",
                table: "ItemDetails");
        }
    }
}
