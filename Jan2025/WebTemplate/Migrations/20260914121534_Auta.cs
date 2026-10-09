using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class Auta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spoj",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrDana = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spoj", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Automobili",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PredjenaKilometraza = table.Column<int>(type: "int", nullable: false),
                    Godiste = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrSedista = table.Column<int>(type: "int", nullable: false),
                    CenaPoDanu = table.Column<int>(type: "int", nullable: false),
                    Iznajmljen = table.Column<bool>(type: "bit", nullable: false),
                    SpojeviID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobili", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Automobili_Spoj_SpojeviID",
                        column: x => x.SpojeviID,
                        principalTable: "Spoj",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImePrezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    BrVozake = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    SpojID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Korisnik_Spoj_SpojID",
                        column: x => x.SpojID,
                        principalTable: "Spoj",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automobili_SpojeviID",
                table: "Automobili",
                column: "SpojeviID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_SpojID",
                table: "Korisnik",
                column: "SpojID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automobili");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Spoj");
        }
    }
}
