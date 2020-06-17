using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VIP_Services_Rudy_2020.Migrations
{
    public partial class gerry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    Categorie = table.Column<int>(nullable: false),
                    BTWnummer = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Limousines",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    EersteUur = table.Column<double>(nullable: false),
                    Nightlife = table.Column<double>(nullable: false),
                    Wedding = table.Column<double>(nullable: false),
                    Wellness = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Limousines", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Locaties",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    StraatNaam = table.Column<string>(nullable: true),
                    straatNummer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locaties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Staffelkortingen",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aantal = table.Column<int>(nullable: false),
                    Korting = table.Column<double>(nullable: false),
                    KlantType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffelkortingen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reserveringen",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GereserveerdeTijd = table.Column<int>(nullable: false),
                    StartDatum = table.Column<DateTime>(nullable: false),
                    StratPlaatsID = table.Column<int>(nullable: true),
                    EindPlaatsID = table.Column<int>(nullable: true),
                    LimousineID = table.Column<int>(nullable: true),
                    KlantID = table.Column<int>(nullable: true),
                    ReservatieType = table.Column<int>(nullable: false),
                    Cost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserveringen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Locaties_EindPlaatsID",
                        column: x => x.EindPlaatsID,
                        principalTable: "Locaties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Klanten_KlantID",
                        column: x => x.KlantID,
                        principalTable: "Klanten",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Limousines_LimousineID",
                        column: x => x.LimousineID,
                        principalTable: "Limousines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserveringen_Locaties_StratPlaatsID",
                        column: x => x.StratPlaatsID,
                        principalTable: "Locaties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_EindPlaatsID",
                table: "Reserveringen",
                column: "EindPlaatsID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_KlantID",
                table: "Reserveringen",
                column: "KlantID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_LimousineID",
                table: "Reserveringen",
                column: "LimousineID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserveringen_StratPlaatsID",
                table: "Reserveringen",
                column: "StratPlaatsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserveringen");

            migrationBuilder.DropTable(
                name: "Staffelkortingen");

            migrationBuilder.DropTable(
                name: "Locaties");

            migrationBuilder.DropTable(
                name: "Klanten");

            migrationBuilder.DropTable(
                name: "Limousines");
        }
    }
}
