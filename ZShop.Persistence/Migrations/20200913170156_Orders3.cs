using Microsoft.EntityFrameworkCore.Migrations;

namespace ZShop.Persistence.Migrations
{
    public partial class Orders3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemName",
                table: "orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "orders");
        }
    }
}
