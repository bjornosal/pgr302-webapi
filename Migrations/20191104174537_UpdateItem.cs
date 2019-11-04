using Microsoft.EntityFrameworkCore.Migrations;

namespace WarehouseApi.Migrations
{
    public partial class UpdateItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "price",
                table: "Items",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "Items");
        }
    }
}
