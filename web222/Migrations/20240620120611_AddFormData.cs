using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web222.Migrations
{
    /// <inheritdoc />
    public partial class AddFormData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwisko = table.Column<string>(type: "TEXT", nullable: false),
                    Imie = table.Column<string>(type: "TEXT", nullable: false),
                    Pracodawca = table.Column<string>(type: "TEXT", nullable: false),
                    DataWeryfikacji = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataWyslaniaDoSG = table.Column<DateTime>(type: "TEXT", nullable: true),
                    NumerWNP = table.Column<string>(type: "TEXT", nullable: false),
                    WNP = table.Column<string>(type: "TEXT", nullable: false),
                    KierownikPrzemek = table.Column<string>(type: "TEXT", nullable: false),
                    DataOdbioruID = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Uwagi = table.Column<string>(type: "TEXT", nullable: false),
                    DzialBB = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormData");
        }
    }
}
