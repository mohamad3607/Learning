using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamedia.Src.Infrastructure.Data.Migrations
{
    public partial class TrackInfos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackInfo_Posts_PostId",
                table: "TrackInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackInfo",
                table: "TrackInfo");

            migrationBuilder.RenameTable(
                name: "TrackInfo",
                newName: "TrackInfos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackInfos",
                table: "TrackInfos",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackInfos_Posts_PostId",
                table: "TrackInfos",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackInfos_Posts_PostId",
                table: "TrackInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrackInfos",
                table: "TrackInfos");

            migrationBuilder.RenameTable(
                name: "TrackInfos",
                newName: "TrackInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrackInfo",
                table: "TrackInfo",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackInfo_Posts_PostId",
                table: "TrackInfo",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
