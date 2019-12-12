using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamedia.Src.Infrastructure.Data.Migrations
{
    public partial class ArtistTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostArtists_ArtistTypes_ArtistId_TypeId",
                table: "PostArtists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostArtists",
                table: "PostArtists");

            migrationBuilder.DropIndex(
                name: "IX_PostArtists_ArtistId_TypeId",
                table: "PostArtists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistTypes",
                table: "ArtistTypes");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "PostArtists");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "PostArtists",
                newName: "ArtistTypeId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ArtistTypes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostArtists",
                table: "PostArtists",
                columns: new[] { "PostId", "ArtistTypeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistTypes",
                table: "ArtistTypes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PostArtists_ArtistTypeId",
                table: "PostArtists",
                column: "ArtistTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistTypes_ArtistId",
                table: "ArtistTypes",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostArtists_ArtistTypes_ArtistTypeId",
                table: "PostArtists",
                column: "ArtistTypeId",
                principalTable: "ArtistTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostArtists_ArtistTypes_ArtistTypeId",
                table: "PostArtists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostArtists",
                table: "PostArtists");

            migrationBuilder.DropIndex(
                name: "IX_PostArtists_ArtistTypeId",
                table: "PostArtists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtistTypes",
                table: "ArtistTypes");

            migrationBuilder.DropIndex(
                name: "IX_ArtistTypes_ArtistId",
                table: "ArtistTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ArtistTypes");

            migrationBuilder.RenameColumn(
                name: "ArtistTypeId",
                table: "PostArtists",
                newName: "TypeId");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "PostArtists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostArtists",
                table: "PostArtists",
                columns: new[] { "PostId", "ArtistId", "TypeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtistTypes",
                table: "ArtistTypes",
                columns: new[] { "ArtistId", "TypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_PostArtists_ArtistId_TypeId",
                table: "PostArtists",
                columns: new[] { "ArtistId", "TypeId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostArtists_ArtistTypes_ArtistId_TypeId",
                table: "PostArtists",
                columns: new[] { "ArtistId", "TypeId" },
                principalTable: "ArtistTypes",
                principalColumns: new[] { "ArtistId", "TypeId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
