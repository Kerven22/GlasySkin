using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlasySkin.Migrations
{
    /// <inheritdoc />
    public partial class CahangeNameTypeToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_TypeId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Products",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_TypeId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Categories",
                newName: "CategoryId ");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId ",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Products",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                newName: "IX_Products_TypeId");

            migrationBuilder.RenameColumn(
                name: "CategoryId ",
                table: "Categories",
                newName: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_TypeId",
                table: "Products",
                column: "TypeId",
                principalTable: "Categories",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
