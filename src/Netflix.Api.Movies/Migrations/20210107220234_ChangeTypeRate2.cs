using Microsoft.EntityFrameworkCore.Migrations;

namespace Netflix.Api.Movies.Migrations
{
    public partial class ChangeTypeRate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "MovieCategories",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "MovieCategories",
                type: "decimal(2,2)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
