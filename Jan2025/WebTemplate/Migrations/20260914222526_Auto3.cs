using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTemplate.Migrations
{
    /// <inheritdoc />
    public partial class Auto3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automobili_Spoj_SpojeviID",
                table: "Automobili");

            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_Spoj_SpojID",
                table: "Korisnik");

            migrationBuilder.DropIndex(
                name: "IX_Korisnik_SpojID",
                table: "Korisnik");

            migrationBuilder.DropIndex(
                name: "IX_Automobili_SpojeviID",
                table: "Automobili");

            migrationBuilder.DropColumn(
                name: "SpojID",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "SpojeviID",
                table: "Automobili");

            migrationBuilder.AddColumn<int>(
                name: "AutomobiliID",
                table: "Spoj",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KorisnikID",
                table: "Spoj",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spoj_AutomobiliID",
                table: "Spoj",
                column: "AutomobiliID");

            migrationBuilder.CreateIndex(
                name: "IX_Spoj_KorisnikID",
                table: "Spoj",
                column: "KorisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Spoj_Automobili_AutomobiliID",
                table: "Spoj",
                column: "AutomobiliID",
                principalTable: "Automobili",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Spoj_Korisnik_KorisnikID",
                table: "Spoj",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Spoj_Automobili_AutomobiliID",
                table: "Spoj");

            migrationBuilder.DropForeignKey(
                name: "FK_Spoj_Korisnik_KorisnikID",
                table: "Spoj");

            migrationBuilder.DropIndex(
                name: "IX_Spoj_AutomobiliID",
                table: "Spoj");

            migrationBuilder.DropIndex(
                name: "IX_Spoj_KorisnikID",
                table: "Spoj");

            migrationBuilder.DropColumn(
                name: "AutomobiliID",
                table: "Spoj");

            migrationBuilder.DropColumn(
                name: "KorisnikID",
                table: "Spoj");

            migrationBuilder.AddColumn<int>(
                name: "SpojID",
                table: "Korisnik",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpojeviID",
                table: "Automobili",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_SpojID",
                table: "Korisnik",
                column: "SpojID");

            migrationBuilder.CreateIndex(
                name: "IX_Automobili_SpojeviID",
                table: "Automobili",
                column: "SpojeviID");

            migrationBuilder.AddForeignKey(
                name: "FK_Automobili_Spoj_SpojeviID",
                table: "Automobili",
                column: "SpojeviID",
                principalTable: "Spoj",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_Spoj_SpojID",
                table: "Korisnik",
                column: "SpojID",
                principalTable: "Spoj",
                principalColumn: "ID");
        }
    }
}
