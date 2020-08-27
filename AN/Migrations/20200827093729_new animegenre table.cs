using Microsoft.EntityFrameworkCore.Migrations;

namespace AN.Migrations
{
    public partial class newanimegenretable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Animes_AnimeId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_AnimeId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "AnimeId",
                table: "Genres");

            migrationBuilder.CreateTable(
                name: "AnimeGenres",
                columns: table => new
                {
                    AnimeId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeGenres", x => new { x.GenreId, x.AnimeId });
                    table.ForeignKey(
                        name: "FK_AnimeGenres_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimeGenres_AnimeId",
                table: "AnimeGenres",
                column: "AnimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimeGenres");

            migrationBuilder.AddColumn<int>(
                name: "AnimeId",
                table: "Genres",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_AnimeId",
                table: "Genres",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Animes_AnimeId",
                table: "Genres",
                column: "AnimeId",
                principalTable: "Animes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
