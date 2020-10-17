using Microsoft.EntityFrameworkCore.Migrations;

namespace ZShop.Persistence.Migrations
{
    public partial class addedmoreimages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl_1",
                table: "products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl_2",
                table: "products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl_3",
                table: "products",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl_1",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ImageUrl_2",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ImageUrl_3",
                table: "products");
        }
    }
}
