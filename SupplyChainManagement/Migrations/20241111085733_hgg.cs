using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyChainManagement.Migrations
{
    /// <inheritdoc />
    public partial class hgg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "YarnBookingMasterId",
                table: "PurchaseRequisitionMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YarnPOMasterYPOMasterID",
                table: "ItemPODetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemPODetail_YarnPOMasterYPOMasterID",
                table: "ItemPODetail",
                column: "YarnPOMasterYPOMasterID");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPODetail_ItemPOMaster_YarnPOMasterYPOMasterID",
                table: "ItemPODetail",
                column: "YarnPOMasterYPOMasterID",
                principalTable: "ItemPOMaster",
                principalColumn: "YPOMasterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPODetail_ItemPOMaster_YarnPOMasterYPOMasterID",
                table: "ItemPODetail");

            migrationBuilder.DropIndex(
                name: "IX_ItemPODetail_YarnPOMasterYPOMasterID",
                table: "ItemPODetail");

            migrationBuilder.DropColumn(
                name: "YarnBookingMasterId",
                table: "PurchaseRequisitionMasters");

            migrationBuilder.DropColumn(
                name: "YarnPOMasterYPOMasterID",
                table: "ItemPODetail");
        }
    }
}
