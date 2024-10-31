using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupplyChainManagement.Migrations
{
    /// <inheritdoc />
    public partial class secondinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "itemDetailsId",
                table: "purchaseRequisitions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "pr_id",
                table: "itemDetails",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "itemDetailsId",
                table: "purchaseRequisitions");

            migrationBuilder.DropColumn(
                name: "pr_id",
                table: "itemDetails");
        }
    }
}
