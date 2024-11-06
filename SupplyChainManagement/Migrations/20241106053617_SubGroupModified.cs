using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyChainManagement.Migrations
{
    /// <inheritdoc />
    public partial class SubGroupModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemMasters_ItemSubGroups_ItemSubGroupSubGroupId",
                table: "ItemMasters");

            migrationBuilder.DropIndex(
                name: "IX_ItemMasters_ItemSubGroupSubGroupId",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "ItemSubGroupSubGroupId",
                table: "ItemMasters");

            migrationBuilder.RenameColumn(
                name: "SubGroupId",
                table: "ItemSubGroups",
                newName: "ItemSubGroupId");

            migrationBuilder.RenameColumn(
                name: "SubGroupId",
                table: "ItemMasters",
                newName: "ItemSubGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMasters_ItemSubGroupId",
                table: "ItemMasters",
                column: "ItemSubGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMasters_ItemSubGroups_ItemSubGroupId",
                table: "ItemMasters",
                column: "ItemSubGroupId",
                principalTable: "ItemSubGroups",
                principalColumn: "ItemSubGroupId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemMasters_ItemSubGroups_ItemSubGroupId",
                table: "ItemMasters");

            migrationBuilder.DropIndex(
                name: "IX_ItemMasters_ItemSubGroupId",
                table: "ItemMasters");

            migrationBuilder.RenameColumn(
                name: "ItemSubGroupId",
                table: "ItemSubGroups",
                newName: "SubGroupId");

            migrationBuilder.RenameColumn(
                name: "ItemSubGroupId",
                table: "ItemMasters",
                newName: "SubGroupId");

            migrationBuilder.AddColumn<int>(
                name: "ItemSubGroupSubGroupId",
                table: "ItemMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ItemMasters_ItemSubGroupSubGroupId",
                table: "ItemMasters",
                column: "ItemSubGroupSubGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMasters_ItemSubGroups_ItemSubGroupSubGroupId",
                table: "ItemMasters",
                column: "ItemSubGroupSubGroupId",
                principalTable: "ItemSubGroups",
                principalColumn: "SubGroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
