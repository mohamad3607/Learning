using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamedia.Infrastructure.Data.Migrations
{
    public partial class PostTrackForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Tracks_TrackId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_TrackId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "TrackId",
                table: "Posts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "PostKinds",
                keyColumn: "Id",
                keyValue: 2,
                column: "Kind",
                value: "آلبوم قابل دانلود");

            migrationBuilder.InsertData(
                table: "PostKinds",
                columns: new[] { "Id", "Kind" },
                values: new object[] { 5, "آلبوم قابل خرید" });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TrackId",
                table: "Posts",
                column: "TrackId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Tracks_TrackId",
                table: "Posts",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Tracks_TrackId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_TrackId",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "PostKinds",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<int>(
                name: "TrackId",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "PostKinds",
                keyColumn: "Id",
                keyValue: 2,
                column: "Kind",
                value: "آلبوم");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TrackId",
                table: "Posts",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Tracks_TrackId",
                table: "Posts",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
