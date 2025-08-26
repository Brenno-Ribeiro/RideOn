using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideOn.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "plane",
                table: "rental_contracts",
                newName: "plan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "plan",
                table: "rental_contracts",
                newName: "plane");
        }
    }
}
