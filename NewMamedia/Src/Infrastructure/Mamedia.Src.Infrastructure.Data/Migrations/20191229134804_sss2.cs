using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamedia.Src.Infrastructure.Data.Migrations
{
    public partial class sss2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mamedia.Src.Domain.Core.Entities.PurchasableAlbumInfo_Posts_PostId",
                table: "Mamedia.Src.Domain.Core.Entities.PurchasableAlbumInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mamedia.Src.Domain.Core.Entities.PurchasableAlbumInfo",
                table: "Mamedia.Src.Domain.Core.Entities.PurchasableAlbumInfo");

            migrationBuilder.RenameTable(
                name: "Mamedia.Src.Domain.Core.Entities.PurchasableAlbumInfo",
                newName: "PurchasableAlbumInfos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasableAlbumInfos",
                table: "PurchasableAlbumInfos",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchasableAlbumInfos_Posts_PostId",
                table: "PurchasableAlbumInfos",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchasableAlbumInfos_Posts_PostId",
                table: "PurchasableAlbumInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasableAlbumInfos",
                table: "PurchasableAlbumInfos");

            migrationBuilder.RenameTable(
                name: "PurchasableAlbumInfos",
                newName: "Mamedia.Src.Domain.Core.Entities.PurchasableAlbumInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mamedia.Src.Domain.Core.Entities.PurchasableAlbumInfo",
                table: "Mamedia.Src.Domain.Core.Entities.PurchasableAlbumInfo",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mamedia.Src.Domain.Core.Entities.PurchasableAlbumInfo_Posts_PostId",
                table: "Mamedia.Src.Domain.Core.Entities.PurchasableAlbumInfo",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
