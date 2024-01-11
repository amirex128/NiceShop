using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NiceShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix_coupon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppliedCouponPrice",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "QuantityCouponPrice",
                table: "BasketItems");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Baskets",
                newName: "TotalCouponPrice");

            migrationBuilder.RenameColumn(
                name: "TotalDiscount",
                table: "Baskets",
                newName: "RawQuantityPrice");

            migrationBuilder.AddColumn<int>(
                name: "CouponId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "RawPrice",
                table: "Baskets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RawPrice",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "TotalCouponPrice",
                table: "Baskets",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "RawQuantityPrice",
                table: "Baskets",
                newName: "TotalDiscount");

            migrationBuilder.AddColumn<long>(
                name: "AppliedCouponPrice",
                table: "BasketItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FinalPrice",
                table: "BasketItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "QuantityCouponPrice",
                table: "BasketItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
