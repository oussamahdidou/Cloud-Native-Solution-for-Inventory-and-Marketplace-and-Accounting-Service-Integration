using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketplaceService.API.Migrations
{
    /// <inheritdoc />
    public partial class Payement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PayementId",
                table: "commandes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayementId",
                table: "commandes");
        }
    }
}
