using Microsoft.EntityFrameworkCore.Migrations;

namespace Coffe.Infrastructure.Migrations
{
    public partial class Migr1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderListProduct",
                table: "OrderListProduct");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderListProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderListProduct",
                table: "OrderListProduct",
                columns: new[] { "Id", "OrderListId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderListProduct_OrderListId",
                table: "OrderListProduct",
                column: "OrderListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderListProduct",
                table: "OrderListProduct");

            migrationBuilder.DropIndex(
                name: "IX_OrderListProduct_OrderListId",
                table: "OrderListProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderListProduct");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderListProduct",
                table: "OrderListProduct",
                columns: new[] { "OrderListId", "ProductId" });
        }
    }
}
