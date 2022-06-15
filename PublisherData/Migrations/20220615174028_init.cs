using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PublisherData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Humans",
                columns: table => new
                {
                    HumanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humans", x => x.HumanId);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    PetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HumanId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.PetId);
                    table.ForeignKey(
                        name: "FK_Pets_Humans_HumanId",
                        column: x => x.HumanId,
                        principalTable: "Humans",
                        principalColumn: "HumanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    PetId = table.Column<int>(type: "int", nullable: false),
                    Meows = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.PetId);
                    table.ForeignKey(
                        name: "FK_Cats_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "PetId");
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    PetId = table.Column<int>(type: "int", nullable: false),
                    BarkDecibels = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.PetId);
                    table.ForeignKey(
                        name: "FK_Dogs_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "PetId");
                });

            migrationBuilder.InsertData(
                table: "Humans",
                columns: new[] { "HumanId", "Name" },
                values: new object[] { 1, "Rafał" });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "PetId", "DateOfBirth", "HumanId", "Name" },
                values: new object[] { 2, new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Lily" });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "PetId", "DateOfBirth", "HumanId", "Name" },
                values: new object[] { 3, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Beza" });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "PetId", "DateOfBirth", "HumanId", "Name" },
                values: new object[] { 1, new DateTime(2010, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Bessi" });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "PetId", "Meows" },
                values: new object[] { 2, 3 });

            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "PetId", "Meows" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "PetId", "BarkDecibels" },
                values: new object[] { 1, 70.3m });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_HumanId",
                table: "Pets",
                column: "HumanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cats");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Humans");
        }
    }
}
