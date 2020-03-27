using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamedia.Src.Infrastructure.Data.Migrations
{
    public partial class ShowInPostField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsMain",
                table: "PostArtists",
                newName: "ShowInPost");

            migrationBuilder.AlterColumn<string>(
                name: "Lyric",
                table: "TrackInfos",
                maxLength: 3000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2500,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShowInPost",
                table: "PostArtists",
                newName: "IsMain");

            migrationBuilder.AlterColumn<string>(
                name: "Lyric",
                table: "TrackInfos",
                maxLength: 2500,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3000,
                oldNullable: true);
        }
    }
}
