using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NiceShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove_raw_price : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RawPrice",
                table: "Baskets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RawPrice",
                table: "Baskets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
