using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamedia.Infrastructure.Data.Migrations
{
    public partial class PostKindTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostKind",
                table: "Posts",
                newName: "PostKindId");

            migrationBuilder.CreateTable(
                name: "PostKinds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kind = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostKinds", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PostKinds",
                columns: new[] { "Id", "Kind" },
                values: new object[,]
                {
                    { 1, "تک آهنگ" },
                    { 3, "فیلم" },
                    { 4, "سریال" },
                    { 2, "آلبوم" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostKindId",
                table: "Posts",
                column: "PostKindId");

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

            migrationBuilder.DropTable(
                name: "PostKinds");

            migrationBuilder.DropIndex(
                name: "IX_Posts_PostKindId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "PostKindId",
                table: "Posts",
                newName: "PostKind");
        }
    }
}
