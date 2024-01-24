using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exit3.Migrations
{
    public partial class InitialDatabaseVol12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "ResimId",
                table: "Begeniler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Begeniler_ResimId",
                table: "Begeniler",
                column: "ResimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Begeniler_Resimler_ResimId",
                table: "Begeniler",
                column: "ResimId",
                principalTable: "Resimler",
                principalColumn: "ResimId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Begeniler_Resimler_ResimId",
                table: "Begeniler");

            migrationBuilder.DropIndex(
                name: "IX_Begeniler_ResimId",
                table: "Begeniler");

            migrationBuilder.DropColumn(
                name: "ResimId",
                table: "Begeniler");

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
    }
}
