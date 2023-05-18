using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AEPortal.Data.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Longitude",
                table: "Ships",
                type: "Decimal(9,6)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "Ships",
                type: "Decimal(8,6)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Ships",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(9,6)");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Ships",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Decimal(8,6)");
        }
    }
}
