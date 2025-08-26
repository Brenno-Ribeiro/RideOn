using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideOn.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class valueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cnhs");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "rental_contracts",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "ReturnDate",
                table: "rental_contracts",
                newName: "return_date");

            migrationBuilder.RenameColumn(
                name: "ExpectedEndDate",
                table: "rental_contracts",
                newName: "expected_end_date");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "rental_contracts",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "DailyRate",
                table: "rental_contracts",
                newName: "daily_rate");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "motorcycles",
                newName: "year");

            migrationBuilder.RenameColumn(
                name: "Plate",
                table: "motorcycles",
                newName: "plate");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "motorcycles",
                newName: "model");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "delivery_men",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CNPJ",
                table: "delivery_men",
                newName: "cnpj");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "delivery_men",
                newName: "birth_date");

            migrationBuilder.AlterColumn<string>(
                name: "plate",
                table: "motorcycles",
                type: "character varying(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldUnicode: false,
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cnpj",
                table: "delivery_men",
                type: "character varying(14)",
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldUnicode: false,
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cnh_image",
                table: "delivery_men",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cnh_number",
                table: "delivery_men",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cnh_type",
                table: "delivery_men",
                type: "character varying(3)",
                maxLength: 3,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cnh_image",
                table: "delivery_men");

            migrationBuilder.DropColumn(
                name: "cnh_number",
                table: "delivery_men");

            migrationBuilder.DropColumn(
                name: "cnh_type",
                table: "delivery_men");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "rental_contracts",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "return_date",
                table: "rental_contracts",
                newName: "ReturnDate");

            migrationBuilder.RenameColumn(
                name: "expected_end_date",
                table: "rental_contracts",
                newName: "ExpectedEndDate");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "rental_contracts",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "daily_rate",
                table: "rental_contracts",
                newName: "DailyRate");

            migrationBuilder.RenameColumn(
                name: "year",
                table: "motorcycles",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "plate",
                table: "motorcycles",
                newName: "Plate");

            migrationBuilder.RenameColumn(
                name: "model",
                table: "motorcycles",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "delivery_men",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "cnpj",
                table: "delivery_men",
                newName: "CNPJ");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "delivery_men",
                newName: "BirthDate");

            migrationBuilder.AlterColumn<string>(
                name: "Plate",
                table: "motorcycles",
                type: "character varying(10)",
                unicode: false,
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(8)",
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "delivery_men",
                type: "character varying(20)",
                unicode: false,
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(14)",
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "cnhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliveryManId = table.Column<Guid>(type: "uuid", nullable: false),
                    CnhImage = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    CnhNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CnhType = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Created_At = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    Updated_At = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Updated_by = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cnhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cnhs_delivery_men_DeliveryManId",
                        column: x => x.DeliveryManId,
                        principalTable: "delivery_men",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CNH_CnhNumber",
                table: "cnhs",
                column: "CnhNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cnhs_DeliveryManId",
                table: "cnhs",
                column: "DeliveryManId",
                unique: true);
        }
    }
}
