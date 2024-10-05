using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REVISION_DOT_NET.Migrations
{
    /// <inheritdoc />
    public partial class adf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categories_category_id",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Jobs",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_category_id",
                table: "Jobs",
                newName: "IX_Jobs_categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categories_categoryId",
                table: "Jobs",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categories_categoryId",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "Jobs",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_categoryId",
                table: "Jobs",
                newName: "IX_Jobs_category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categories_category_id",
                table: "Jobs",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
