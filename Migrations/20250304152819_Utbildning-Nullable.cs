using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestApi_Uppgift.Migrations
{
    /// <inheritdoc />
    public partial class UtbildningNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_erfarenheter_person_PersonID_FK",
                table: "erfarenheter");

            migrationBuilder.DropForeignKey(
                name: "FK_utbildnings_person_PersonID_FK",
                table: "utbildnings");

            migrationBuilder.DropIndex(
                name: "IX_utbildnings_PersonID_FK",
                table: "utbildnings");

            migrationBuilder.DropIndex(
                name: "IX_erfarenheter_PersonID_FK",
                table: "erfarenheter");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID_FK",
                table: "utbildnings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "utbildnings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonID",
                table: "erfarenheter",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_utbildnings_PersonID",
                table: "utbildnings",
                column: "PersonID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_utbildnings_person_PersonID",
                table: "utbildnings",
                column: "PersonID",
                principalTable: "person",
                principalColumn: "PersonID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_erfarenheter_person_PersonID",
                table: "erfarenheter");

            migrationBuilder.DropForeignKey(
                name: "FK_utbildnings_person_PersonID",
                table: "utbildnings");

            migrationBuilder.DropIndex(
                name: "IX_utbildnings_PersonID",
                table: "utbildnings");

            migrationBuilder.DropIndex(
                name: "IX_erfarenheter_PersonID",
                table: "erfarenheter");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "utbildnings");

            migrationBuilder.DropColumn(
                name: "PersonID",
                table: "erfarenheter");

            migrationBuilder.AlterColumn<int>(
                name: "PersonID_FK",
                table: "utbildnings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_utbildnings_PersonID_FK",
                table: "utbildnings",
                column: "PersonID_FK");

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

            migrationBuilder.AddForeignKey(
                name: "FK_utbildnings_person_PersonID_FK",
                table: "utbildnings",
                column: "PersonID_FK",
                principalTable: "person",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
