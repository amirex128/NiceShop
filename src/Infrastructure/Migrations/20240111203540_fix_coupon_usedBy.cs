using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NiceShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix_coupon_usedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Coupon_CouponId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CouponId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CouponId",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "CouponUser",
                columns: table => new
                {
                    CouponId = table.Column<int>(type: "int", nullable: false),
                    UsedById = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponUser", x => new { x.CouponId, x.UsedById });
                    table.ForeignKey(
                        name: "FK_CouponUser_Coupon_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouponUser_Users_UsedById",
                        column: x => x.UsedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CouponUser_UsedById",
                table: "CouponUser",
                column: "UsedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CouponUser");

            migrationBuilder.AddColumn<int>(
                name: "CouponId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CouponId",
                table: "Users",
                column: "CouponId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Coupon_CouponId",
                table: "Users",
                column: "CouponId",
                principalTable: "Coupon",
                principalColumn: "Id");
        }
    }
}
