using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoOglasi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automobili",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marka = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Godiste = table.Column<int>(type: "INTEGER", nullable: false),
                    ZapreminaMotora = table.Column<int>(type: "INTEGER", nullable: true),
                    Snaga = table.Column<int>(type: "INTEGER", nullable: true),
                    Gorivo = table.Column<int>(type: "INTEGER", nullable: false),
                    Karoserija = table.Column<int>(type: "INTEGER", nullable: false),
                    Opis = table.Column<string>(type: "TEXT", maxLength: 2000, nullable: true),
                    Cena = table.Column<decimal>(type: "TEXT", nullable: false),
                    Kontakt = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobili", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automobili");
        }
    }
}
