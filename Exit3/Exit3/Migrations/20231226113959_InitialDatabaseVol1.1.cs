using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exit3.Migrations
{
    public partial class InitialDatabaseVol11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paylasimlar_Begeniler_BegeniId",
                table: "Paylasimlar");

            migrationBuilder.DropIndex(
                name: "IX_Paylasimlar_BegeniId",
                table: "Paylasimlar");

            migrationBuilder.DropColumn(
                name: "BegeniId",
                table: "Paylasimlar");

            migrationBuilder.AddColumn<int>(
                name: "BegeniId",
                table: "Resimler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Resimler_BegeniId",
                table: "Resimler",
                column: "BegeniId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resimler_Begeniler_BegeniId",
                table: "Resimler",
                column: "BegeniId",
                principalTable: "Begeniler",
                principalColumn: "BegeniId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resimler_Begeniler_BegeniId",
                table: "Resimler");

            migrationBuilder.DropIndex(
                name: "IX_Resimler_BegeniId",
                table: "Resimler");

            migrationBuilder.DropColumn(
                name: "BegeniId",
                table: "Resimler");

            migrationBuilder.AddColumn<int>(
                name: "BegeniId",
                table: "Paylasimlar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Paylasimlar_BegeniId",
                table: "Paylasimlar",
                column: "BegeniId");

            migrationBuilder.AddForeignKey(
                name: "FK_Paylasimlar_Begeniler_BegeniId",
                table: "Paylasimlar",
                column: "BegeniId",
                principalTable: "Begeniler",
                principalColumn: "BegeniId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
