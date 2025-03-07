using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi_Uppgift.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    PersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TelefonNmr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Epost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "erfarenheter",
                columns: table => new
                {
                    ErfarenhetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<int>(type: "int", nullable: false),
                    Jobbtitel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivning = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonID_FK = table.Column<int>(type: "int", nullable: false),
                    PersonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_erfarenheter", x => x.ErfarenhetID);
                    table.ForeignKey(
                        name: "FK_erfarenheter_person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "person",
                        principalColumn: "PersonID");
                });

            migrationBuilder.CreateTable(
                name: "utbildnings",
                columns: table => new
                {
                    UtbildningsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDatum = table.Column<int>(type: "int", nullable: false),
                    SlutDatum = table.Column<int>(type: "int", nullable: false),
                    Examen = table.Column<int>(type: "int", nullable: false),
                    Skola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonID_FK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_utbildnings", x => x.UtbildningsID);
                    table.ForeignKey(
                        name: "FK_utbildnings_person_PersonID_FK",
                        column: x => x.PersonID_FK,
                        principalTable: "person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_erfarenheter_PersonID",
                table: "erfarenheter",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_utbildnings_PersonID_FK",
                table: "utbildnings",
                column: "PersonID_FK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "erfarenheter");

            migrationBuilder.DropTable(
                name: "utbildnings");

            migrationBuilder.DropTable(
                name: "person");
        }
    }
}
