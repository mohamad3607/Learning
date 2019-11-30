using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamedia.Infrastructure.Data.Migrations
{
    public partial class ENgTITLE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "Tracks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "SeriesEpisode",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "Series",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "PurchasableAlbums",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "DownloadableAlbums",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "SeriesEpisode");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "PurchasableAlbums");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "DownloadableAlbums");
        }
    }
}
