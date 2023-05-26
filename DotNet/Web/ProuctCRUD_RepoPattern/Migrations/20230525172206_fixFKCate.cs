using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductCRUD_RepoPattern.Migrations
{
    /// <inheritdoc />
    public partial class fixFKCate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category_Id",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                rowVersion: true,
                nullable: false,
                defaultValue: new DateTime(2023, 5, 26, 0, 22, 6, 162, DateTimeKind.Local).AddTicks(4066),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldRowVersion: true,
                oldDefaultValue: new DateTime(2023, 5, 25, 21, 9, 23, 163, DateTimeKind.Local).AddTicks(7978));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                rowVersion: true,
                nullable: false,
                defaultValue: new DateTime(2023, 5, 26, 0, 22, 6, 162, DateTimeKind.Local).AddTicks(9725),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldRowVersion: true,
                oldDefaultValue: new DateTime(2023, 5, 25, 21, 9, 23, 164, DateTimeKind.Local).AddTicks(2965));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Products",
                type: "datetime2",
                rowVersion: true,
                nullable: false,
                defaultValue: new DateTime(2023, 5, 25, 21, 9, 23, 163, DateTimeKind.Local).AddTicks(7978),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldRowVersion: true,
                oldDefaultValue: new DateTime(2023, 5, 26, 0, 22, 6, 162, DateTimeKind.Local).AddTicks(4066));

            migrationBuilder.AddColumn<Guid>(
                name: "Category_Id",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Categories",
                type: "datetime2",
                rowVersion: true,
                nullable: false,
                defaultValue: new DateTime(2023, 5, 25, 21, 9, 23, 164, DateTimeKind.Local).AddTicks(2965),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldRowVersion: true,
                oldDefaultValue: new DateTime(2023, 5, 26, 0, 22, 6, 162, DateTimeKind.Local).AddTicks(9725));
        }
    }
}
