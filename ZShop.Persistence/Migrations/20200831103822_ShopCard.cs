using Microsoft.EntityFrameworkCore.Migrations;

namespace ZShop.Persistence.Migrations
{
    public partial class ShopCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopCardId",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShopCardId",
                table: "products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShopCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopCard_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_ShopCardId",
                table: "products",
                column: "ShopCardId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopCard_UserId",
                table: "ShopCard",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_products_ShopCard_ShopCardId",
                table: "products",
                column: "ShopCardId",
                principalTable: "ShopCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_ShopCard_ShopCardId",
                table: "products");

            migrationBuilder.DropTable(
                name: "ShopCard");

            migrationBuilder.DropIndex(
                name: "IX_products_ShopCardId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ShopCardId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ShopCardId",
                table: "products");
        }
    }
}
