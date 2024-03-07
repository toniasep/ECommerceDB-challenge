using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceDB.Migrations
{
    public partial class AddRelationProductCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_products_categories_category_id",
                table: "products_categories",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_categories_category_id",
                table: "products_categories",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_categories_products_product_id",
                table: "products_categories",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_categories_category_id",
                table: "products_categories");

            migrationBuilder.DropForeignKey(
                name: "FK_products_categories_products_product_id",
                table: "products_categories");

            migrationBuilder.DropIndex(
                name: "IX_products_categories_category_id",
                table: "products_categories");
        }
    }
}
