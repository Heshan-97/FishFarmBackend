using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishFarm.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "fishFarms",
                columns: table => new
                {
                    FarmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FarmPictureUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BargeAvailability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fishFarms", x => x.FarmId);
                });

            migrationBuilder.CreateTable(
                name: "boats",
                columns: table => new
                {
                    BoatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoatName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GpsPosition = table.Column<double>(type: "float", nullable: false),
                    NoOfCages = table.Column<int>(type: "int", nullable: false),
                    FishFarmsFarmId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boats", x => x.BoatId);
                    table.ForeignKey(
                        name: "FK_boats_fishFarms_FishFarmsFarmId",
                        column: x => x.FishFarmsFarmId,
                        principalTable: "fishFarms",
                        principalColumn: "FarmId");
                });

            migrationBuilder.CreateTable(
                name: "workers",
                columns: table => new
                {
                    WorkerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CertifiedDatePeriod = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CrewRole = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkerPosition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FishFarmsFarmId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workers", x => x.WorkerId);
                    table.ForeignKey(
                        name: "FK_workers_fishFarms_FishFarmsFarmId",
                        column: x => x.FishFarmsFarmId,
                        principalTable: "fishFarms",
                        principalColumn: "FarmId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_boats_FishFarmsFarmId",
                table: "boats",
                column: "FishFarmsFarmId");

            migrationBuilder.CreateIndex(
                name: "IX_workers_FishFarmsFarmId",
                table: "workers",
                column: "FishFarmsFarmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "boats");

            migrationBuilder.DropTable(
                name: "workers");

            migrationBuilder.DropTable(
                name: "fishFarms");
        }
    }
}
