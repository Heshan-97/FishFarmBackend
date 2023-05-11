using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishFarm.Migrations
{
    /// <inheritdoc />
    public partial class AddFishFarmsToWorkers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_boats_fishFarms_FishFarmsFarmId",
                table: "boats");

            migrationBuilder.DropForeignKey(
                name: "FK_workers_fishFarms_FishFarmsFarmId",
                table: "workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_workers",
                table: "workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_fishFarms",
                table: "fishFarms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_boats",
                table: "boats");

            migrationBuilder.RenameTable(
                name: "workers",
                newName: "Workers");

            migrationBuilder.RenameTable(
                name: "fishFarms",
                newName: "FishFarms");

            migrationBuilder.RenameTable(
                name: "boats",
                newName: "Boats");

            migrationBuilder.RenameIndex(
                name: "IX_workers_FishFarmsFarmId",
                table: "Workers",
                newName: "IX_Workers_FishFarmsFarmId");

            migrationBuilder.RenameIndex(
                name: "IX_boats_FishFarmsFarmId",
                table: "Boats",
                newName: "IX_Boats_FishFarmsFarmId");

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "Workers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FishFarmsFarmId",
                table: "Workers",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Workers",
                table: "Workers",
                column: "WorkerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FishFarms",
                table: "FishFarms",
                column: "FarmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boats",
                table: "Boats",
                column: "BoatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boats_FishFarms_FishFarmsFarmId",
                table: "Boats",
                column: "FishFarmsFarmId",
                principalTable: "FishFarms",
                principalColumn: "FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_FishFarms_FishFarmsFarmId",
                table: "Workers",
                column: "FishFarmsFarmId",
                principalTable: "FishFarms",
                principalColumn: "FarmId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boats_FishFarms_FishFarmsFarmId",
                table: "Boats");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_FishFarms_FishFarmsFarmId",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Workers",
                table: "Workers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FishFarms",
                table: "FishFarms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boats",
                table: "Boats");

            migrationBuilder.RenameTable(
                name: "Workers",
                newName: "workers");

            migrationBuilder.RenameTable(
                name: "FishFarms",
                newName: "fishFarms");

            migrationBuilder.RenameTable(
                name: "Boats",
                newName: "boats");

            migrationBuilder.RenameIndex(
                name: "IX_Workers_FishFarmsFarmId",
                table: "workers",
                newName: "IX_workers_FishFarmsFarmId");

            migrationBuilder.RenameIndex(
                name: "IX_Boats_FishFarmsFarmId",
                table: "boats",
                newName: "IX_boats_FishFarmsFarmId");

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "workers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "FishFarmsFarmId",
                table: "workers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_workers",
                table: "workers",
                column: "WorkerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_fishFarms",
                table: "fishFarms",
                column: "FarmId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_boats",
                table: "boats",
                column: "BoatId");

            migrationBuilder.AddForeignKey(
                name: "FK_boats_fishFarms_FishFarmsFarmId",
                table: "boats",
                column: "FishFarmsFarmId",
                principalTable: "fishFarms",
                principalColumn: "FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_workers_fishFarms_FishFarmsFarmId",
                table: "workers",
                column: "FishFarmsFarmId",
                principalTable: "fishFarms",
                principalColumn: "FarmId");
        }
    }
}
