using Microsoft.EntityFrameworkCore.Migrations;

namespace ZShop.Persistence.Migrations
{
    public partial class Orders5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_items_ItemId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_ItemId",
                table: "orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_orders_ItemId",
                table: "orders",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_items_ItemId",
                table: "orders",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
