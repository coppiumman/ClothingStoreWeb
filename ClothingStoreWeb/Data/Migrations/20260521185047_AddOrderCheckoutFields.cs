using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStoreWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderCheckoutFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Order_Comment",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Order_DeliveryAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Order_DeliveryAmount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Order_DeliveryMethod",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Order_PaymentMethod",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Order_RecipientEmail",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Order_RecipientName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Order_RecipientPhone",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order_Comment",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Order_DeliveryAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Order_DeliveryAmount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Order_DeliveryMethod",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Order_PaymentMethod",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Order_RecipientEmail",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Order_RecipientName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Order_RecipientPhone",
                table: "Orders");
        }
    }
}
