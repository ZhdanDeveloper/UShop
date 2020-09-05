using Microsoft.EntityFrameworkCore.Migrations;

namespace ZShop.Persistence.Migrations
{
    public partial class ShopCart3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_shopCards_ShopCardId",
                table: "products");

            migrationBuilder.DropTable(
                name: "shopCards");

            migrationBuilder.DropIndex(
                name: "IX_products_ShopCardId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ShopCardId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ShopCardId",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_CartId",
                table: "products",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_products_Carts_CartId",
                table: "products",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Carts_CartId",
                table: "products");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_products_CartId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "ShopCardId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShopCardId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "shopCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shopCards_Users_UserId",
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
                name: "IX_shopCards_UserId",
                table: "shopCards",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_products_shopCards_ShopCardId",
                table: "products",
                column: "ShopCardId",
                principalTable: "shopCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
