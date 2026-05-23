using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStoreWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryIsHidden : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Category_IsHidden",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category_IsHidden",
                table: "Categories");
        }
    }
}
