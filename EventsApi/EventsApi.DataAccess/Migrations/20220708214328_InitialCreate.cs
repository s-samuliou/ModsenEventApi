using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventsApi.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Plan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Organizer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Speaker = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    EventTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventPlace = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EventPlace", "EventTime", "Name", "Organizer", "Plan", "Speaker" },
                values: new object[] { 1, "Talk about animals.", "Mogilev", new DateTime(2022, 7, 9, 0, 43, 27, 712, DateTimeKind.Local).AddTicks(4880), "Nature", "Samuliou Stsiapan", "1. Start; 2. Talk; 3. End;", "Byarozkin Hleb" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Description", "EventPlace", "EventTime", "Name", "Organizer", "Plan", "Speaker" },
                values: new object[] { 2, "Talk about sport.", "Minsk", new DateTime(2022, 7, 9, 0, 0, 0, 0, DateTimeKind.Local), "Sport", "Lionel Messi", "1. Start; 2. Talk; 3. End;", "Cristiano Ronaldo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
