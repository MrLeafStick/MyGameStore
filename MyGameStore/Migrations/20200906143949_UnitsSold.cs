using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGameStore.Migrations
{
    public partial class UnitsSold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descriptoin",
                table: "Game");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Game",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Game",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitsSold",
                table: "Game",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "UnitsSold",
                table: "Game");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Game",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AddColumn<string>(
                name: "Descriptoin",
                table: "Game",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
