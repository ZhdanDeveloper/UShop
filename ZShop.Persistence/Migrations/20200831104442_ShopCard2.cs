using Microsoft.EntityFrameworkCore.Migrations;

namespace ZShop.Persistence.Migrations
{
    public partial class ShopCard2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_ShopCard_ShopCardId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopCard_Users_UserId",
                table: "ShopCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShopCard",
                table: "ShopCard");

            migrationBuilder.RenameTable(
                name: "ShopCard",
                newName: "shopCards");

            migrationBuilder.RenameIndex(
                name: "IX_ShopCard_UserId",
                table: "shopCards",
                newName: "IX_shopCards_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shopCards",
                table: "shopCards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_shopCards_ShopCardId",
                table: "products",
                column: "ShopCardId",
                principalTable: "shopCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_shopCards_Users_UserId",
                table: "shopCards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_shopCards_ShopCardId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_shopCards_Users_UserId",
                table: "shopCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shopCards",
                table: "shopCards");

            migrationBuilder.RenameTable(
                name: "shopCards",
                newName: "ShopCard");

            migrationBuilder.RenameIndex(
                name: "IX_shopCards_UserId",
                table: "ShopCard",
                newName: "IX_ShopCard_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShopCard",
                table: "ShopCard",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_ShopCard_ShopCardId",
                table: "products",
                column: "ShopCardId",
                principalTable: "ShopCard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopCard_Users_UserId",
                table: "ShopCard",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
