using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SongsLibrary.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusicVideoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusicVideoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MusicVideo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicVideo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicVideo_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicVideo_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artist_MusicVideoId",
                table: "Artist",
                column: "MusicVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_MusicVideoId",
                table: "Genre",
                column: "MusicVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicVideo_ArtistId",
                table: "MusicVideo",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicVideo_GenreId",
                table: "MusicVideo",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artist_MusicVideo_MusicVideoId",
                table: "Artist",
                column: "MusicVideoId",
                principalTable: "MusicVideo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_MusicVideo_MusicVideoId",
                table: "Genre",
                column: "MusicVideoId",
                principalTable: "MusicVideo",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artist_MusicVideo_MusicVideoId",
                table: "Artist");

            migrationBuilder.DropForeignKey(
                name: "FK_Genre_MusicVideo_MusicVideoId",
                table: "Genre");

            migrationBuilder.DropTable(
                name: "MusicVideo");

            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
