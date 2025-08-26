using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideOn.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnInDeliveryMen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updated_by",
                table: "delivery_men",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "delivery_men",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Created_by",
                table: "delivery_men",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "delivery_men",
                newName: "created_at");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "delivery_men",
                newName: "Updated_by");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "delivery_men",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "delivery_men",
                newName: "Created_by");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "delivery_men",
                newName: "Created_At");
        }
    }
}
