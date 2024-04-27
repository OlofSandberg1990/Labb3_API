using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Labb3_API.Migrations
{
    /// <inheritdoc />
    public partial class InitalizeDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    InterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonInterests_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonInterestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_PersonInterests_PersonInterestId",
                        column: x => x.PersonInterestId,
                        principalTable: "PersonInterests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Growing plants and vegetables", "Gardening" },
                    { 2, "Developing software and applications", "Programming" },
                    { 3, "Playing Discgolf", "Discgolf" },
                    { 4, "Playing Soccer", "Soccer" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Erik Andersson", "0701234567" },
                    { 2, "Jonatan Nordin", "072344412412" },
                    { 3, "Olof Sandberg", "07234124124" },
                    { 4, "Nina Lindberg Nilsson", "0723412123123" },
                    { 5, "Pär Sandberg", "072341233334" },
                    { 6, "Sara Johansson", "0762055271" }
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 2, 2 },
                    { 4, 3, 1 },
                    { 5, 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "PersonInterestId", "URL" },
                values: new object[,]
                {
                    { 1, 1, "http://www.gardeningexample.com" },
                    { 2, 1, "http://www.programmingexample.com" },
                    { 3, 3, "http://www.discGolfWithOlof.com" },
                    { 4, 4, "http://www.discGolfWithOlofPROEDITION.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_PersonInterestId",
                table: "Links",
                column: "PersonInterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_InterestId",
                table: "PersonInterests",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterests_PersonId",
                table: "PersonInterests",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "PersonInterests");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
