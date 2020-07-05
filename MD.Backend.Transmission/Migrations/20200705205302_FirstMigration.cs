using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MD.Backend.Transmission.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Torrents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MovieName = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Torrents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Torrents_MovieName",
                table: "Torrents",
                column: "MovieName",
                unique: true,
                filter: "[MovieName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Torrents");
        }
    }
}
