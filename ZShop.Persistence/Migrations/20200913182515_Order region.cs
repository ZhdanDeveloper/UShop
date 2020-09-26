using Microsoft.EntityFrameworkCore.Migrations;

namespace ZShop.Persistence.Migrations
{
    public partial class Orderregion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Region",
                table: "orders");
        }
    }
}
