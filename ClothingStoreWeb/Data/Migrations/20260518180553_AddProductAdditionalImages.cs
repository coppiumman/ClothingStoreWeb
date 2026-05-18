using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStoreWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddProductAdditionalImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Product_ImagePath2",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Product_ImagePath3",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Product_ImagePath4",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Product_ImagePath2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Product_ImagePath3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Product_ImagePath4",
                table: "Products");
        }
    }
}