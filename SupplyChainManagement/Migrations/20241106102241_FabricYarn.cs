using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyChainManagement.Migrations
{
    /// <inheritdoc />
    public partial class FabricYarn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Yarns_YarnId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Yarns_ItemMasters_ItemMasterId",
                table: "Yarns");

            migrationBuilder.DropIndex(
                name: "IX_Yarns_ItemMasterId",
                table: "Yarns");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_YarnId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ItemMasterId",
                table: "Yarns");

            migrationBuilder.DropColumn(
                name: "YarnId",
                table: "Suppliers");

            migrationBuilder.CreateTable(
                name: "FabricYarns",
                columns: table => new
                {
                    FabricYarnId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FabricId = table.Column<int>(type: "int", nullable: false),
                    YarnId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricYarns", x => x.FabricYarnId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FabricYarns");

            migrationBuilder.AddColumn<int>(
                name: "ItemMasterId",
                table: "Yarns",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YarnId",
                table: "Suppliers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yarns_ItemMasterId",
                table: "Yarns",
                column: "ItemMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_YarnId",
                table: "Suppliers",
                column: "YarnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Yarns_YarnId",
                table: "Suppliers",
                column: "YarnId",
                principalTable: "Yarns",
                principalColumn: "YarnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Yarns_ItemMasters_ItemMasterId",
                table: "Yarns",
                column: "ItemMasterId",
                principalTable: "ItemMasters",
                principalColumn: "ItemMasterId");
        }
    }
}
