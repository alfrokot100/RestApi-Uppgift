using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi_Uppgift.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_erfarenheter_person_PersonID",
                table: "erfarenheter");

            migrationBuilder.DropIndex(
                name: "IX_erfarenheter_PersonID",
                table: "erfarenheter");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "erfarenheter");

            migrationBuilder.CreateIndex(
                name: "IX_erfarenheter_PersonID_FK",
                table: "erfarenheter",
                column: "PersonID_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_erfarenheter_person_PersonID_FK",
                table: "erfarenheter",
                column: "PersonID_FK",
                principalTable: "person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_erfarenheter_person_PersonID_FK",
                table: "erfarenheter");

            migrationBuilder.DropIndex(
                name: "IX_erfarenheter_PersonID_FK",
                table: "erfarenheter");

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "erfarenheter",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_erfarenheter_PersonID",
                table: "erfarenheter",
                column: "PersonID");

            migrationBuilder.AddForeignKey(
                name: "FK_erfarenheter_person_PersonID",
                table: "erfarenheter",
                column: "PersonID",
                principalTable: "person",
                principalColumn: "PersonID");
        }
    }
}
