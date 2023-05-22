using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDProductApp_API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_category_id",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "category_id",
                table: "Products",
                newName: "Category_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_category_id",
                table: "Products",
                newName: "IX_Products_Category_Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                rowVersion: true,
                nullable: false,
                defaultValueSql: "getutcdate()");

            migrationBuilder.AddForeignKey(
                name: "Fk_Cate_Prod",
                table: "Products",
                column: "Category_Id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Fk_Cate_Prod",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Category_Id",
                table: "Products",
                newName: "category_id");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Category_Id",
                table: "Products",
                newName: "IX_Products_category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_category_id",
                table: "Products",
                column: "category_id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
