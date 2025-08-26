using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideOn.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnInAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rental_contracts_delivery_men_DeliveryManId",
                table: "rental_contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_rental_contracts_motorcycles_MotorcycleId",
                table: "rental_contracts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "rental_contracts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "MotorcycleId",
                table: "rental_contracts",
                newName: "motorcycle_id");

            migrationBuilder.RenameColumn(
                name: "DeliveryManId",
                table: "rental_contracts",
                newName: "delivery_man_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "delivery_men",
                newName: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_rental_contracts_delivery_men_delivery_man_id",
                table: "rental_contracts",
                column: "delivery_man_id",
                principalTable: "delivery_men",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rental_contracts_motorcycles_motorcycle_id",
                table: "rental_contracts",
                column: "motorcycle_id",
                principalTable: "motorcycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rental_contracts_delivery_men_delivery_man_id",
                table: "rental_contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_rental_contracts_motorcycles_motorcycle_id",
                table: "rental_contracts");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "rental_contracts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "motorcycle_id",
                table: "rental_contracts",
                newName: "MotorcycleId");

            migrationBuilder.RenameColumn(
                name: "delivery_man_id",
                table: "rental_contracts",
                newName: "DeliveryManId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "delivery_men",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_rental_contracts_delivery_men_DeliveryManId",
                table: "rental_contracts",
                column: "DeliveryManId",
                principalTable: "delivery_men",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rental_contracts_motorcycles_MotorcycleId",
                table: "rental_contracts",
                column: "MotorcycleId",
                principalTable: "motorcycles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
