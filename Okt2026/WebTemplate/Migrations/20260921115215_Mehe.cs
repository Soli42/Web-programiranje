using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class Mehe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ansambl",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ansambl", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Clanovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visina = table.Column<int>(type: "int", nullable: false),
                    BrGodineIskustva = table.Column<int>(type: "int", nullable: false),
                    AnsamblID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clanovi_Ansambl_AnsamblID",
                        column: x => x.AnsamblID,
                        principalTable: "Ansambl",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clanovi_AnsamblID",
                table: "Clanovi",
                column: "AnsamblID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clanovi");

            migrationBuilder.DropTable(
                name: "Ansambl");
        }
    }
}
