using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NiceShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Coupon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    FixedAmount = table.Column<long>(type: "bigint", nullable: true),
                    Percentage = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    TotalSales = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Colour_Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalCode = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Social_Telegram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Social_Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Social_Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CouponProduct",
                columns: table => new
                {
                    CouponsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponProduct", x => new { x.CouponsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CouponProduct_Coupon_CouponsId",
                        column: x => x.CouponsId,
                        principalTable: "Coupon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CouponProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceAdjustment = table.Column<long>(type: "bigint", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TodoItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Reminder = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Done = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoItems_TodoLists_ListId",
                        column: x => x.ListId,
                        principalTable: "TodoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPrice = table.Column<long>(type: "bigint", nullable: false),
                    TotalDiscount = table.Column<long>(type: "bigint", nullable: false),
                    FinalPrice = table.Column<long>(type: "bigint", nullable: false),
                    CouponId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Baskets_Coupon_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Baskets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelativePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medias_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OTPs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OTPs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductReviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlists_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wishlists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresses_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    BasketId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductVariantId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BasketItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MediaProduct",
                columns: table => new
                {
                    MediasId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaProduct", x => new { x.MediasId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_MediaProduct_Medias_MediasId",
                        column: x => x.MediasId,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MediaProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalProductPrice = table.Column<long>(type: "bigint", nullable: false),
                    TotalDiscountPrice = table.Column<long>(type: "bigint", nullable: false),
                    TotalTaxPrice = table.Column<long>(type: "bigint", nullable: false),
                    TotalSendPrice = table.Column<long>(type: "bigint", nullable: false),
                    TotalFinalPrice = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PackageSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackingCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Courier = table.Column<int>(type: "int", nullable: false),
                    LastStatusUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategory",
                columns: table => new
                {
                    ArticlesId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategory", x => new { x.ArticlesId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_ArticleCategory_Articles_ArticlesId",
                        column: x => x.ArticlesId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: false),
                    RawPrice = table.Column<long>(type: "bigint", nullable: false),
                    RawPriceVariant = table.Column<long>(type: "bigint", nullable: false),
                    PriceWithCount = table.Column<long>(type: "bigint", nullable: false),
                    DiscountPrice = table.Column<long>(type: "bigint", nullable: false),
                    FinalPrice = table.Column<long>(type: "bigint", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ProductVariantId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Returns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrderItemId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Returns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Returns_OrderItems_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "OrderItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Returns_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Returns_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Returns_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name", "Slug", "Status" },
                values: new object[,]
                {
                    { 1, "آذربایجان شرقی", "آذربایجان-شرقی", "Active" },
                    { 2, "آذربایجان غربی", "آذربایجان-غربی", "Active" },
                    { 3, "اردبیل", "اردبیل", "Active" },
                    { 4, "اصفهان", "اصفهان", "Active" },
                    { 5, "البرز", "البرز", "Active" },
                    { 6, "ایلام", "ایلام", "Active" },
                    { 7, "بوشهر", "بوشهر", "Active" },
                    { 8, "تهران", "تهران", "Active" },
                    { 9, "چهارمحال و بختیاری", "چهارمحال-بختیاری", "Active" },
                    { 10, "خراسان جنوبی", "خراسان-جنوبی", "Active" },
                    { 11, "خراسان رضوی", "خراسان-رضوی", "Active" },
                    { 12, "خراسان شمالی", "خراسان-شمالی", "Active" },
                    { 13, "خوزستان", "خوزستان", "Active" },
                    { 14, "زنجان", "زنجان", "Active" },
                    { 15, "سمنان", "سمنان", "Active" },
                    { 16, "سیستان و بلوچستان", "سیستان-بلوچستان", "Active" },
                    { 17, "فارس", "فارس", "Active" },
                    { 18, "قزوین", "قزوین", "Active" },
                    { 19, "قم", "قم", "Active" },
                    { 20, "کردستان", "کردستان", "Active" },
                    { 21, "کرمان", "کرمان", "Active" },
                    { 22, "کرمانشاه", "کرمانشاه", "Active" },
                    { 23, "کهگیلویه و بویراحمد", "کهگیلویه-بویراحمد", "Active" },
                    { 24, "گلستان", "گلستان", "Active" },
                    { 25, "لرستان", "لرستان", "Active" },
                    { 26, "گیلان", "گیلان", "Active" },
                    { 27, "مازندران", "مازندران", "Active" },
                    { 28, "مرکزی", "مرکزی", "Active" },
                    { 29, "هرمزگان", "هرمزگان", "Active" },
                    { 30, "همدان", "همدان", "Active" },
                    { 31, "یزد", "یزد", "Active" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "ProvinceId", "Slug", "Status" },
                values: new object[,]
                {
                    { 1, "اسکو", 1, "اسکو", "Active" },
                    { 2, "اهر", 1, "اهر", "Active" },
                    { 3, "ایلخچی", 1, "ایلخچی", "Active" },
                    { 4, "آبش احمد", 1, "آبش-احمد", "Active" },
                    { 5, "آذرشهر", 1, "آذرشهر", "Active" },
                    { 6, "آقکند", 1, "آقکند", "Active" },
                    { 7, "باسمنج", 1, "باسمنج", "Active" },
                    { 8, "بخشایش", 1, "بخشایش", "Active" },
                    { 9, "بستان آباد", 1, "بستان-آباد", "Active" },
                    { 10, "بناب", 1, "بناب", "Active" },
                    { 11, "بناب جدید", 1, "بناب-جدید", "Active" },
                    { 12, "تبریز", 1, "تبریز", "Active" },
                    { 13, "ترک", 1, "ترک", "Active" },
                    { 14, "ترکمانچای", 1, "ترکمانچای", "Active" },
                    { 15, "تسوج", 1, "تسوج", "Active" },
                    { 16, "تیکمه داش", 1, "تیکمه-داش", "Active" },
                    { 17, "جلفا", 1, "جلفا", "Active" },
                    { 18, "خاروانا", 1, "خاروانا", "Active" },
                    { 19, "خامنه", 1, "خامنه", "Active" },
                    { 20, "خراجو", 1, "خراجو", "Active" },
                    { 21, "خسروشهر", 1, "خسروشهر", "Active" },
                    { 22, "خضرلو", 1, "خضرلو", "Active" },
                    { 23, "خمارلو", 1, "خمارلو", "Active" },
                    { 24, "خواجه", 1, "خواجه", "Active" },
                    { 25, "دوزدوزان", 1, "دوزدوزان", "Active" },
                    { 26, "زرنق", 1, "زرنق", "Active" },
                    { 27, "زنوز", 1, "زنوز", "Active" },
                    { 28, "سراب", 1, "سراب", "Active" },
                    { 29, "سردرود", 1, "سردرود", "Active" },
                    { 30, "سهند", 1, "سهند", "Active" },
                    { 31, "سیس", 1, "سیس", "Active" },
                    { 32, "سیه رود", 1, "سیه-رود", "Active" },
                    { 33, "شبستر", 1, "شبستر", "Active" },
                    { 34, "شربیان", 1, "شربیان", "Active" },
                    { 35, "شرفخانه", 1, "شرفخانه", "Active" },
                    { 36, "شندآباد", 1, "شندآباد", "Active" },
                    { 37, "صوفیان", 1, "صوفیان", "Active" },
                    { 38, "عجب شیر", 1, "عجب-شیر", "Active" },
                    { 39, "قره آغاج", 1, "قره-آغاج", "Active" },
                    { 40, "کشکسرای", 1, "کشکسرای", "Active" },
                    { 41, "کلوانق", 1, "کلوانق", "Active" },
                    { 42, "کلیبر", 1, "کلیبر", "Active" },
                    { 43, "کوزه کنان", 1, "کوزه-کنان", "Active" },
                    { 44, "گوگان", 1, "گوگان", "Active" },
                    { 45, "لیلان", 1, "لیلان", "Active" },
                    { 46, "مراغه", 1, "مراغه", "Active" },
                    { 47, "مرند", 1, "مرند", "Active" },
                    { 48, "ملکان", 1, "ملکان", "Active" },
                    { 49, "ملک کیان", 1, "ملک-کیان", "Active" },
                    { 50, "ممقان", 1, "ممقان", "Active" },
                    { 51, "مهربان", 1, "مهربان", "Active" },
                    { 52, "میانه", 1, "میانه", "Active" },
                    { 53, "نظرکهریزی", 1, "نظرکهریزی", "Active" },
                    { 54, "هادی شهر", 1, "هادی-شهر", "Active" },
                    { 55, "هرگلان", 1, "هرگلان", "Active" },
                    { 56, "هریس", 1, "هریس", "Active" },
                    { 57, "هشترود", 1, "هشترود", "Active" },
                    { 58, "هوراند", 1, "هوراند", "Active" },
                    { 59, "وایقان", 1, "وایقان", "Active" },
                    { 60, "ورزقان", 1, "ورزقان", "Active" },
                    { 61, "یامچی", 1, "یامچی", "Active" },
                    { 62, "ارومیه", 2, "ارومیه", "Active" },
                    { 63, "اشنویه", 2, "اشنویه", "Active" },
                    { 64, "ایواوغلی", 2, "ایواوغلی", "Active" },
                    { 65, "آواجیق", 2, "آواجیق", "Active" },
                    { 66, "باروق", 2, "باروق", "Active" },
                    { 67, "بازرگان", 2, "بازرگان", "Active" },
                    { 68, "بوکان", 2, "بوکان", "Active" },
                    { 69, "پلدشت", 2, "پلدشت", "Active" },
                    { 70, "پیرانشهر", 2, "پیرانشهر", "Active" },
                    { 71, "تازه شهر", 2, "تازه-شهر", "Active" },
                    { 72, "تکاب", 2, "تکاب", "Active" },
                    { 73, "چهاربرج", 2, "چهاربرج", "Active" },
                    { 74, "خوی", 2, "خوی", "Active" },
                    { 75, "دیزج دیز", 2, "دیزج-دیز", "Active" },
                    { 76, "ربط", 2, "ربط", "Active" },
                    { 77, "سردشت", 2, "آذربایجان-غربی-سردشت", "Active" },
                    { 78, "سرو", 2, "سرو", "Active" },
                    { 79, "سلماس", 2, "سلماس", "Active" },
                    { 80, "سیلوانه", 2, "سیلوانه", "Active" },
                    { 81, "سیمینه", 2, "سیمینه", "Active" },
                    { 82, "سیه چشمه", 2, "سیه-چشمه", "Active" },
                    { 83, "شاهین دژ", 2, "شاهین-دژ", "Active" },
                    { 84, "شوط", 2, "شوط", "Active" },
                    { 85, "فیرورق", 2, "فیرورق", "Active" },
                    { 86, "قره ضیاءالدین", 2, "قره-ضیاءالدین", "Active" },
                    { 87, "قطور", 2, "قطور", "Active" },
                    { 88, "قوشچی", 2, "قوشچی", "Active" },
                    { 89, "کشاورز", 2, "کشاورز", "Active" },
                    { 90, "گردکشانه", 2, "گردکشانه", "Active" },
                    { 91, "ماکو", 2, "ماکو", "Active" },
                    { 92, "محمدیار", 2, "محمدیار", "Active" },
                    { 93, "محمودآباد", 2, "آذربایجان-غربی-محمودآباد", "Active" },
                    { 94, "مهاباد", 2, "آذربایجان-غربی-مهاباد", "Active" },
                    { 95, "میاندوآب", 2, "میاندوآب", "Active" },
                    { 96, "میرآباد", 2, "میرآباد", "Active" },
                    { 97, "نالوس", 2, "نالوس", "Active" },
                    { 98, "نقده", 2, "نقده", "Active" },
                    { 99, "نوشین", 2, "نوشین", "Active" },
                    { 100, "اردبیل", 3, "اردبیل", "Active" },
                    { 101, "اصلاندوز", 3, "اصلاندوز", "Active" },
                    { 102, "آبی بیگلو", 3, "آبی-بیگلو", "Active" },
                    { 103, "بیله سوار", 3, "بیله-سوار", "Active" },
                    { 104, "پارس آباد", 3, "پارس-آباد", "Active" },
                    { 105, "تازه کند", 3, "تازه-کند", "Active" },
                    { 106, "تازه کندانگوت", 3, "تازه-کندانگوت", "Active" },
                    { 107, "جعفرآباد", 3, "جعفرآباد", "Active" },
                    { 108, "خلخال", 3, "خلخال", "Active" },
                    { 109, "رضی", 3, "رضی", "Active" },
                    { 110, "سرعین", 3, "سرعین", "Active" },
                    { 111, "عنبران", 3, "عنبران", "Active" },
                    { 112, "فخرآباد", 3, "فخرآباد", "Active" },
                    { 113, "کلور", 3, "کلور", "Active" },
                    { 114, "کوراییم", 3, "کوراییم", "Active" },
                    { 115, "گرمی", 3, "گرمی", "Active" },
                    { 116, "گیوی", 3, "گیوی", "Active" },
                    { 117, "لاهرود", 3, "لاهرود", "Active" },
                    { 118, "مشگین شهر", 3, "مشگین-شهر", "Active" },
                    { 119, "نمین", 3, "نمین", "Active" },
                    { 120, "نیر", 3, "اردبیل-نیر", "Active" },
                    { 121, "هشتجین", 3, "هشتجین", "Active" },
                    { 122, "هیر", 3, "هیر", "Active" },
                    { 123, "ابریشم", 4, "ابریشم", "Active" },
                    { 124, "ابوزیدآباد", 4, "ابوزیدآباد", "Active" },
                    { 125, "اردستان", 4, "اردستان", "Active" },
                    { 126, "اژیه", 4, "اژیه", "Active" },
                    { 127, "اصفهان", 4, "اصفهان", "Active" },
                    { 128, "افوس", 4, "افوس", "Active" },
                    { 129, "انارک", 4, "انارک", "Active" },
                    { 130, "ایمانشهر", 4, "ایمانشهر", "Active" },
                    { 131, "آران وبیدگل", 4, "آران-وبیدگل", "Active" },
                    { 132, "بادرود", 4, "بادرود", "Active" },
                    { 133, "باغ بهادران", 4, "باغ-بهادران", "Active" },
                    { 134, "بافران", 4, "بافران", "Active" },
                    { 135, "برزک", 4, "برزک", "Active" },
                    { 136, "برف انبار", 4, "برف-انبار", "Active" },
                    { 137, "بهاران شهر", 4, "بهاران-شهر", "Active" },
                    { 138, "بهارستان", 4, "بهارستان", "Active" },
                    { 139, "بوئین و میاندشت", 4, "بوئین-میاندشت", "Active" },
                    { 140, "پیربکران", 4, "پیربکران", "Active" },
                    { 141, "تودشک", 4, "تودشک", "Active" },
                    { 142, "تیران", 4, "تیران", "Active" },
                    { 143, "جندق", 4, "جندق", "Active" },
                    { 144, "جوزدان", 4, "جوزدان", "Active" },
                    { 145, "جوشقان و کامو", 4, "جوشقان-کامو", "Active" },
                    { 146, "چادگان", 4, "چادگان", "Active" },
                    { 147, "چرمهین", 4, "چرمهین", "Active" },
                    { 148, "چمگردان", 4, "چمگردان", "Active" },
                    { 149, "حبیب آباد", 4, "حبیب-آباد", "Active" },
                    { 150, "حسن آباد", 4, "اصفهان-حسن-آباد", "Active" },
                    { 151, "حنا", 4, "حنا", "Active" },
                    { 152, "خالدآباد", 4, "خالدآباد", "Active" },
                    { 153, "خمینی شهر", 4, "خمینی-شهر", "Active" },
                    { 154, "خوانسار", 4, "خوانسار", "Active" },
                    { 155, "خور", 4, "اصفهان-خور", "Active" },
                    { 157, "خورزوق", 4, "خورزوق", "Active" },
                    { 158, "داران", 4, "داران", "Active" },
                    { 159, "دامنه", 4, "دامنه", "Active" },
                    { 160, "درچه", 4, "درچه", "Active" },
                    { 161, "دستگرد", 4, "دستگرد", "Active" },
                    { 162, "دهاقان", 4, "دهاقان", "Active" },
                    { 163, "دهق", 4, "دهق", "Active" },
                    { 164, "دولت آباد", 4, "اصفهان-دولت-آباد", "Active" },
                    { 165, "دیزیچه", 4, "دیزیچه", "Active" },
                    { 166, "رزوه", 4, "رزوه", "Active" },
                    { 167, "رضوانشهر", 4, "اصفهان-رضوانشهر", "Active" },
                    { 168, "زاینده رود", 4, "زاینده-رود", "Active" },
                    { 169, "زرین شهر", 4, "زرین-شهر", "Active" },
                    { 170, "زواره", 4, "زواره", "Active" },
                    { 171, "زیباشهر", 4, "زیباشهر", "Active" },
                    { 172, "سده لنجان", 4, "سده-لنجان", "Active" },
                    { 173, "سفیدشهر", 4, "سفیدشهر", "Active" },
                    { 174, "سگزی", 4, "سگزی", "Active" },
                    { 175, "سمیرم", 4, "سمیرم", "Active" },
                    { 176, "شاهین شهر", 4, "شاهین-شهر", "Active" },
                    { 177, "شهرضا", 4, "شهرضا", "Active" },
                    { 178, "طالخونچه", 4, "طالخونچه", "Active" },
                    { 179, "عسگران", 4, "عسگران", "Active" },
                    { 180, "علویجه", 4, "علویجه", "Active" },
                    { 181, "فرخی", 4, "فرخی", "Active" },
                    { 182, "فریدونشهر", 4, "فریدونشهر", "Active" },
                    { 183, "فلاورجان", 4, "فلاورجان", "Active" },
                    { 184, "فولادشهر", 4, "فولادشهر", "Active" },
                    { 185, "قمصر", 4, "قمصر", "Active" },
                    { 186, "قهجاورستان", 4, "قهجاورستان", "Active" },
                    { 187, "قهدریجان", 4, "قهدریجان", "Active" },
                    { 188, "کاشان", 4, "کاشان", "Active" },
                    { 189, "کرکوند", 4, "کرکوند", "Active" },
                    { 190, "کلیشاد و سودرجان", 4, "کلیشاد-سودرجان", "Active" },
                    { 191, "کمشچه", 4, "کمشچه", "Active" },
                    { 192, "کمه", 4, "کمه", "Active" },
                    { 193, "کهریزسنگ", 4, "کهریزسنگ", "Active" },
                    { 194, "کوشک", 4, "کوشک", "Active" },
                    { 195, "کوهپایه", 4, "کوهپایه", "Active" },
                    { 196, "گرگاب", 4, "گرگاب", "Active" },
                    { 197, "گزبرخوار", 4, "گزبرخوار", "Active" },
                    { 198, "گلپایگان", 4, "گلپایگان", "Active" },
                    { 199, "گلدشت", 4, "گلدشت", "Active" },
                    { 200, "گلشهر", 4, "گلشهر", "Active" },
                    { 201, "گوگد", 4, "گوگد", "Active" },
                    { 202, "لای بید", 4, "لای-بید", "Active" },
                    { 203, "مبارکه", 4, "مبارکه", "Active" },
                    { 204, "مجلسی", 4, "مجلسی", "Active" },
                    { 205, "محمدآباد", 4, "اصفهان-محمدآباد", "Active" },
                    { 206, "مشکات", 4, "مشکات", "Active" },
                    { 207, "منظریه", 4, "منظریه", "Active" },
                    { 208, "مهاباد", 4, "اصفهان-مهاباد", "Active" },
                    { 209, "میمه", 4, "اصفهان-میمه", "Active" },
                    { 210, "نائین", 4, "نائین", "Active" },
                    { 211, "نجف آباد", 4, "نجف-آباد", "Active" },
                    { 212, "نصرآباد", 4, "اصفهان-نصرآباد", "Active" },
                    { 213, "نطنز", 4, "نطنز", "Active" },
                    { 214, "نوش آباد", 4, "نوش-آباد", "Active" },
                    { 215, "نیاسر", 4, "نیاسر", "Active" },
                    { 216, "نیک آباد", 4, "نیک-آباد", "Active" },
                    { 217, "هرند", 4, "هرند", "Active" },
                    { 218, "ورزنه", 4, "ورزنه", "Active" },
                    { 219, "ورنامخواست", 4, "ورنامخواست", "Active" },
                    { 220, "وزوان", 4, "وزوان", "Active" },
                    { 221, "ونک", 4, "ونک", "Active" },
                    { 222, "اسارا", 5, "اسارا", "Active" },
                    { 223, "اشتهارد", 5, "اشتهارد", "Active" },
                    { 224, "تنکمان", 5, "تنکمان", "Active" },
                    { 225, "چهارباغ", 5, "چهارباغ", "Active" },
                    { 226, "سعید آباد", 5, "سعید-آباد", "Active" },
                    { 227, "شهر جدید هشتگرد", 5, "شهر-جدید-هشتگرد", "Active" },
                    { 228, "طالقان", 5, "طالقان", "Active" },
                    { 229, "کرج", 5, "کرج", "Active" },
                    { 230, "کمال شهر", 5, "کمال-شهر", "Active" },
                    { 231, "کوهسار", 5, "کوهسار", "Active" },
                    { 232, "گرمدره", 5, "گرمدره", "Active" },
                    { 233, "ماهدشت", 5, "ماهدشت", "Active" },
                    { 234, "محمدشهر", 5, "البرز-محمدشهر", "Active" },
                    { 235, "مشکین دشت", 5, "مشکین-دشت", "Active" },
                    { 236, "نظرآباد", 5, "نظرآباد", "Active" },
                    { 237, "هشتگرد", 5, "هشتگرد", "Active" },
                    { 238, "ارکواز", 6, "ارکواز", "Active" },
                    { 239, "ایلام", 6, "ایلام", "Active" },
                    { 240, "ایوان", 6, "ایوان", "Active" },
                    { 241, "آبدانان", 6, "آبدانان", "Active" },
                    { 242, "آسمان آباد", 6, "آسمان-آباد", "Active" },
                    { 243, "بدره", 6, "بدره", "Active" },
                    { 244, "پهله", 6, "پهله", "Active" },
                    { 245, "توحید", 6, "توحید", "Active" },
                    { 246, "چوار", 6, "چوار", "Active" },
                    { 247, "دره شهر", 6, "دره-شهر", "Active" },
                    { 248, "دلگشا", 6, "دلگشا", "Active" },
                    { 249, "دهلران", 6, "دهلران", "Active" },
                    { 250, "زرنه", 6, "زرنه", "Active" },
                    { 251, "سراب باغ", 6, "سراب-باغ", "Active" },
                    { 252, "سرابله", 6, "سرابله", "Active" },
                    { 253, "صالح آباد", 6, "ایلام-صالح-آباد", "Active" },
                    { 254, "لومار", 6, "لومار", "Active" },
                    { 255, "مهران", 6, "مهران", "Active" },
                    { 256, "مورموری", 6, "مورموری", "Active" },
                    { 257, "موسیان", 6, "موسیان", "Active" },
                    { 258, "میمه", 6, "ایلام-میمه", "Active" },
                    { 259, "امام حسن", 7, "امام-حسن", "Active" },
                    { 260, "انارستان", 7, "انارستان", "Active" },
                    { 261, "اهرم", 7, "اهرم", "Active" },
                    { 262, "آب پخش", 7, "آب-پخش", "Active" },
                    { 263, "آبدان", 7, "آبدان", "Active" },
                    { 264, "برازجان", 7, "برازجان", "Active" },
                    { 265, "بردخون", 7, "بردخون", "Active" },
                    { 266, "بندردیر", 7, "بندردیر", "Active" },
                    { 267, "بندردیلم", 7, "بندردیلم", "Active" },
                    { 268, "بندرریگ", 7, "بندرریگ", "Active" },
                    { 269, "بندرکنگان", 7, "بندرکنگان", "Active" },
                    { 270, "بندرگناوه", 7, "بندرگناوه", "Active" },
                    { 271, "بنک", 7, "بنک", "Active" },
                    { 272, "بوشهر", 7, "بوشهر", "Active" },
                    { 273, "تنگ ارم", 7, "تنگ-ارم", "Active" },
                    { 274, "جم", 7, "جم", "Active" },
                    { 275, "چغادک", 7, "چغادک", "Active" },
                    { 276, "خارک", 7, "خارک", "Active" },
                    { 277, "خورموج", 7, "خورموج", "Active" },
                    { 278, "دالکی", 7, "دالکی", "Active" },
                    { 279, "دلوار", 7, "دلوار", "Active" },
                    { 280, "ریز", 7, "ریز", "Active" },
                    { 281, "سعدآباد", 7, "سعدآباد", "Active" },
                    { 282, "سیراف", 7, "سیراف", "Active" },
                    { 283, "شبانکاره", 7, "شبانکاره", "Active" },
                    { 284, "شنبه", 7, "شنبه", "Active" },
                    { 285, "عسلویه", 7, "عسلویه", "Active" },
                    { 286, "کاکی", 7, "کاکی", "Active" },
                    { 287, "کلمه", 7, "کلمه", "Active" },
                    { 288, "نخل تقی", 7, "نخل-تقی", "Active" },
                    { 289, "وحدتیه", 7, "وحدتیه", "Active" },
                    { 290, "ارجمند", 8, "ارجمند", "Active" },
                    { 291, "اسلامشهر", 8, "اسلامشهر", "Active" },
                    { 292, "اندیشه", 8, "اندیشه", "Active" },
                    { 293, "آبسرد", 8, "آبسرد", "Active" },
                    { 294, "آبعلی", 8, "آبعلی", "Active" },
                    { 295, "باغستان", 8, "باغستان", "Active" },
                    { 296, "باقرشهر", 8, "باقرشهر", "Active" },
                    { 297, "بومهن", 8, "بومهن", "Active" },
                    { 298, "پاکدشت", 8, "پاکدشت", "Active" },
                    { 299, "پردیس", 8, "پردیس", "Active" },
                    { 300, "پیشوا", 8, "پیشوا", "Active" },
                    { 301, "تهران", 8, "تهران", "Active" },
                    { 302, "جوادآباد", 8, "جوادآباد", "Active" },
                    { 303, "چهاردانگه", 8, "چهاردانگه", "Active" },
                    { 304, "حسن آباد", 8, "تهران-حسن-آباد", "Active" },
                    { 305, "دماوند", 8, "دماوند", "Active" },
                    { 306, "دیزین", 8, "دیزین", "Active" },
                    { 307, "شهر ری", 8, "شهر-ری", "Active" },
                    { 308, "رباط کریم", 8, "رباط-کریم", "Active" },
                    { 309, "رودهن", 8, "رودهن", "Active" },
                    { 310, "شاهدشهر", 8, "شاهدشهر", "Active" },
                    { 311, "شریف آباد", 8, "شریف-آباد", "Active" },
                    { 312, "شمشک", 8, "شمشک", "Active" },
                    { 313, "شهریار", 8, "شهریار", "Active" },
                    { 314, "صالح آباد", 8, "تهران-صالح-آباد", "Active" },
                    { 315, "صباشهر", 8, "صباشهر", "Active" },
                    { 316, "صفادشت", 8, "صفادشت", "Active" },
                    { 317, "فردوسیه", 8, "فردوسیه", "Active" },
                    { 318, "فشم", 8, "فشم", "Active" },
                    { 319, "فیروزکوه", 8, "فیروزکوه", "Active" },
                    { 320, "قدس", 8, "قدس", "Active" },
                    { 321, "قرچک", 8, "قرچک", "Active" },
                    { 322, "کهریزک", 8, "کهریزک", "Active" },
                    { 323, "کیلان", 8, "کیلان", "Active" },
                    { 324, "گلستان", 8, "شهر-گلستان", "Active" },
                    { 325, "لواسان", 8, "لواسان", "Active" },
                    { 326, "ملارد", 8, "ملارد", "Active" },
                    { 327, "میگون", 8, "میگون", "Active" },
                    { 328, "نسیم شهر", 8, "نسیم-شهر", "Active" },
                    { 329, "نصیرآباد", 8, "نصیرآباد", "Active" },
                    { 330, "وحیدیه", 8, "وحیدیه", "Active" },
                    { 331, "ورامین", 8, "ورامین", "Active" },
                    { 332, "اردل", 9, "اردل", "Active" },
                    { 333, "آلونی", 9, "آلونی", "Active" },
                    { 334, "باباحیدر", 9, "باباحیدر", "Active" },
                    { 335, "بروجن", 9, "بروجن", "Active" },
                    { 336, "بلداجی", 9, "بلداجی", "Active" },
                    { 337, "بن", 9, "بن", "Active" },
                    { 338, "جونقان", 9, "جونقان", "Active" },
                    { 339, "چلگرد", 9, "چلگرد", "Active" },
                    { 340, "سامان", 9, "سامان", "Active" },
                    { 341, "سفیددشت", 9, "سفیددشت", "Active" },
                    { 342, "سودجان", 9, "سودجان", "Active" },
                    { 343, "سورشجان", 9, "سورشجان", "Active" },
                    { 344, "شلمزار", 9, "شلمزار", "Active" },
                    { 345, "شهرکرد", 9, "شهرکرد", "Active" },
                    { 346, "طاقانک", 9, "طاقانک", "Active" },
                    { 347, "فارسان", 9, "فارسان", "Active" },
                    { 348, "فرادنبه", 9, "فرادبنه", "Active" },
                    { 349, "فرخ شهر", 9, "فرخ-شهر", "Active" },
                    { 350, "کیان", 9, "کیان", "Active" },
                    { 351, "گندمان", 9, "گندمان", "Active" },
                    { 352, "گهرو", 9, "گهرو", "Active" },
                    { 353, "لردگان", 9, "لردگان", "Active" },
                    { 354, "مال خلیفه", 9, "مال-خلیفه", "Active" },
                    { 355, "ناغان", 9, "ناغان", "Active" },
                    { 356, "نافچ", 9, "نافچ", "Active" },
                    { 357, "نقنه", 9, "نقنه", "Active" },
                    { 358, "هفشجان", 9, "هفشجان", "Active" },
                    { 359, "ارسک", 10, "ارسک", "Active" },
                    { 360, "اسدیه", 10, "اسدیه", "Active" },
                    { 361, "اسفدن", 10, "اسفدن", "Active" },
                    { 362, "اسلامیه", 10, "اسلامیه", "Active" },
                    { 363, "آرین شهر", 10, "آرین-شهر", "Active" },
                    { 364, "آیسک", 10, "آیسک", "Active" },
                    { 365, "بشرویه", 10, "بشرویه", "Active" },
                    { 366, "بیرجند", 10, "بیرجند", "Active" },
                    { 367, "حاجی آباد", 10, "خراسان-جنوبی-حاجی-آباد", "Active" },
                    { 368, "خضری دشت بیاض", 10, "خضری-دشت-بیاض", "Active" },
                    { 369, "خوسف", 10, "خوسف", "Active" },
                    { 370, "زهان", 10, "زهان", "Active" },
                    { 371, "سرایان", 10, "سرایان", "Active" },
                    { 372, "سربیشه", 10, "سربیشه", "Active" },
                    { 373, "سه قلعه", 10, "سه-قلعه", "Active" },
                    { 374, "شوسف", 10, "شوسف", "Active" },
                    { 375, "طبس ", 10, "خراسان-جنوبی-طبس-", "Active" },
                    { 376, "فردوس", 10, "فردوس", "Active" },
                    { 377, "قاین", 10, "قاین", "Active" },
                    { 378, "قهستان", 10, "قهستان", "Active" },
                    { 379, "محمدشهر", 10, "خراسان-جنوبی-محمدشهر", "Active" },
                    { 380, "مود", 10, "مود", "Active" },
                    { 381, "نهبندان", 10, "نهبندان", "Active" },
                    { 382, "نیمبلوک", 10, "نیمبلوک", "Active" },
                    { 383, "احمدآباد صولت", 11, "احمدآباد-صولت", "Active" },
                    { 384, "انابد", 11, "انابد", "Active" },
                    { 385, "باجگیران", 11, "باجگیران", "Active" },
                    { 386, "باخرز", 11, "باخرز", "Active" },
                    { 387, "بار", 11, "بار", "Active" },
                    { 388, "بایگ", 11, "بایگ", "Active" },
                    { 389, "بجستان", 11, "بجستان", "Active" },
                    { 390, "بردسکن", 11, "بردسکن", "Active" },
                    { 391, "بیدخت", 11, "بیدخت", "Active" },
                    { 392, "تایباد", 11, "تایباد", "Active" },
                    { 393, "تربت جام", 11, "تربت-جام", "Active" },
                    { 394, "تربت حیدریه", 11, "تربت-حیدریه", "Active" },
                    { 395, "جغتای", 11, "جغتای", "Active" },
                    { 396, "جنگل", 11, "جنگل", "Active" },
                    { 397, "چاپشلو", 11, "چاپشلو", "Active" },
                    { 398, "چکنه", 11, "چکنه", "Active" },
                    { 399, "چناران", 11, "چناران", "Active" },
                    { 400, "خرو", 11, "خرو", "Active" },
                    { 401, "خلیل آباد", 11, "خلیل-آباد", "Active" },
                    { 402, "خواف", 11, "خواف", "Active" },
                    { 403, "داورزن", 11, "داورزن", "Active" },
                    { 404, "درگز", 11, "درگز", "Active" },
                    { 405, "در رود", 11, "در-رود", "Active" },
                    { 406, "دولت آباد", 11, "خراسان-رضوی-دولت-آباد", "Active" },
                    { 407, "رباط سنگ", 11, "رباط-سنگ", "Active" },
                    { 408, "رشتخوار", 11, "رشتخوار", "Active" },
                    { 409, "رضویه", 11, "رضویه", "Active" },
                    { 410, "روداب", 11, "روداب", "Active" },
                    { 411, "ریوش", 11, "ریوش", "Active" },
                    { 412, "سبزوار", 11, "سبزوار", "Active" },
                    { 413, "سرخس", 11, "سرخس", "Active" },
                    { 414, "سفیدسنگ", 11, "سفیدسنگ", "Active" },
                    { 415, "سلامی", 11, "سلامی", "Active" },
                    { 416, "سلطان آباد", 11, "سلطان-آباد", "Active" },
                    { 417, "سنگان", 11, "سنگان", "Active" },
                    { 418, "شادمهر", 11, "شادمهر", "Active" },
                    { 419, "شاندیز", 11, "شاندیز", "Active" },
                    { 420, "ششتمد", 11, "ششتمد", "Active" },
                    { 421, "شهرآباد", 11, "شهرآباد", "Active" },
                    { 422, "شهرزو", 11, "شهرزو", "Active" },
                    { 423, "صالح آباد", 11, "خراسان-رضوی-صالح-آباد", "Active" },
                    { 424, "طرقبه", 11, "طرقبه", "Active" },
                    { 425, "عشق آباد", 11, "خراسان-رضوی-عشق-آباد", "Active" },
                    { 426, "فرهادگرد", 11, "فرهادگرد", "Active" },
                    { 427, "فریمان", 11, "فریمان", "Active" },
                    { 428, "فیروزه", 11, "فیروزه", "Active" },
                    { 429, "فیض آباد", 11, "فیض-آباد", "Active" },
                    { 430, "قاسم آباد", 11, "قاسم-آباد", "Active" },
                    { 431, "قدمگاه", 11, "قدمگاه", "Active" },
                    { 432, "قلندرآباد", 11, "قلندرآباد", "Active" },
                    { 433, "قوچان", 11, "قوچان", "Active" },
                    { 434, "کاخک", 11, "کاخک", "Active" },
                    { 435, "کاریز", 11, "کاریز", "Active" },
                    { 436, "کاشمر", 11, "کاشمر", "Active" },
                    { 437, "کدکن", 11, "کدکن", "Active" },
                    { 438, "کلات", 11, "کلات", "Active" },
                    { 439, "کندر", 11, "کندر", "Active" },
                    { 440, "گلمکان", 11, "گلمکان", "Active" },
                    { 441, "گناباد", 11, "گناباد", "Active" },
                    { 442, "لطف آباد", 11, "لطف-آباد", "Active" },
                    { 443, "مزدآوند", 11, "مزدآوند", "Active" },
                    { 444, "مشهد", 11, "مشهد", "Active" },
                    { 445, "ملک آباد", 11, "ملک-آباد", "Active" },
                    { 446, "نشتیفان", 11, "نشتیفان", "Active" },
                    { 447, "نصرآباد", 11, "خراسان-رضوی-نصرآباد", "Active" },
                    { 448, "نقاب", 11, "نقاب", "Active" },
                    { 449, "نوخندان", 11, "نوخندان", "Active" },
                    { 450, "نیشابور", 11, "نیشابور", "Active" },
                    { 451, "نیل شهر", 11, "نیل-شهر", "Active" },
                    { 452, "همت آباد", 11, "همت-آباد", "Active" },
                    { 453, "یونسی", 11, "یونسی", "Active" },
                    { 454, "اسفراین", 12, "اسفراین", "Active" },
                    { 455, "ایور", 12, "ایور", "Active" },
                    { 456, "آشخانه", 12, "آشخانه", "Active" },
                    { 457, "بجنورد", 12, "بجنورد", "Active" },
                    { 458, "پیش قلعه", 12, "پیش-قلعه", "Active" },
                    { 459, "تیتکانلو", 12, "تیتکانلو", "Active" },
                    { 460, "جاجرم", 12, "جاجرم", "Active" },
                    { 461, "حصارگرمخان", 12, "حصارگرمخان", "Active" },
                    { 462, "درق", 12, "درق", "Active" },
                    { 463, "راز", 12, "راز", "Active" },
                    { 464, "سنخواست", 12, "سنخواست", "Active" },
                    { 465, "شوقان", 12, "شوقان", "Active" },
                    { 466, "شیروان", 12, "شیروان", "Active" },
                    { 467, "صفی آباد", 12, "خراسان-شمالی-صفی-آباد", "Active" },
                    { 468, "فاروج", 12, "فاروج", "Active" },
                    { 469, "قاضی", 12, "قاضی", "Active" },
                    { 470, "گرمه", 12, "گرمه", "Active" },
                    { 471, "لوجلی", 12, "لوجلی", "Active" },
                    { 472, "اروندکنار", 13, "اروندکنار", "Active" },
                    { 473, "الوان", 13, "الوان", "Active" },
                    { 474, "امیدیه", 13, "امیدیه", "Active" },
                    { 475, "اندیمشک", 13, "اندیمشک", "Active" },
                    { 476, "اهواز", 13, "اهواز", "Active" },
                    { 477, "ایذه", 13, "ایذه", "Active" },
                    { 478, "آبادان", 13, "آبادان", "Active" },
                    { 479, "آغاجاری", 13, "آغاجاری", "Active" },
                    { 480, "باغ ملک", 13, "باغ-ملک", "Active" },
                    { 481, "بستان", 13, "بستان", "Active" },
                    { 482, "بندرامام خمینی", 13, "بندرامام-خمینی", "Active" },
                    { 483, "بندرماهشهر", 13, "بندرماهشهر", "Active" },
                    { 484, "بهبهان", 13, "بهبهان", "Active" },
                    { 485, "ترکالکی", 13, "ترکالکی", "Active" },
                    { 486, "جایزان", 13, "جایزان", "Active" },
                    { 487, "چمران", 13, "چمران", "Active" },
                    { 488, "چویبده", 13, "چویبده", "Active" },
                    { 489, "حر", 13, "حر", "Active" },
                    { 490, "حسینیه", 13, "حسینیه", "Active" },
                    { 491, "حمزه", 13, "حمزه", "Active" },
                    { 492, "حمیدیه", 13, "حمیدیه", "Active" },
                    { 493, "خرمشهر", 13, "خرمشهر", "Active" },
                    { 494, "دارخوین", 13, "دارخوین", "Active" },
                    { 495, "دزآب", 13, "دزآب", "Active" },
                    { 496, "دزفول", 13, "دزفول", "Active" },
                    { 497, "دهدز", 13, "دهدز", "Active" },
                    { 498, "رامشیر", 13, "رامشیر", "Active" },
                    { 499, "رامهرمز", 13, "رامهرمز", "Active" },
                    { 500, "رفیع", 13, "رفیع", "Active" },
                    { 501, "زهره", 13, "زهره", "Active" },
                    { 502, "سالند", 13, "سالند", "Active" },
                    { 503, "سردشت", 13, "خوزستان-سردشت", "Active" },
                    { 504, "سوسنگرد", 13, "سوسنگرد", "Active" },
                    { 505, "شادگان", 13, "شادگان", "Active" },
                    { 506, "شاوور", 13, "شاوور", "Active" },
                    { 507, "شرافت", 13, "شرافت", "Active" },
                    { 508, "شوش", 13, "شوش", "Active" },
                    { 509, "شوشتر", 13, "شوشتر", "Active" },
                    { 510, "شیبان", 13, "شیبان", "Active" },
                    { 511, "صالح شهر", 13, "صالح-شهر", "Active" },
                    { 512, "صفی آباد", 13, "خوزستان-صفی-آباد", "Active" },
                    { 513, "صیدون", 13, "صیدون", "Active" },
                    { 514, "قلعه تل", 13, "قلعه-تل", "Active" },
                    { 515, "قلعه خواجه", 13, "قلعه-خواجه", "Active" },
                    { 516, "گتوند", 13, "گتوند", "Active" },
                    { 517, "لالی", 13, "لالی", "Active" },
                    { 518, "مسجدسلیمان", 13, "مسجدسلیمان", "Active" },
                    { 520, "ملاثانی", 13, "ملاثانی", "Active" },
                    { 521, "میانرود", 13, "میانرود", "Active" },
                    { 522, "مینوشهر", 13, "مینوشهر", "Active" },
                    { 523, "هفتگل", 13, "هفتگل", "Active" },
                    { 524, "هندیجان", 13, "هندیجان", "Active" },
                    { 525, "هویزه", 13, "هویزه", "Active" },
                    { 526, "ویس", 13, "ویس", "Active" },
                    { 527, "ابهر", 14, "ابهر", "Active" },
                    { 528, "ارمغان خانه", 14, "ارمغان-خانه", "Active" },
                    { 529, "آب بر", 14, "آب-بر", "Active" },
                    { 530, "چورزق", 14, "چورزق", "Active" },
                    { 531, "حلب", 14, "حلب", "Active" },
                    { 532, "خرمدره", 14, "خرمدره", "Active" },
                    { 533, "دندی", 14, "دندی", "Active" },
                    { 534, "زرین آباد", 14, "زرین-آباد", "Active" },
                    { 535, "زرین رود", 14, "زرین-رود", "Active" },
                    { 536, "زنجان", 14, "زنجان", "Active" },
                    { 537, "سجاس", 14, "سجاس", "Active" },
                    { 538, "سلطانیه", 14, "سلطانیه", "Active" },
                    { 539, "سهرورد", 14, "سهرورد", "Active" },
                    { 540, "صائین قلعه", 14, "صائین-قلعه", "Active" },
                    { 541, "قیدار", 14, "قیدار", "Active" },
                    { 542, "گرماب", 14, "گرماب", "Active" },
                    { 543, "ماه نشان", 14, "ماه-نشان", "Active" },
                    { 544, "هیدج", 14, "هیدج", "Active" },
                    { 545, "امیریه", 15, "امیریه", "Active" },
                    { 546, "ایوانکی", 15, "ایوانکی", "Active" },
                    { 547, "آرادان", 15, "آرادان", "Active" },
                    { 548, "بسطام", 15, "بسطام", "Active" },
                    { 549, "بیارجمند", 15, "بیارجمند", "Active" },
                    { 550, "دامغان", 15, "دامغان", "Active" },
                    { 551, "درجزین", 15, "درجزین", "Active" },
                    { 552, "دیباج", 15, "دیباج", "Active" },
                    { 553, "سرخه", 15, "سرخه", "Active" },
                    { 554, "سمنان", 15, "سمنان", "Active" },
                    { 555, "شاهرود", 15, "شاهرود", "Active" },
                    { 556, "شهمیرزاد", 15, "شهمیرزاد", "Active" },
                    { 557, "کلاته خیج", 15, "کلاته-خیج", "Active" },
                    { 558, "گرمسار", 15, "گرمسار", "Active" },
                    { 559, "مجن", 15, "مجن", "Active" },
                    { 560, "مهدی شهر", 15, "مهدی-شهر", "Active" },
                    { 561, "میامی", 15, "میامی", "Active" },
                    { 562, "ادیمی", 16, "ادیمی", "Active" },
                    { 563, "اسپکه", 16, "اسپکه", "Active" },
                    { 564, "ایرانشهر", 16, "ایرانشهر", "Active" },
                    { 565, "بزمان", 16, "بزمان", "Active" },
                    { 566, "بمپور", 16, "بمپور", "Active" },
                    { 567, "بنت", 16, "بنت", "Active" },
                    { 568, "بنجار", 16, "بنجار", "Active" },
                    { 569, "پیشین", 16, "پیشین", "Active" },
                    { 570, "جالق", 16, "جالق", "Active" },
                    { 571, "چابهار", 16, "چابهار", "Active" },
                    { 572, "خاش", 16, "خاش", "Active" },
                    { 573, "دوست محمد", 16, "دوست-محمد", "Active" },
                    { 574, "راسک", 16, "راسک", "Active" },
                    { 575, "زابل", 16, "زابل", "Active" },
                    { 576, "زابلی", 16, "زابلی", "Active" },
                    { 577, "زاهدان", 16, "زاهدان", "Active" },
                    { 578, "زهک", 16, "زهک", "Active" },
                    { 579, "سراوان", 16, "سراوان", "Active" },
                    { 580, "سرباز", 16, "سرباز", "Active" },
                    { 581, "سوران", 16, "سوران", "Active" },
                    { 582, "سیرکان", 16, "سیرکان", "Active" },
                    { 583, "علی اکبر", 16, "علی-اکبر", "Active" },
                    { 584, "فنوج", 16, "فنوج", "Active" },
                    { 585, "قصرقند", 16, "قصرقند", "Active" },
                    { 586, "کنارک", 16, "کنارک", "Active" },
                    { 587, "گشت", 16, "گشت", "Active" },
                    { 588, "گلمورتی", 16, "گلمورتی", "Active" },
                    { 589, "محمدان", 16, "محمدان", "Active" },
                    { 590, "محمدآباد", 16, "سیستان-و-بلوچستان-محمدآباد", "Active" },
                    { 591, "محمدی", 16, "محمدی", "Active" },
                    { 592, "میرجاوه", 16, "میرجاوه", "Active" },
                    { 593, "نصرت آباد", 16, "نصرت-آباد", "Active" },
                    { 594, "نگور", 16, "نگور", "Active" },
                    { 595, "نوک آباد", 16, "نوک-آباد", "Active" },
                    { 596, "نیک شهر", 16, "نیک-شهر", "Active" },
                    { 597, "هیدوچ", 16, "هیدوچ", "Active" },
                    { 598, "اردکان", 17, "فارس-اردکان", "Active" },
                    { 599, "ارسنجان", 17, "ارسنجان", "Active" },
                    { 600, "استهبان", 17, "استهبان", "Active" },
                    { 601, "اشکنان", 17, "اشکنان", "Active" },
                    { 602, "افزر", 17, "افزر", "Active" },
                    { 603, "اقلید", 17, "اقلید", "Active" },
                    { 604, "امام شهر", 17, "امام-شهر", "Active" },
                    { 605, "اهل", 17, "اهل", "Active" },
                    { 606, "اوز", 17, "اوز", "Active" },
                    { 607, "ایج", 17, "ایج", "Active" },
                    { 608, "ایزدخواست", 17, "ایزدخواست", "Active" },
                    { 609, "آباده", 17, "آباده", "Active" },
                    { 610, "آباده طشک", 17, "آباده-طشک", "Active" },
                    { 611, "باب انار", 17, "باب-انار", "Active" },
                    { 612, "بالاده", 17, "فارس-بالاده", "Active" },
                    { 613, "بنارویه", 17, "بنارویه", "Active" },
                    { 614, "بهمن", 17, "بهمن", "Active" },
                    { 615, "بوانات", 17, "بوانات", "Active" },
                    { 616, "بیرم", 17, "بیرم", "Active" },
                    { 617, "بیضا", 17, "بیضا", "Active" },
                    { 618, "جنت شهر", 17, "جنت-شهر", "Active" },
                    { 619, "جهرم", 17, "جهرم", "Active" },
                    { 620, "جویم", 17, "جویم", "Active" },
                    { 621, "زرین دشت", 17, "زرین-دشت", "Active" },
                    { 622, "حسن آباد", 17, "فارس-حسن-آباد", "Active" },
                    { 623, "خان زنیان", 17, "خان-زنیان", "Active" },
                    { 624, "خاوران", 17, "خاوران", "Active" },
                    { 625, "خرامه", 17, "خرامه", "Active" },
                    { 626, "خشت", 17, "خشت", "Active" },
                    { 627, "خنج", 17, "خنج", "Active" },
                    { 628, "خور", 17, "فارس-خور", "Active" },
                    { 629, "داراب", 17, "داراب", "Active" },
                    { 630, "داریان", 17, "داریان", "Active" },
                    { 631, "دبیران", 17, "دبیران", "Active" },
                    { 632, "دژکرد", 17, "دژکرد", "Active" },
                    { 633, "دهرم", 17, "دهرم", "Active" },
                    { 634, "دوبرجی", 17, "دوبرجی", "Active" },
                    { 635, "رامجرد", 17, "رامجرد", "Active" },
                    { 636, "رونیز", 17, "رونیز", "Active" },
                    { 637, "زاهدشهر", 17, "زاهدشهر", "Active" },
                    { 638, "زرقان", 17, "زرقان", "Active" },
                    { 639, "سده", 17, "سده", "Active" },
                    { 640, "سروستان", 17, "سروستان", "Active" },
                    { 641, "سعادت شهر", 17, "سعادت-شهر", "Active" },
                    { 642, "سورمق", 17, "سورمق", "Active" },
                    { 643, "سیدان", 17, "سیدان", "Active" },
                    { 644, "ششده", 17, "ششده", "Active" },
                    { 645, "شهرپیر", 17, "شهرپیر", "Active" },
                    { 646, "شهرصدرا", 17, "شهرصدرا", "Active" },
                    { 647, "شیراز", 17, "شیراز", "Active" },
                    { 648, "صغاد", 17, "صغاد", "Active" },
                    { 649, "صفاشهر", 17, "صفاشهر", "Active" },
                    { 650, "علامرودشت", 17, "علامرودشت", "Active" },
                    { 651, "فدامی", 17, "فدامی", "Active" },
                    { 652, "فراشبند", 17, "فراشبند", "Active" },
                    { 653, "فسا", 17, "فسا", "Active" },
                    { 654, "فیروزآباد", 17, "فارس-فیروزآباد", "Active" },
                    { 655, "قائمیه", 17, "قائمیه", "Active" },
                    { 656, "قادرآباد", 17, "قادرآباد", "Active" },
                    { 657, "قطب آباد", 17, "قطب-آباد", "Active" },
                    { 658, "قطرویه", 17, "قطرویه", "Active" },
                    { 659, "قیر", 17, "قیر", "Active" },
                    { 660, "کارزین (فتح آباد)", 17, "کارزین-فتح-آباد", "Active" },
                    { 661, "کازرون", 17, "کازرون", "Active" },
                    { 662, "کامفیروز", 17, "کامفیروز", "Active" },
                    { 663, "کره ای", 17, "کره-ای", "Active" },
                    { 664, "کنارتخته", 17, "کنارتخته", "Active" },
                    { 665, "کوار", 17, "کوار", "Active" },
                    { 666, "گراش", 17, "گراش", "Active" },
                    { 667, "گله دار", 17, "گله-دار", "Active" },
                    { 668, "لار", 17, "لار", "Active" },
                    { 669, "لامرد", 17, "لامرد", "Active" },
                    { 670, "لپویی", 17, "لپویی", "Active" },
                    { 671, "لطیفی", 17, "لطیفی", "Active" },
                    { 672, "مبارک آباددیز", 17, "مبارک-آباددیز", "Active" },
                    { 673, "مرودشت", 17, "مرودشت", "Active" },
                    { 674, "مشکان", 17, "مشکان", "Active" },
                    { 675, "مصیری", 17, "مصیری", "Active" },
                    { 676, "مهر", 17, "مهر", "Active" },
                    { 677, "میمند", 17, "میمند", "Active" },
                    { 678, "نوبندگان", 17, "نوبندگان", "Active" },
                    { 679, "نوجین", 17, "نوجین", "Active" },
                    { 680, "نودان", 17, "نودان", "Active" },
                    { 681, "نورآباد", 17, "فارس-نورآباد", "Active" },
                    { 682, "نی ریز", 17, "نی-ریز", "Active" },
                    { 683, "وراوی", 17, "وراوی", "Active" },
                    { 684, "ارداق", 18, "ارداق", "Active" },
                    { 685, "اسفرورین", 18, "اسفرورین", "Active" },
                    { 686, "اقبالیه", 18, "اقبالیه", "Active" },
                    { 687, "الوند", 18, "الوند", "Active" },
                    { 688, "آبگرم", 18, "آبگرم", "Active" },
                    { 689, "آبیک", 18, "آبیک", "Active" },
                    { 690, "آوج", 18, "آوج", "Active" },
                    { 691, "بوئین زهرا", 18, "بوئین-زهرا", "Active" },
                    { 692, "بیدستان", 18, "بیدستان", "Active" },
                    { 693, "تاکستان", 18, "تاکستان", "Active" },
                    { 694, "خاکعلی", 18, "خاکعلی", "Active" },
                    { 695, "خرمدشت", 18, "خرمدشت", "Active" },
                    { 696, "دانسفهان", 18, "دانسفهان", "Active" },
                    { 697, "رازمیان", 18, "رازمیان", "Active" },
                    { 698, "سگزآباد", 18, "سگزآباد", "Active" },
                    { 699, "سیردان", 18, "سیردان", "Active" },
                    { 700, "شال", 18, "شال", "Active" },
                    { 701, "شریفیه", 18, "شریفیه", "Active" },
                    { 702, "ضیاآباد", 18, "ضیاآباد", "Active" },
                    { 703, "قزوین", 18, "قزوین", "Active" },
                    { 704, "کوهین", 18, "کوهین", "Active" },
                    { 705, "محمدیه", 18, "محمدیه", "Active" },
                    { 706, "محمودآباد نمونه", 18, "محمودآباد-نمونه", "Active" },
                    { 707, "معلم کلایه", 18, "معلم-کلایه", "Active" },
                    { 708, "نرجه", 18, "نرجه", "Active" },
                    { 709, "جعفریه", 19, "جعفریه", "Active" },
                    { 710, "دستجرد", 19, "دستجرد", "Active" },
                    { 711, "سلفچگان", 19, "سلفچگان", "Active" },
                    { 712, "قم", 19, "قم", "Active" },
                    { 713, "قنوات", 19, "قنوات", "Active" },
                    { 714, "کهک", 19, "کهک", "Active" },
                    { 715, "آرمرده", 20, "آرمرده", "Active" },
                    { 716, "بابارشانی", 20, "بابارشانی", "Active" },
                    { 717, "بانه", 20, "بانه", "Active" },
                    { 718, "بلبان آباد", 20, "بلبان-آباد", "Active" },
                    { 719, "بوئین سفلی", 20, "بوئین-سفلی", "Active" },
                    { 720, "بیجار", 20, "بیجار", "Active" },
                    { 721, "چناره", 20, "چناره", "Active" },
                    { 722, "دزج", 20, "دزج", "Active" },
                    { 723, "دلبران", 20, "دلبران", "Active" },
                    { 724, "دهگلان", 20, "دهگلان", "Active" },
                    { 725, "دیواندره", 20, "دیواندره", "Active" },
                    { 726, "زرینه", 20, "زرینه", "Active" },
                    { 727, "سروآباد", 20, "سروآباد", "Active" },
                    { 728, "سریش آباد", 20, "سریش-آباد", "Active" },
                    { 729, "سقز", 20, "سقز", "Active" },
                    { 730, "سنندج", 20, "سنندج", "Active" },
                    { 731, "شویشه", 20, "شویشه", "Active" },
                    { 732, "صاحب", 20, "صاحب", "Active" },
                    { 733, "قروه", 20, "قروه", "Active" },
                    { 734, "کامیاران", 20, "کامیاران", "Active" },
                    { 735, "کانی دینار", 20, "کانی-دینار", "Active" },
                    { 736, "کانی سور", 20, "کانی-سور", "Active" },
                    { 737, "مریوان", 20, "مریوان", "Active" },
                    { 738, "موچش", 20, "موچش", "Active" },
                    { 739, "یاسوکند", 20, "یاسوکند", "Active" },
                    { 740, "اختیارآباد", 21, "اختیارآباد", "Active" },
                    { 741, "ارزوئیه", 21, "ارزوئیه", "Active" },
                    { 742, "امین شهر", 21, "امین-شهر", "Active" },
                    { 743, "انار", 21, "انار", "Active" },
                    { 744, "اندوهجرد", 21, "اندوهجرد", "Active" },
                    { 745, "باغین", 21, "باغین", "Active" },
                    { 746, "بافت", 21, "بافت", "Active" },
                    { 747, "بردسیر", 21, "بردسیر", "Active" },
                    { 748, "بروات", 21, "بروات", "Active" },
                    { 749, "بزنجان", 21, "بزنجان", "Active" },
                    { 750, "بم", 21, "بم", "Active" },
                    { 751, "بهرمان", 21, "بهرمان", "Active" },
                    { 752, "پاریز", 21, "پاریز", "Active" },
                    { 753, "جبالبارز", 21, "جبالبارز", "Active" },
                    { 754, "جوپار", 21, "جوپار", "Active" },
                    { 755, "جوزم", 21, "جوزم", "Active" },
                    { 756, "جیرفت", 21, "جیرفت", "Active" },
                    { 757, "چترود", 21, "چترود", "Active" },
                    { 758, "خاتون آباد", 21, "خاتون-آباد", "Active" },
                    { 759, "خانوک", 21, "خانوک", "Active" },
                    { 760, "خورسند", 21, "خورسند", "Active" },
                    { 761, "درب بهشت", 21, "درب-بهشت", "Active" },
                    { 762, "دهج", 21, "دهج", "Active" },
                    { 763, "رابر", 21, "رابر", "Active" },
                    { 764, "راور", 21, "راور", "Active" },
                    { 765, "راین", 21, "راین", "Active" },
                    { 766, "رفسنجان", 21, "رفسنجان", "Active" },
                    { 767, "رودبار", 21, "کرمان-رودبار", "Active" },
                    { 768, "ریحان شهر", 21, "ریحان-شهر", "Active" },
                    { 769, "زرند", 21, "زرند", "Active" },
                    { 770, "زنگی آباد", 21, "زنگی-آباد", "Active" },
                    { 771, "زیدآباد", 21, "زیدآباد", "Active" },
                    { 772, "سیرجان", 21, "سیرجان", "Active" },
                    { 773, "شهداد", 21, "شهداد", "Active" },
                    { 774, "شهربابک", 21, "شهربابک", "Active" },
                    { 775, "صفائیه", 21, "صفائیه", "Active" },
                    { 776, "عنبرآباد", 21, "عنبرآباد", "Active" },
                    { 777, "فاریاب", 21, "فاریاب", "Active" },
                    { 778, "فهرج", 21, "فهرج", "Active" },
                    { 779, "قلعه گنج", 21, "قلعه-گنج", "Active" },
                    { 780, "کاظم آباد", 21, "کاظم-آباد", "Active" },
                    { 781, "کرمان", 21, "کرمان", "Active" },
                    { 782, "کشکوئیه", 21, "کشکوئیه", "Active" },
                    { 783, "کهنوج", 21, "کهنوج", "Active" },
                    { 784, "کوهبنان", 21, "کوهبنان", "Active" },
                    { 785, "کیانشهر", 21, "کیانشهر", "Active" },
                    { 786, "گلباف", 21, "گلباف", "Active" },
                    { 787, "گلزار", 21, "گلزار", "Active" },
                    { 788, "لاله زار", 21, "لاله-زار", "Active" },
                    { 789, "ماهان", 21, "ماهان", "Active" },
                    { 790, "محمدآباد", 21, "کرمان-محمدآباد", "Active" },
                    { 791, "محی آباد", 21, "محی-آباد", "Active" },
                    { 792, "مردهک", 21, "مردهک", "Active" },
                    { 793, "مس سرچشمه", 21, "مس-سرچشمه", "Active" },
                    { 794, "منوجان", 21, "منوجان", "Active" },
                    { 795, "نجف شهر", 21, "نجف-شهر", "Active" },
                    { 796, "نرماشیر", 21, "نرماشیر", "Active" },
                    { 797, "نظام شهر", 21, "نظام-شهر", "Active" },
                    { 798, "نگار", 21, "نگار", "Active" },
                    { 799, "نودژ", 21, "نودژ", "Active" },
                    { 800, "هجدک", 21, "هجدک", "Active" },
                    { 801, "یزدان شهر", 21, "یزدان-شهر", "Active" },
                    { 802, "ازگله", 22, "ازگله", "Active" },
                    { 803, "اسلام آباد غرب", 22, "اسلام-آباد-غرب", "Active" },
                    { 804, "باینگان", 22, "باینگان", "Active" },
                    { 805, "بیستون", 22, "بیستون", "Active" },
                    { 806, "پاوه", 22, "پاوه", "Active" },
                    { 807, "تازه آباد", 22, "تازه-آباد", "Active" },
                    { 808, "جوان رود", 22, "جوان-رود", "Active" },
                    { 809, "حمیل", 22, "حمیل", "Active" },
                    { 810, "ماهیدشت", 22, "ماهیدشت", "Active" },
                    { 811, "روانسر", 22, "روانسر", "Active" },
                    { 812, "سرپل ذهاب", 22, "سرپل-ذهاب", "Active" },
                    { 813, "سرمست", 22, "سرمست", "Active" },
                    { 814, "سطر", 22, "سطر", "Active" },
                    { 815, "سنقر", 22, "سنقر", "Active" },
                    { 816, "سومار", 22, "سومار", "Active" },
                    { 817, "شاهو", 22, "شاهو", "Active" },
                    { 818, "صحنه", 22, "صحنه", "Active" },
                    { 819, "قصرشیرین", 22, "قصرشیرین", "Active" },
                    { 820, "کرمانشاه", 22, "کرمانشاه", "Active" },
                    { 821, "کرندغرب", 22, "کرندغرب", "Active" },
                    { 822, "کنگاور", 22, "کنگاور", "Active" },
                    { 823, "کوزران", 22, "کوزران", "Active" },
                    { 824, "گهواره", 22, "گهواره", "Active" },
                    { 825, "گیلانغرب", 22, "گیلانغرب", "Active" },
                    { 826, "میان راهان", 22, "میان-راهان", "Active" },
                    { 827, "نودشه", 22, "نودشه", "Active" },
                    { 828, "نوسود", 22, "نوسود", "Active" },
                    { 829, "هرسین", 22, "هرسین", "Active" },
                    { 830, "هلشی", 22, "هلشی", "Active" },
                    { 831, "باشت", 23, "باشت", "Active" },
                    { 832, "پاتاوه", 23, "پاتاوه", "Active" },
                    { 833, "چرام", 23, "چرام", "Active" },
                    { 834, "چیتاب", 23, "چیتاب", "Active" },
                    { 835, "دهدشت", 23, "دهدشت", "Active" },
                    { 836, "دوگنبدان", 23, "دوگنبدان", "Active" },
                    { 837, "دیشموک", 23, "دیشموک", "Active" },
                    { 838, "سوق", 23, "سوق", "Active" },
                    { 839, "سی سخت", 23, "سی-سخت", "Active" },
                    { 840, "قلعه رئیسی", 23, "قلعه-رئیسی", "Active" },
                    { 841, "گراب سفلی", 23, "گراب-سفلی", "Active" },
                    { 842, "لنده", 23, "لنده", "Active" },
                    { 843, "لیکک", 23, "لیکک", "Active" },
                    { 844, "مادوان", 23, "مادوان", "Active" },
                    { 845, "مارگون", 23, "مارگون", "Active" },
                    { 846, "یاسوج", 23, "یاسوج", "Active" },
                    { 847, "انبارآلوم", 24, "انبارآلوم", "Active" },
                    { 848, "اینچه برون", 24, "اینچه-برون", "Active" },
                    { 849, "آزادشهر", 24, "آزادشهر", "Active" },
                    { 850, "آق قلا", 24, "آق-قلا", "Active" },
                    { 851, "بندرترکمن", 24, "بندرترکمن", "Active" },
                    { 852, "بندرگز", 24, "بندرگز", "Active" },
                    { 853, "جلین", 24, "جلین", "Active" },
                    { 854, "خان ببین", 24, "خان-ببین", "Active" },
                    { 855, "دلند", 24, "دلند", "Active" },
                    { 856, "رامیان", 24, "رامیان", "Active" },
                    { 857, "سرخنکلاته", 24, "سرخنکلاته", "Active" },
                    { 858, "سیمین شهر", 24, "سیمین-شهر", "Active" },
                    { 859, "علی آباد کتول", 24, "علی-آباد-کتول", "Active" },
                    { 860, "فاضل آباد", 24, "فاضل-آباد", "Active" },
                    { 861, "کردکوی", 24, "کردکوی", "Active" },
                    { 862, "کلاله", 24, "کلاله", "Active" },
                    { 863, "گالیکش", 24, "گالیکش", "Active" },
                    { 864, "گرگان", 24, "گرگان", "Active" },
                    { 865, "گمیش تپه", 24, "گمیش-تپه", "Active" },
                    { 866, "گنبدکاووس", 24, "گنبدکاووس", "Active" },
                    { 867, "مراوه", 24, "مراوه", "Active" },
                    { 868, "مینودشت", 24, "مینودشت", "Active" },
                    { 869, "نگین شهر", 24, "نگین-شهر", "Active" },
                    { 870, "نوده خاندوز", 24, "نوده-خاندوز", "Active" },
                    { 871, "نوکنده", 24, "نوکنده", "Active" },
                    { 872, "ازنا", 25, "ازنا", "Active" },
                    { 873, "اشترینان", 25, "اشترینان", "Active" },
                    { 874, "الشتر", 25, "الشتر", "Active" },
                    { 875, "الیگودرز", 25, "الیگودرز", "Active" },
                    { 876, "بروجرد", 25, "بروجرد", "Active" },
                    { 877, "پلدختر", 25, "پلدختر", "Active" },
                    { 878, "چالانچولان", 25, "چالانچولان", "Active" },
                    { 879, "چغلوندی", 25, "چغلوندی", "Active" },
                    { 880, "چقابل", 25, "چقابل", "Active" },
                    { 881, "خرم آباد", 25, "لرستان-خرم-آباد", "Active" },
                    { 882, "درب گنبد", 25, "درب-گنبد", "Active" },
                    { 883, "دورود", 25, "دورود", "Active" },
                    { 884, "زاغه", 25, "زاغه", "Active" },
                    { 885, "سپیددشت", 25, "سپیددشت", "Active" },
                    { 886, "سراب دوره", 25, "سراب-دوره", "Active" },
                    { 887, "فیروزآباد", 25, "لرستان-فیروزآباد", "Active" },
                    { 888, "کونانی", 25, "کونانی", "Active" },
                    { 889, "کوهدشت", 25, "کوهدشت", "Active" },
                    { 890, "گراب", 25, "گراب", "Active" },
                    { 891, "معمولان", 25, "معمولان", "Active" },
                    { 892, "مومن آباد", 25, "مومن-آباد", "Active" },
                    { 893, "نورآباد", 25, "لرستان-نورآباد", "Active" },
                    { 894, "ویسیان", 25, "ویسیان", "Active" },
                    { 895, "احمدسرگوراب", 26, "احمدسرگوراب", "Active" },
                    { 896, "اسالم", 26, "اسالم", "Active" },
                    { 897, "اطاقور", 26, "اطاقور", "Active" },
                    { 898, "املش", 26, "املش", "Active" },
                    { 899, "آستارا", 26, "آستارا", "Active" },
                    { 900, "آستانه اشرفیه", 26, "آستانه-اشرفیه", "Active" },
                    { 901, "بازار جمعه", 26, "بازار-جمعه", "Active" },
                    { 902, "بره سر", 26, "بره-سر", "Active" },
                    { 903, "بندرانزلی", 26, "بندرانزلی", "Active" },
                    { 906, "پره سر", 26, "پره-سر", "Active" },
                    { 907, "تالش", 26, "تالش", "Active" },
                    { 908, "توتکابن", 26, "توتکابن", "Active" },
                    { 909, "جیرنده", 26, "جیرنده", "Active" },
                    { 910, "چابکسر", 26, "چابکسر", "Active" },
                    { 911, "چاف و چمخاله", 26, "چاف-و-چمخاله", "Active" },
                    { 912, "چوبر", 26, "چوبر", "Active" },
                    { 913, "حویق", 26, "حویق", "Active" },
                    { 914, "خشکبیجار", 26, "خشکبیجار", "Active" },
                    { 915, "خمام", 26, "خمام", "Active" },
                    { 916, "دیلمان", 26, "دیلمان", "Active" },
                    { 917, "رانکوه", 26, "رانکوه", "Active" },
                    { 918, "رحیم آباد", 26, "رحیم-آباد", "Active" },
                    { 919, "رستم آباد", 26, "رستم-آباد", "Active" },
                    { 920, "رشت", 26, "رشت", "Active" },
                    { 921, "رضوانشهر", 26, "گیلان-رضوانشهر", "Active" },
                    { 922, "رودبار", 26, "گیلان-رودبار", "Active" },
                    { 923, "رودبنه", 26, "رودبنه", "Active" },
                    { 924, "رودسر", 26, "رودسر", "Active" },
                    { 925, "سنگر", 26, "سنگر", "Active" },
                    { 926, "سیاهکل", 26, "سیاهکل", "Active" },
                    { 927, "شفت", 26, "شفت", "Active" },
                    { 928, "شلمان", 26, "شلمان", "Active" },
                    { 929, "صومعه سرا", 26, "صومعه-سرا", "Active" },
                    { 930, "فومن", 26, "فومن", "Active" },
                    { 931, "کلاچای", 26, "کلاچای", "Active" },
                    { 932, "کوچصفهان", 26, "کوچصفهان", "Active" },
                    { 933, "کومله", 26, "کومله", "Active" },
                    { 934, "کیاشهر", 26, "کیاشهر", "Active" },
                    { 935, "گوراب زرمیخ", 26, "گوراب-زرمیخ", "Active" },
                    { 936, "لاهیجان", 26, "لاهیجان", "Active" },
                    { 937, "لشت نشا", 26, "لشت-نشا", "Active" },
                    { 938, "لنگرود", 26, "لنگرود", "Active" },
                    { 939, "لوشان", 26, "لوشان", "Active" },
                    { 940, "لولمان", 26, "لولمان", "Active" },
                    { 941, "لوندویل", 26, "لوندویل", "Active" },
                    { 942, "لیسار", 26, "لیسار", "Active" },
                    { 943, "ماسال", 26, "ماسال", "Active" },
                    { 944, "ماسوله", 26, "ماسوله", "Active" },
                    { 945, "مرجقل", 26, "مرجقل", "Active" },
                    { 946, "منجیل", 26, "منجیل", "Active" },
                    { 947, "واجارگاه", 26, "واجارگاه", "Active" },
                    { 948, "امیرکلا", 27, "امیرکلا", "Active" },
                    { 949, "ایزدشهر", 27, "ایزدشهر", "Active" },
                    { 950, "آلاشت", 27, "آلاشت", "Active" },
                    { 951, "آمل", 27, "آمل", "Active" },
                    { 952, "بابل", 27, "بابل", "Active" },
                    { 953, "بابلسر", 27, "بابلسر", "Active" },
                    { 954, "بلده", 27, "مازندران-بلده", "Active" },
                    { 955, "بهشهر", 27, "بهشهر", "Active" },
                    { 956, "بهنمیر", 27, "بهنمیر", "Active" },
                    { 957, "پل سفید", 27, "پل-سفید", "Active" },
                    { 958, "تنکابن", 27, "تنکابن", "Active" },
                    { 959, "جویبار", 27, "جویبار", "Active" },
                    { 960, "چالوس", 27, "چالوس", "Active" },
                    { 961, "چمستان", 27, "چمستان", "Active" },
                    { 962, "خرم آباد", 27, "مازندران-خرم-آباد", "Active" },
                    { 963, "خلیل شهر", 27, "خلیل-شهر", "Active" },
                    { 964, "خوش رودپی", 27, "خوش-رودپی", "Active" },
                    { 965, "دابودشت", 27, "دابودشت", "Active" },
                    { 966, "رامسر", 27, "رامسر", "Active" },
                    { 967, "رستمکلا", 27, "رستمکلا", "Active" },
                    { 968, "رویان", 27, "رویان", "Active" },
                    { 969, "رینه", 27, "رینه", "Active" },
                    { 970, "زرگرمحله", 27, "زرگرمحله", "Active" },
                    { 971, "زیرآب", 27, "زیرآب", "Active" },
                    { 972, "ساری", 27, "ساری", "Active" },
                    { 973, "سرخرود", 27, "سرخرود", "Active" },
                    { 974, "سلمان شهر", 27, "سلمان-شهر", "Active" },
                    { 975, "سورک", 27, "سورک", "Active" },
                    { 976, "شیرگاه", 27, "شیرگاه", "Active" },
                    { 977, "شیرود", 27, "شیرود", "Active" },
                    { 978, "عباس آباد", 27, "عباس-آباد", "Active" },
                    { 979, "فریدونکنار", 27, "فریدونکنار", "Active" },
                    { 980, "فریم", 27, "فریم", "Active" },
                    { 981, "قائم شهر", 27, "قائم-شهر", "Active" },
                    { 982, "کتالم", 27, "کتالم", "Active" },
                    { 983, "کلارآباد", 27, "کلارآباد", "Active" },
                    { 984, "کلاردشت", 27, "کلاردشت", "Active" },
                    { 985, "کله بست", 27, "کله-بست", "Active" },
                    { 986, "کوهی خیل", 27, "کوهی-خیل", "Active" },
                    { 987, "کیاسر", 27, "کیاسر", "Active" },
                    { 988, "کیاکلا", 27, "کیاکلا", "Active" },
                    { 989, "گتاب", 27, "گتاب", "Active" },
                    { 990, "گزنک", 27, "گزنک", "Active" },
                    { 991, "گلوگاه", 27, "گلوگاه", "Active" },
                    { 992, "محمودآباد", 27, "مازندران-محمودآباد", "Active" },
                    { 993, "مرزن آباد", 27, "مرزن-آباد", "Active" },
                    { 994, "مرزیکلا", 27, "مرزیکلا", "Active" },
                    { 995, "نشتارود", 27, "نشتارود", "Active" },
                    { 996, "نکا", 27, "نکا", "Active" },
                    { 997, "نور", 27, "نور", "Active" },
                    { 998, "نوشهر", 27, "نوشهر", "Active" },
                    { 999, "اراک", 28, "اراک", "Active" },
                    { 1000, "آستانه", 28, "آستانه", "Active" },
                    { 1001, "آشتیان", 28, "آشتیان", "Active" },
                    { 1002, "پرندک", 28, "پرندک", "Active" },
                    { 1003, "تفرش", 28, "تفرش", "Active" },
                    { 1004, "توره", 28, "توره", "Active" },
                    { 1005, "جاورسیان", 28, "جاورسیان", "Active" },
                    { 1006, "خشکرود", 28, "خشکرود", "Active" },
                    { 1007, "خمین", 28, "خمین", "Active" },
                    { 1008, "خنداب", 28, "خنداب", "Active" },
                    { 1009, "داودآباد", 28, "داودآباد", "Active" },
                    { 1010, "دلیجان", 28, "دلیجان", "Active" },
                    { 1011, "رازقان", 28, "رازقان", "Active" },
                    { 1012, "زاویه", 28, "زاویه", "Active" },
                    { 1013, "ساروق", 28, "ساروق", "Active" },
                    { 1014, "ساوه", 28, "ساوه", "Active" },
                    { 1015, "سنجان", 28, "سنجان", "Active" },
                    { 1016, "شازند", 28, "شازند", "Active" },
                    { 1017, "غرق آباد", 28, "غرق-آباد", "Active" },
                    { 1018, "فرمهین", 28, "فرمهین", "Active" },
                    { 1019, "قورچی باشی", 28, "قورچی-باشی", "Active" },
                    { 1020, "کرهرود", 28, "کرهرود", "Active" },
                    { 1021, "کمیجان", 28, "کمیجان", "Active" },
                    { 1022, "مامونیه", 28, "مامونیه", "Active" },
                    { 1023, "محلات", 28, "محلات", "Active" },
                    { 1024, "مهاجران", 28, "مهاجران", "Active" },
                    { 1025, "میلاجرد", 28, "میلاجرد", "Active" },
                    { 1026, "نراق", 28, "نراق", "Active" },
                    { 1027, "نوبران", 28, "نوبران", "Active" },
                    { 1028, "نیمور", 28, "نیمور", "Active" },
                    { 1029, "هندودر", 28, "هندودر", "Active" },
                    { 1030, "ابوموسی", 29, "ابوموسی", "Active" },
                    { 1031, "بستک", 29, "بستک", "Active" },
                    { 1032, "بندرجاسک", 29, "بندرجاسک", "Active" },
                    { 1033, "بندرچارک", 29, "بندرچارک", "Active" },
                    { 1034, "بندرخمیر", 29, "بندرخمیر", "Active" },
                    { 1035, "بندرعباس", 29, "بندرعباس", "Active" },
                    { 1036, "بندرلنگه", 29, "بندرلنگه", "Active" },
                    { 1037, "بیکا", 29, "بیکا", "Active" },
                    { 1038, "پارسیان", 29, "پارسیان", "Active" },
                    { 1039, "تخت", 29, "تخت", "Active" },
                    { 1040, "جناح", 29, "جناح", "Active" },
                    { 1041, "حاجی آباد", 29, "هرمزگان-حاجی-آباد", "Active" },
                    { 1042, "درگهان", 29, "درگهان", "Active" },
                    { 1043, "دهبارز", 29, "دهبارز", "Active" },
                    { 1044, "رویدر", 29, "رویدر", "Active" },
                    { 1045, "زیارتعلی", 29, "زیارتعلی", "Active" },
                    { 1046, "سردشت", 29, "هرمزگان-سردشت", "Active" },
                    { 1047, "سندرک", 29, "سندرک", "Active" },
                    { 1048, "سوزا", 29, "سوزا", "Active" },
                    { 1049, "سیریک", 29, "سیریک", "Active" },
                    { 1050, "فارغان", 29, "فارغان", "Active" },
                    { 1051, "فین", 29, "فین", "Active" },
                    { 1052, "قشم", 29, "قشم", "Active" },
                    { 1053, "قلعه قاضی", 29, "قلعه-قاضی", "Active" },
                    { 1054, "کنگ", 29, "کنگ", "Active" },
                    { 1055, "کوشکنار", 29, "کوشکنار", "Active" },
                    { 1056, "کیش", 29, "کیش", "Active" },
                    { 1057, "گوهران", 29, "گوهران", "Active" },
                    { 1058, "میناب", 29, "میناب", "Active" },
                    { 1059, "هرمز", 29, "هرمز", "Active" },
                    { 1060, "هشتبندی", 29, "هشتبندی", "Active" },
                    { 1061, "ازندریان", 30, "ازندریان", "Active" },
                    { 1062, "اسدآباد", 30, "اسدآباد", "Active" },
                    { 1063, "برزول", 30, "برزول", "Active" },
                    { 1064, "بهار", 30, "بهار", "Active" },
                    { 1065, "تویسرکان", 30, "تویسرکان", "Active" },
                    { 1066, "جورقان", 30, "جورقان", "Active" },
                    { 1067, "جوکار", 30, "جوکار", "Active" },
                    { 1068, "دمق", 30, "دمق", "Active" },
                    { 1069, "رزن", 30, "رزن", "Active" },
                    { 1070, "زنگنه", 30, "زنگنه", "Active" },
                    { 1071, "سامن", 30, "سامن", "Active" },
                    { 1072, "سرکان", 30, "سرکان", "Active" },
                    { 1073, "شیرین سو", 30, "شیرین-سو", "Active" },
                    { 1074, "صالح آباد", 30, "همدان-صالح-آباد", "Active" },
                    { 1075, "فامنین", 30, "فامنین", "Active" },
                    { 1076, "فرسفج", 30, "فرسفج", "Active" },
                    { 1077, "فیروزان", 30, "فیروزان", "Active" },
                    { 1078, "قروه درجزین", 30, "قروه-درجزین", "Active" },
                    { 1079, "قهاوند", 30, "قهاوند", "Active" },
                    { 1080, "کبودر آهنگ", 30, "کبودر-آهنگ", "Active" },
                    { 1081, "گل تپه", 30, "گل-تپه", "Active" },
                    { 1082, "گیان", 30, "گیان", "Active" },
                    { 1083, "لالجین", 30, "لالجین", "Active" },
                    { 1084, "مریانج", 30, "مریانج", "Active" },
                    { 1085, "ملایر", 30, "ملایر", "Active" },
                    { 1086, "نهاوند", 30, "نهاوند", "Active" },
                    { 1087, "همدان", 30, "همدان", "Active" },
                    { 1088, "ابرکوه", 31, "ابرکوه", "Active" },
                    { 1089, "احمدآباد", 31, "احمدآباد", "Active" },
                    { 1090, "اردکان", 31, "یزد-اردکان", "Active" },
                    { 1091, "اشکذر", 31, "اشکذر", "Active" },
                    { 1092, "بافق", 31, "بافق", "Active" },
                    { 1093, "بفروئیه", 31, "بفروئیه", "Active" },
                    { 1094, "بهاباد", 31, "بهاباد", "Active" },
                    { 1095, "تفت", 31, "تفت", "Active" },
                    { 1096, "حمیدیا", 31, "حمیدیا", "Active" },
                    { 1097, "خضرآباد", 31, "خضرآباد", "Active" },
                    { 1098, "دیهوک", 31, "دیهوک", "Active" },
                    { 1099, "زارچ", 31, "زارچ", "Active" },
                    { 1100, "شاهدیه", 31, "شاهدیه", "Active" },
                    { 1101, "طبس", 31, "یزد-طبس", "Active" },
                    { 1103, "عقدا", 31, "عقدا", "Active" },
                    { 1104, "مروست", 31, "مروست", "Active" },
                    { 1105, "مهردشت", 31, "مهردشت", "Active" },
                    { 1106, "مهریز", 31, "مهریز", "Active" },
                    { 1107, "میبد", 31, "میبد", "Active" },
                    { 1108, "ندوشن", 31, "ندوشن", "Active" },
                    { 1109, "نیر", 31, "یزد-نیر", "Active" },
                    { 1110, "هرات", 31, "هرات", "Active" },
                    { 1111, "یزد", 31, "یزد", "Active" },
                    { 1116, "پرند", 8, "پرند", "Active" },
                    { 1117, "فردیس", 5, "فردیس", "Active" },
                    { 1118, "مارلیک", 5, "مارلیک", "Active" },
                    { 1119, "سادات شهر", 27, "سادات-شهر", "Active" },
                    { 1121, "زیباکنار", 26, "زیباکنار", "Active" },
                    { 1135, "کردان", 5, "کردان", "Active" },
                    { 1137, "ساوجبلاغ", 5, "ساوجبلاغ", "Active" },
                    { 1138, "تهران دشت", 5, "تهران-دشت", "Active" },
                    { 1150, "گلبهار", 11, "گلبهار", "Active" },
                    { 1153, "قیامدشت", 8, "قیامدشت", "Active" },
                    { 1155, "بینالود", 11, "بینالود", "Active" },
                    { 1159, "پیربازار", 26, "پیربازار", "Active" },
                    { 1160, "رضوانشهر", 31, "رضوانشهر", "Active" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ProvinceId",
                table: "Addresses",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategory_CategoriesId",
                table: "ArticleCategory",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_MediaId",
                table: "Articles",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_BasketId",
                table: "BasketItems",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductId",
                table: "BasketItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ProductVariantId",
                table: "BasketItems",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_CouponId",
                table: "Baskets",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_UserId",
                table: "Baskets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_ProvinceId",
                table: "Cities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponProduct_ProductsId",
                table: "CouponProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaProduct_ProductId",
                table: "MediaProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_UserId",
                table: "Medias",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductVariantId",
                table: "OrderItems",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OTPs_UserId",
                table: "OTPs",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_ProductId",
                table: "ProductAttributes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_ProductId",
                table: "ProductReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductReviews_UserId",
                table: "ProductReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_OrderId",
                table: "Returns",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_OrderItemId",
                table: "Returns",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_ProductId",
                table: "Returns",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_UserId",
                table: "Returns",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_ListId",
                table: "TodoItems",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_ProductId",
                table: "Wishlists",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_UserId",
                table: "Wishlists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategory");

            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "CouponProduct");

            migrationBuilder.DropTable(
                name: "MediaProduct");

            migrationBuilder.DropTable(
                name: "OTPs");

            migrationBuilder.DropTable(
                name: "ProductAttributes");

            migrationBuilder.DropTable(
                name: "ProductReviews");

            migrationBuilder.DropTable(
                name: "Returns");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "TodoItems");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "TodoLists");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "Coupon");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}
