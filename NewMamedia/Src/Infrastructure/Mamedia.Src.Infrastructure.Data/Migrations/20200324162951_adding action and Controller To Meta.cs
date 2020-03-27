using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamedia.Src.Infrastructure.Data.Migrations
{
    public partial class addingactionandControllerToMeta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActionName",
                table: "MetaInfos",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ControllerName",
                table: "MetaInfos",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionName",
                table: "MetaInfos");

            migrationBuilder.DropColumn(
                name: "ControllerName",
                table: "MetaInfos");
        }
    }
}
