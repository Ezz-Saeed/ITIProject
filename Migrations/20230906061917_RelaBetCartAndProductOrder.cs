using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITIProject.Migrations
{
    /// <inheritdoc />
    public partial class RelaBetCartAndProductOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "ProductOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_CartId",
                table: "ProductOrders",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOrders_Carts_CartId",
                table: "ProductOrders",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOrders_Carts_CartId",
                table: "ProductOrders");

            migrationBuilder.DropIndex(
                name: "IX_ProductOrders_CartId",
                table: "ProductOrders");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "ProductOrders");
        }
    }
}
