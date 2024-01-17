using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NiceShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fix_order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPrice",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "FinalPrice",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "PriceWithCount",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "TotalProductPrice",
                table: "Orders",
                newName: "TotalQuantityPrice");

            migrationBuilder.RenameColumn(
                name: "TotalFinalPrice",
                table: "Orders",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "TotalDiscountPrice",
                table: "Orders",
                newName: "TotalCouponPrice");

            migrationBuilder.RenameColumn(
                name: "RawPriceVariant",
                table: "OrderItems",
                newName: "QuantityPrice");

            migrationBuilder.RenameColumn(
                name: "RawPrice",
                table: "OrderItems",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "OrderItems",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "RawQuantityPrice",
                table: "Baskets",
                newName: "TotalQuantityPrice");

            migrationBuilder.RenameColumn(
                name: "FinalPrice",
                table: "Baskets",
                newName: "TotalPrice");

            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BasketId",
                table: "Orders",
                column: "BasketId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Baskets_BasketId",
                table: "Orders",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Baskets_BasketId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BasketId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TotalQuantityPrice",
                table: "Orders",
                newName: "TotalProductPrice");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Orders",
                newName: "TotalFinalPrice");

            migrationBuilder.RenameColumn(
                name: "TotalCouponPrice",
                table: "Orders",
                newName: "TotalDiscountPrice");

            migrationBuilder.RenameColumn(
                name: "QuantityPrice",
                table: "OrderItems",
                newName: "RawPriceVariant");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrderItems",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderItems",
                newName: "RawPrice");

            migrationBuilder.RenameColumn(
                name: "TotalQuantityPrice",
                table: "Baskets",
                newName: "RawQuantityPrice");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Baskets",
                newName: "FinalPrice");

            migrationBuilder.AddColumn<long>(
                name: "DiscountPrice",
                table: "OrderItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FinalPrice",
                table: "OrderItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PriceWithCount",
                table: "OrderItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
