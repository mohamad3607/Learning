using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamedia.Src.Infrastructure.Data.Migrations
{
    public partial class ADDINGMIGRATE3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostKind_PostKindId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostKind",
                table: "PostKind");

            migrationBuilder.RenameTable(
                name: "PostKind",
                newName: "PostKinds");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostKinds",
                table: "PostKinds",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostKinds_PostKindId",
                table: "Posts",
                column: "PostKindId",
                principalTable: "PostKinds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostKinds_PostKindId",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostKinds",
                table: "PostKinds");

            migrationBuilder.RenameTable(
                name: "PostKinds",
                newName: "PostKind");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostKind",
                table: "PostKind",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostKind_PostKindId",
                table: "Posts",
                column: "PostKindId",
                principalTable: "PostKind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
