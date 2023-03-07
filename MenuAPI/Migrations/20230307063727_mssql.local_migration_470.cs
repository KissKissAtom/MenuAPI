using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MenuAPI.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_470 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeMenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameMenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhraseMenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Intensite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEntree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NamePlat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameDessert = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEntree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionPLat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionDessert = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IngredientsMenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
