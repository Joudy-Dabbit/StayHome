using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayHome.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryOrderCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_DeliveryOrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DeliveryOrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeliveryOrderId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "DeliveryOrderCart",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UtcDateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UtcDateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UtcDateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryOrderCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryOrderCart_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryOrderCart_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrderCart_OrderId",
                table: "DeliveryOrderCart",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryOrderCart_ProductId",
                table: "DeliveryOrderCart",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryOrderCart");

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryOrderId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeliveryOrderId",
                table: "Products",
                column: "DeliveryOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_DeliveryOrderId",
                table: "Products",
                column: "DeliveryOrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }
    }
}
