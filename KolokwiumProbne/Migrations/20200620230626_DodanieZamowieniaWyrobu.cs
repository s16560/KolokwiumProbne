using Microsoft.EntityFrameworkCore.Migrations;

namespace KolokwiumProbne.Migrations
{
    public partial class DodanieZamowieniaWyrobu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Zamowienie_WyrobyCukiernicze",
                columns: new[] { "IdWyrobuCukierniczego", "IdZamowienia", "Ilosc", "Uwagi" },
                values: new object[] { 1, 4, 3, "uwaga4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Zamowienie_WyrobyCukiernicze",
                keyColumns: new[] { "IdWyrobuCukierniczego", "IdZamowienia" },
                keyValues: new object[] { 1, 4 });
        }
    }
}
