using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class EPAPIv5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategory_Category_CategoryId",
                table: "Subcategory");

            migrationBuilder.AddColumn<int>(
                name: "SubcategoryId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Product_SubcategoryId",
                table: "Product",
                column: "SubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Subcategory_SubcategoryId",
                table: "Product",
                column: "SubcategoryId",
                principalTable: "Subcategory",
                principalColumn: "SubcategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategory_Category_CategoryId",
                table: "Subcategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Subcategory_SubcategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Subcategory_Category_CategoryId",
                table: "Subcategory");

            migrationBuilder.DropIndex(
                name: "IX_Product_SubcategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SubcategoryId",
                table: "Product");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subcategory_Category_CategoryId",
                table: "Subcategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
