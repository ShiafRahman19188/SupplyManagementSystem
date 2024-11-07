using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyChainManagement.Migrations
{
    /// <inheritdoc />
    public partial class yarnBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

           

            migrationBuilder.CreateTable(
                name: "YarnBookingMasters",
                columns: table => new
                {
                    YarnBookingMasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YarnBookingMasterNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAcknowledge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YarnBookingMasters", x => x.YarnBookingMasterId);
                });

            migrationBuilder.CreateTable(
                name: "YarnBookingChilds",
                columns: table => new
                {
                    YarnBookingChildId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YarnBookingMasterId = table.Column<int>(type: "int", nullable: false),
                    ItemMasterId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YarnBookingChilds", x => x.YarnBookingChildId);
                    table.ForeignKey(
                        name: "FK_YarnBookingChilds_YarnBookingMasters_YarnBookingMasterId",
                        column: x => x.YarnBookingMasterId,
                        principalTable: "YarnBookingMasters",
                        principalColumn: "YarnBookingMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YarnBookingChilds_YarnBookingMasterId",
                table: "YarnBookingChilds",
                column: "YarnBookingMasterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "YarnBookingChilds");

            migrationBuilder.DropTable(
                name: "YarnBookingMasters");
        }
    }
}
