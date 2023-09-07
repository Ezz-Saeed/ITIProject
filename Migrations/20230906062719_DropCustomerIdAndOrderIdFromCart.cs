using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIProject.Migrations
{
    /// <inheritdoc />
    public partial class DropCustomerIdAndOrderIdFromCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Carts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Carts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Carts",
                type: "int",
                nullable: true);
        }
    }
}
