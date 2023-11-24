using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KargoSirketleris",
                columns: table => new
                {
                    kargoSirketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KargoSirketleris", x => x.kargoSirketID);
                });

            migrationBuilder.CreateTable(
                name: "Kategoris",
                columns: table => new
                {
                    kategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoris", x => x.kategoriID);
                });

            migrationBuilder.CreateTable(
                name: "Musteris",
                columns: table => new
                {
                    musteriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ePosta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteris", x => x.musteriID);
                });

            migrationBuilder.CreateTable(
                name: "OdemeYontems",
                columns: table => new
                {
                    odemeYontemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdemeYontems", x => x.odemeYontemID);
                });

            migrationBuilder.CreateTable(
                name: "SiparisDurums",
                columns: table => new
                {
                    siparisDurumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiparisDurums", x => x.siparisDurumID);
                });

            migrationBuilder.CreateTable(
                name: "Uruns",
                columns: table => new
                {
                    urunID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kategoriID = table.Column<int>(type: "int", nullable: false),
                    ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fiyat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uruns", x => x.urunID);
                    table.ForeignKey(
                        name: "FK_Uruns_Kategoris_kategoriID",
                        column: x => x.kategoriID,
                        principalTable: "Kategoris",
                        principalColumn: "kategoriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adreslers",
                columns: table => new
                {
                    adresID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ulke = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sehir = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sokak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bina = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    musteriID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adreslers", x => x.adresID);
                    table.ForeignKey(
                        name: "FK_Adreslers_Musteris_musteriID",
                        column: x => x.musteriID,
                        principalTable: "Musteris",
                        principalColumn: "musteriID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Siparis",
                columns: table => new
                {
                    siparisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    musteriID = table.Column<int>(type: "int", nullable: false),
                    odemeYontemID = table.Column<int>(type: "int", nullable: false),
                    kargoSirketID = table.Column<int>(type: "int", nullable: false),
                    urunID = table.Column<int>(type: "int", nullable: false),
                    miktar = table.Column<int>(type: "int", nullable: false),
                    fiyat = table.Column<double>(type: "float", nullable: false),
                    siparisDurumID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparis", x => x.siparisID);
                    table.ForeignKey(
                        name: "FK_Siparis_KargoSirketleris_kargoSirketID",
                        column: x => x.kargoSirketID,
                        principalTable: "KargoSirketleris",
                        principalColumn: "kargoSirketID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Siparis_Musteris_musteriID",
                        column: x => x.musteriID,
                        principalTable: "Musteris",
                        principalColumn: "musteriID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Siparis_OdemeYontems_odemeYontemID",
                        column: x => x.odemeYontemID,
                        principalTable: "OdemeYontems",
                        principalColumn: "odemeYontemID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Siparis_SiparisDurums_siparisDurumID",
                        column: x => x.siparisDurumID,
                        principalTable: "SiparisDurums",
                        principalColumn: "siparisDurumID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Siparis_Uruns_urunID",
                        column: x => x.urunID,
                        principalTable: "Uruns",
                        principalColumn: "urunID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adreslers_musteriID",
                table: "Adreslers",
                column: "musteriID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_kargoSirketID",
                table: "Siparis",
                column: "kargoSirketID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_musteriID",
                table: "Siparis",
                column: "musteriID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_odemeYontemID",
                table: "Siparis",
                column: "odemeYontemID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_siparisDurumID",
                table: "Siparis",
                column: "siparisDurumID");

            migrationBuilder.CreateIndex(
                name: "IX_Siparis_urunID",
                table: "Siparis",
                column: "urunID");

            migrationBuilder.CreateIndex(
                name: "IX_Uruns_kategoriID",
                table: "Uruns",
                column: "kategoriID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adreslers");

            migrationBuilder.DropTable(
                name: "Siparis");

            migrationBuilder.DropTable(
                name: "KargoSirketleris");

            migrationBuilder.DropTable(
                name: "Musteris");

            migrationBuilder.DropTable(
                name: "OdemeYontems");

            migrationBuilder.DropTable(
                name: "SiparisDurums");

            migrationBuilder.DropTable(
                name: "Uruns");

            migrationBuilder.DropTable(
                name: "Kategoris");
        }
    }
}
