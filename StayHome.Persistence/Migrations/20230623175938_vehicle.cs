using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayHome.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class vehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "OrderStage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentStage = table.Column<int>(type: "int", nullable: false),
                    UtcDateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UtcDateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UtcDateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderStage_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderStage_OrderId",
                table: "OrderStage",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderStage");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Vehicles");
        }
    }
}
