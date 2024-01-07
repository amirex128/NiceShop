using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NiceShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ifx_cate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategory_Articles_ArticlesId",
                table: "ArticleCategory");

            migrationBuilder.RenameColumn(
                name: "ArticlesId",
                table: "ArticleCategory",
                newName: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategory_Articles_ArticleId",
                table: "ArticleCategory",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArticleCategory_Articles_ArticleId",
                table: "ArticleCategory");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "ArticleCategory",
                newName: "ArticlesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArticleCategory_Articles_ArticlesId",
                table: "ArticleCategory",
                column: "ArticlesId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
