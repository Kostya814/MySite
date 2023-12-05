using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MySite.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrefixLocality = table.Column<string>(type: "text", nullable: false),
                    NameLocality = table.Column<string>(type: "text", nullable: false),
                    PrefixStreet = table.Column<string>(type: "text", nullable: false),
                    NameStreet = table.Column<string>(type: "text", nullable: false),
                    NumberHouse = table.Column<int>(type: "integer", nullable: false),
                    NumberCase = table.Column<int>(type: "integer", nullable: false),
                    NumberApartments = table.Column<int>(type: "integer", nullable: false),
                    NumberRoom = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    LeterHome = table.Column<string>(type: "text", nullable: false),
                    LeterName1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
