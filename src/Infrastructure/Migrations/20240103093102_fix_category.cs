using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NiceShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix_category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Medias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeoTags",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_CategoryId",
                table: "Medias",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Categories_CategoryId",
                table: "Medias",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Categories_CategoryId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_CategoryId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SeoTags",
                table: "Categories");
        }
    }
}
