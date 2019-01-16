using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductsDemo.Data.Migrations
{
    public partial class ExtendProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Products");
        }
    }
}
