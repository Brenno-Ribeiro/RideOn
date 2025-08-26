using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideOn.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnOfCreateAndUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updated_by",
                table: "rental_contracts",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "rental_contracts",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Created_by",
                table: "rental_contracts",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "rental_contracts",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Updated_by",
                table: "motorcycles",
                newName: "updated_by");

            migrationBuilder.RenameColumn(
                name: "Updated_At",
                table: "motorcycles",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "Created_by",
                table: "motorcycles",
                newName: "created_by");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "motorcycles",
                newName: "created_at");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "rental_contracts",
                newName: "Updated_by");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "rental_contracts",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "rental_contracts",
                newName: "Created_by");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "rental_contracts",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "updated_by",
                table: "motorcycles",
                newName: "Updated_by");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "motorcycles",
                newName: "Updated_At");

            migrationBuilder.RenameColumn(
                name: "created_by",
                table: "motorcycles",
                newName: "Created_by");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "motorcycles",
                newName: "Created_At");
        }
    }
}
