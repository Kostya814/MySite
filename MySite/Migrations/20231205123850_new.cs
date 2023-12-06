using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySite.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LeterName1",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "LeterName2",
                table: "Addresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LeterName1",
                table: "Addresses",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeterName2",
                table: "Addresses",
                type: "text",
                nullable: true);
        }
    }
}
