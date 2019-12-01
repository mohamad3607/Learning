using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamedia.Infrastructure.Data.Migrations
{
    public partial class NEWDB4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Tracks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Tracks",
                nullable: false,
                defaultValue: 0);
        }
    }
}
