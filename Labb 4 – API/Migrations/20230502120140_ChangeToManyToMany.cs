using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labb_4___API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hobbys_Persons_PersonId",
                table: "Hobbys");

            migrationBuilder.DropIndex(
                name: "IX_Hobbys_PersonId",
                table: "Hobbys");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Hobbys");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Hobbys",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HobbyPerson",
                columns: table => new
                {
                    HobbysId = table.Column<int>(type: "int", nullable: false),
                    PersonsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbyPerson", x => new { x.HobbysId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_HobbyPerson_Hobbys_HobbysId",
                        column: x => x.HobbysId,
                        principalTable: "Hobbys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HobbyPerson_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonId",
                table: "Links",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_HobbyPerson_PersonsId",
                table: "HobbyPerson",
                column: "PersonsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Persons_PersonId",
                table: "Links",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Persons_PersonId",
                table: "Links");

            migrationBuilder.DropTable(
                name: "HobbyPerson");

            migrationBuilder.DropIndex(
                name: "IX_Links_PersonId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Links");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Hobbys",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Links",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Hobbys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Hobbys_PersonId",
                table: "Hobbys",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hobbys_Persons_PersonId",
                table: "Hobbys",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
