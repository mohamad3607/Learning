using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamedia.Src.Infrastructure.Data.Migrations
{
    public partial class series : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SeriesInfos",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    Summary = table.Column<string>(maxLength: 1000, nullable: true),
                    Price = table.Column<int>(nullable: false),
                    ProductionYear = table.Column<int>(nullable: false),
                    Duration = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesInfos", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_SeriesInfos_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeriesInfos");
        }
    }
}
