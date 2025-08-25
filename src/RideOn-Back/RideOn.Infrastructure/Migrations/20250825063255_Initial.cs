using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideOn.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "delivery_men",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CNPJ = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created_At = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    Updated_At = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Updated_by = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_men", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "motorcycles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: true),
                    Plate = table.Column<string>(type: "character varying(10)", unicode: false, maxLength: 10, nullable: true),
                    Created_At = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    Updated_At = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Updated_by = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_motorcycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cnhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CnhNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CnhType = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    CnhImage = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    DeliveryManId = table.Column<Guid>(type: "uuid", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "rental_contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DailyRate = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ExpectedEndDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ReturnDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DeliveryManId = table.Column<Guid>(type: "uuid", nullable: false),
                    MotorcycleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Created_At = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    Updated_At = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Updated_by = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rental_contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rental_contracts_delivery_men_DeliveryManId",
                        column: x => x.DeliveryManId,
                        principalTable: "delivery_men",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rental_contracts_motorcycles_MotorcycleId",
                        column: x => x.MotorcycleId,
                        principalTable: "motorcycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryMen_CNPJ",
                table: "delivery_men",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycles_Plate",
                table: "motorcycles",
                column: "Plate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentalContracts_DeliveryMan_Period",
                table: "rental_contracts",
                columns: new[] { "DeliveryManId", "StartDate", "EndDate" });

            migrationBuilder.CreateIndex(
                name: "IX_RentalContracts_DeliveryManId",
                table: "rental_contracts",
                column: "DeliveryManId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalContracts_EndDate",
                table: "rental_contracts",
                column: "EndDate");

            migrationBuilder.CreateIndex(
                name: "IX_RentalContracts_MotorcycleId",
                table: "rental_contracts",
                column: "MotorcycleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentalContracts_StartDate",
                table: "rental_contracts",
                column: "StartDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cnhs");

            migrationBuilder.DropTable(
                name: "rental_contracts");

            migrationBuilder.DropTable(
                name: "delivery_men");

            migrationBuilder.DropTable(
                name: "motorcycles");
        }
    }
}
