using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StayHome.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CustomerGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");
        }
    }
}
