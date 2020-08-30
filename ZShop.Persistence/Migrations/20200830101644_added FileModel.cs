using Microsoft.EntityFrameworkCore.Migrations;

namespace ZShop.Persistence.Migrations
{
    public partial class addedFileModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgSrc",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "FileModelId",
                table: "products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_FileModelId",
                table: "products",
                column: "FileModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Files_FileModelId",
                table: "products",
                column: "FileModelId",
                principalTable: "Files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Files_FileModelId",
                table: "products");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropIndex(
                name: "IX_products_FileModelId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "FileModelId",
                table: "products");

            migrationBuilder.AddColumn<string>(
                name: "ImgSrc",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
