using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exit3.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Begeniler",
                columns: table => new
                {
                    BegeniId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BegeniSayisi = table.Column<int>(type: "int", nullable: false),
                    BegenmemeSayisi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Begeniler", x => x.BegeniId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Etiketler",
                columns: table => new
                {
                    EtiketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EtiketName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etiketler", x => x.EtiketId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KullanciAdi = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adi = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Soyadi = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DogumTarih = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Sifre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cinsiyet = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ResimDetaylari",
                columns: table => new
                {
                    ResimDetaylariId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ResimAciklama = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResimDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EtiketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResimDetaylari", x => x.ResimDetaylariId);
                    table.ForeignKey(
                        name: "FK_ResimDetaylari_Etiketler_EtiketId",
                        column: x => x.EtiketId,
                        principalTable: "Etiketler",
                        principalColumn: "EtiketId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Resimler",
                columns: table => new
                {
                    ResimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ResimUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResimDetaylariId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resimler", x => x.ResimId);
                    table.ForeignKey(
                        name: "FK_Resimler_ResimDetaylari_ResimDetaylariId",
                        column: x => x.ResimDetaylariId,
                        principalTable: "ResimDetaylari",
                        principalColumn: "ResimDetaylariId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Paylasimlar",
                columns: table => new
                {
                    PaylasimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BegeniId = table.Column<int>(type: "int", nullable: false),
                    ResimId = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paylasimlar", x => x.PaylasimId);
                    table.ForeignKey(
                        name: "FK_Paylasimlar_Begeniler_BegeniId",
                        column: x => x.BegeniId,
                        principalTable: "Begeniler",
                        principalColumn: "BegeniId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paylasimlar_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Paylasimlar_Resimler_ResimId",
                        column: x => x.ResimId,
                        principalTable: "Resimler",
                        principalColumn: "ResimId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    YorumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Yorum = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResimId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.YorumId);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Resimler_ResimId",
                        column: x => x.ResimId,
                        principalTable: "Resimler",
                        principalColumn: "ResimId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Paylasimlar_BegeniId",
                table: "Paylasimlar",
                column: "BegeniId");

            migrationBuilder.CreateIndex(
                name: "IX_Paylasimlar_KullaniciId",
                table: "Paylasimlar",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Paylasimlar_ResimId",
                table: "Paylasimlar",
                column: "ResimId");

            migrationBuilder.CreateIndex(
                name: "IX_ResimDetaylari_EtiketId",
                table: "ResimDetaylari",
                column: "EtiketId");

            migrationBuilder.CreateIndex(
                name: "IX_Resimler_ResimDetaylariId",
                table: "Resimler",
                column: "ResimDetaylariId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_ResimId",
                table: "Yorumlar",
                column: "ResimId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paylasimlar");

            migrationBuilder.DropTable(
                name: "Yorumlar");

            migrationBuilder.DropTable(
                name: "Begeniler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Resimler");

            migrationBuilder.DropTable(
                name: "ResimDetaylari");

            migrationBuilder.DropTable(
                name: "Etiketler");
        }
    }
}
