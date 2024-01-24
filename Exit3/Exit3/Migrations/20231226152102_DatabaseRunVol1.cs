using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exit3.Migrations
{
    public partial class DatabaseRunVol1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KullanciAdi",
                table: "Kullanicilar",
                newName: "KullaniciAdi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KullaniciAdi",
                table: "Kullanicilar",
                newName: "KullanciAdi");
        }
    }
}
