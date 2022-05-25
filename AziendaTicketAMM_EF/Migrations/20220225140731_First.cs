using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AziendaTicketAMM_EF.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCategoria = table.Column<string>(nullable: false),
                    Descrizione = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stati",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeStato = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCreazione = table.Column<DateTime>(nullable: false),
                    Richiedente = table.Column<string>(nullable: false),
                    DescrizioneBreve = table.Column<string>(nullable: false),
                    DescrizioneLunga = table.Column<string>(nullable: false),
                    Assegnatario = table.Column<string>(nullable: true),
                    DataChiusura = table.Column<DateTime>(nullable: true),
                    IDCategoria = table.Column<int>(nullable: false),
                    IDStato = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Categorie_IDCategoria",
                        column: x => x.IDCategoria,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Stati_IDStato",
                        column: x => x.IDStato,
                        principalTable: "Stati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorie",
                columns: new[] { "Id", "Descrizione", "NomeCategoria" },
                values: new object[,]
                {
                    { 1, "Descrizione System", "System" },
                    { 2, "descrizione Development", "Development" },
                    { 3, "descrizione Office App", "Office Application" },
                    { 4, "descrizione SAP", "SAP" },
                    { 5, "descrizione other", "Other" }
                });

            migrationBuilder.InsertData(
                table: "Stati",
                columns: new[] { "Id", "NomeStato" },
                values: new object[,]
                {
                    { 1, "Nuovo" },
                    { 2, "Assegnato" },
                    { 3, "In Risoluzione" },
                    { 4, "Chiuso" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Assegnatario", "DataChiusura", "DataCreazione", "DescrizioneBreve", "DescrizioneLunga", "IDCategoria", "IDStato", "Richiedente" },
                values: new object[] { 1, null, null, new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "descrizione breve 1", "descrizione lunga 1", 1, 1, "Alessia" });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IDCategoria",
                table: "Tickets",
                column: "IDCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IDStato",
                table: "Tickets",
                column: "IDStato");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Stati");
        }
    }
}
