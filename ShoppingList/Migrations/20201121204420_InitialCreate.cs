using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingList.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shelfs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelfs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListName = table.Column<string>(nullable: true),
                    CreatingDate = table.Column<DateTime>(nullable: true),
                    Price = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: true),
                    ShelfId = table.Column<int>(nullable: true),
                    Warranty = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Shelfs_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListedProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoppingListId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    IsBought = table.Column<bool>(nullable: true),
                    AvgBuyingQuantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListedProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListedProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListedProduct_ShopList_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShopList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListedProduct_ProductId",
                table: "ListedProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ListedProduct_ShoppingListId",
                table: "ListedProduct",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ShelfId",
                table: "Product",
                column: "ShelfId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListedProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ShopList");

            migrationBuilder.DropTable(
                name: "Shelfs");
        }
    }
}
