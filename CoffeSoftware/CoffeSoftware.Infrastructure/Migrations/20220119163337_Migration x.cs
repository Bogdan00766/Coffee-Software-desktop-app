using Microsoft.EntityFrameworkCore.Migrations;

namespace Coffe.Infrastructure.Migrations
{
    public partial class Migrationx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderListProduct",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderListProduct");
        }
    }
}
