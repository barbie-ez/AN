using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace AN.Migrations
{
    public partial class addednewpropertiesandmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Messages_AspNetUsers_AddedbyId1",
            //    table: "Messages");

            //migrationBuilder.DropIndex(
            //    name: "IX_Messages_AddedbyId1",
            //    table: "Messages");

            //migrationBuilder.DropColumn(
            //    name: "AddedbyId1",
            //    table: "Messages");

            //migrationBuilder.DropColumn(
            //    name: "Token",
            //    table: "AspNetUsers");

            //migrationBuilder.AlterColumn<string>(
            //    name: "AddedbyId",
            //    table: "Messages",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "RoleId",
            //    table: "AspNetUserRoles",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(128)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "AspNetUserRoles",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(128)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<DateTime>(
                name: "BraodcastTime",
                table: "Animes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Animes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Animes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "HasManga",
                table: "Animes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NoOfEps",
                table: "Animes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Rated",
                table: "Animes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Animes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudioId",
                table: "Animes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Animes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    AnimeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeGenre",
                columns: table => new
                {
                    AnimeId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeGenre", x => new { x.GenreId, x.AnimeId });
                    table.ForeignKey(
                        name: "FK_AnimeGenre_Animes_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeGenre_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Messages_AddedbyId",
            //    table: "Messages",
            //    column: "AddedbyId");

            migrationBuilder.CreateIndex(
                name: "IX_Animes_StudioId",
                table: "Animes",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeGenre_AnimeId",
                table: "AnimeGenre",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AnimeId",
                table: "Ratings",
                column: "AnimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animes_Studios_StudioId",
                table: "Animes",
                column: "StudioId",
                principalTable: "Studios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Messages_AspNetUsers_AddedbyId",
            //    table: "Messages",
            //    column: "AddedbyId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animes_Studios_StudioId",
                table: "Animes");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Messages_AspNetUsers_AddedbyId",
            //    table: "Messages");

            migrationBuilder.DropTable(
                name: "AnimeGenre");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Messages_AddedbyId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Animes_StudioId",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "BraodcastTime",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "HasManga",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "NoOfEps",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "Rated",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "StudioId",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Animes");

            //migrationBuilder.AlterColumn<int>(
            //    name: "AddedbyId",
            //    table: "Messages",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "AddedbyId1",
            //    table: "Messages",
            //    type: "varchar(767)",
            //    nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "text",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "RoleId",
            //    table: "AspNetUserRoles",
            //    type: "varchar(128)",
            //    nullable: false,
            //    oldClrType: typeof(string));

            //migrationBuilder.AlterColumn<string>(
            //    name: "UserId",
            //    table: "AspNetUserRoles",
            //    type: "varchar(128)",
            //    nullable: false,
            //    oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "varchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            //migrationBuilder.CreateIndex(
            //    name: "IX_Messages_AddedbyId1",
            //    table: "Messages",
            //    column: "AddedbyId1");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Messages_AspNetUsers_AddedbyId1",
            //    table: "Messages",
            //    column: "AddedbyId1",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
