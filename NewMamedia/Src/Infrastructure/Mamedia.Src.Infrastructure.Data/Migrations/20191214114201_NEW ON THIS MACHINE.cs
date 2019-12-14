using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamedia.Src.Infrastructure.Data.Migrations
{
    public partial class NEWONTHISMACHINE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 20, nullable: true),
                    RegisterDate = table.Column<DateTime>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Bio = table.Column<string>(nullable: true),
                    LatinName = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostKinds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostKinds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfArtists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfArtists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    PublishPermission = table.Column<bool>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    UniqueId = table.Column<string>(maxLength: 200, nullable: true),
                    OpusName = table.Column<string>(maxLength: 150, nullable: true),
                    OpusLatinName = table.Column<string>(maxLength: 150, nullable: true),
                    CoverPhotoUrl = table.Column<string>(maxLength: 500, nullable: true),
                    CoverPhotoTag = table.Column<string>(maxLength: 150, nullable: true),
                    PostKindId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Admins_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_PostKinds_PostKindId",
                        column: x => x.PostKindId,
                        principalTable: "PostKinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtistId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistTypes_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistTypes_TypeOfArtists_TypeId",
                        column: x => x.TypeId,
                        principalTable: "TypeOfArtists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tilte = table.Column<string>(maxLength: 50, nullable: true),
                    UrlForLink = table.Column<string>(maxLength: 500, nullable: true),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchasableAlbumInfo",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasableAlbumInfo", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_PurchasableAlbumInfo_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackInfo",
                columns: table => new
                {
                    PostId = table.Column<int>(nullable: false),
                    Cross = table.Column<string>(maxLength: 500, nullable: true),
                    Lyric = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackInfo", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_TrackInfo_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostArtists",
                columns: table => new
                {
                    ArtistTypeId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostArtists", x => new { x.PostId, x.ArtistTypeId });
                    table.ForeignKey(
                        name: "FK_PostArtists_ArtistTypes_ArtistTypeId",
                        column: x => x.ArtistTypeId,
                        principalTable: "ArtistTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostArtists_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PostKinds",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "آهنگ جدید" },
                    { 3, "فیلم جدید" },
                    { 4, "سریال جدید" },
                    { 2, "آلبوم جدید" },
                    { 5, "ورژن جدید" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfArtists",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 2, "بازیگر" },
                    { 3, "کارگردان" },
                    { 4, "نویسنده" },
                    { 1, "خواننده" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistTypes_ArtistId",
                table: "ArtistTypes",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistTypes_TypeId",
                table: "ArtistTypes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PostId",
                table: "Links",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostArtists_ArtistTypeId",
                table: "PostArtists",
                column: "ArtistTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostKindId",
                table: "Posts",
                column: "PostKindId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "PostArtists");

            migrationBuilder.DropTable(
                name: "PurchasableAlbumInfo");

            migrationBuilder.DropTable(
                name: "TrackInfo");

            migrationBuilder.DropTable(
                name: "ArtistTypes");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "TypeOfArtists");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "PostKinds");
        }
    }
}
