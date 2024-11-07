using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyChainManagement.Migrations
{
    /// <inheritdoc />
    public partial class BookingMasterChild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingMasters",
                columns: table => new
                {
                    BookingMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingMasterNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExportWorkOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingMasters", x => x.BookingMasterId);
                    table.ForeignKey(
                        name: "FK_BookingMasters_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingChild",
                columns: table => new
                {
                    BookingChildId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingMasterId = table.Column<int>(type: "int", nullable: false),
                    ItemMasterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingChild", x => x.BookingChildId);
                    table.ForeignKey(
                        name: "FK_BookingChild_BookingMasters_BookingMasterId",
                        column: x => x.BookingMasterId,
                        principalTable: "BookingMasters",
                        principalColumn: "BookingMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingChild_ItemMasters_ItemMasterId",
                        column: x => x.ItemMasterId,
                        principalTable: "ItemMasters",
                        principalColumn: "ItemMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingChild_BookingMasterId",
                table: "BookingChild",
                column: "BookingMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingChild_ItemMasterId",
                table: "BookingChild",
                column: "ItemMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingMasters_SupplierId",
                table: "BookingMasters",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingChild");

            migrationBuilder.DropTable(
                name: "BookingMasters");
        }
    }
}
