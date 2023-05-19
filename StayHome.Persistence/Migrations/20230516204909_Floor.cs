using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayHome.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Floor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspNetUsers_CustomerId",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "Destination_Floor",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source_Floor",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Address",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Floor",
                table: "Address",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspNetUsers_CustomerId",
                table: "Address",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspNetUsers_CustomerId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Destination_Floor",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Source_Floor",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Address");

            migrationBuilder.AlterColumn<Guid>(
                name: "CustomerId",
                table: "Address",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspNetUsers_CustomerId",
                table: "Address",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
