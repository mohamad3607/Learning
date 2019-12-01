using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mamedia.Infrastructure.Data.Migrations
{
    public partial class NEWDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    EnglishName = table.Column<string>(nullable: true),
                    Biography = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DownloadableAlbums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    EnglishName = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    CoverPhotoAddress = table.Column<string>(nullable: true),
                    CoverPhotoAlterText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadableAlbums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    EnglishName = table.Column<string>(nullable: true),
                    ProductionYear = table.Column<int>(nullable: false),
                    ProductionCountry = table.Column<string>(nullable: true),
                    ArtistTypeId = table.Column<int>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    CoverPhotoAddress = table.Column<string>(nullable: true),
                    CoverPhotoAlterText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "PurchasableAlbums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    EnglishName = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    CoverPhotoAddress = table.Column<string>(nullable: true),
                    CoverPhotoAlterText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasableAlbums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    EnglishName = table.Column<string>(nullable: true),
                    ProductionYear = table.Column<int>(nullable: false),
                    ProductionCountry = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    EnglishName = table.Column<string>(nullable: true),
                    Cross = table.Column<string>(nullable: true),
                    Lyric = table.Column<string>(nullable: true),
                    CoverPhotoAddress = table.Column<string>(nullable: true),
                    CoverPhotoAlterText = table.Column<string>(nullable: true),
                    TrackArtistId = table.Column<int>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfArtists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfArtists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlbumDownloadLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tilte = table.Column<string>(nullable: true),
                    UrlForLink = table.Column<string>(nullable: true),
                    AlbumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumDownloadLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumDownloadLinks_DownloadableAlbums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "DownloadableAlbums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tilte = table.Column<string>(nullable: true),
                    UrlForLink = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieLinks_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseAlbumLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tilte = table.Column<string>(nullable: true),
                    UrlForLink = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    AlbumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseAlbumLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseAlbumLinks_PurchasableAlbums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "PurchasableAlbums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesEpisode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    EnglishName = table.Column<string>(nullable: true),
                    ProductionYear = table.Column<int>(nullable: false),
                    ProductionCountry = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    SeriesId = table.Column<int>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    CoverPhotoAddress = table.Column<string>(nullable: true),
                    CoverPhotoAlterText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesEpisode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeriesEpisode_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrackDownloadLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tilte = table.Column<string>(nullable: true),
                    UrlForLink = table.Column<string>(nullable: true),
                    TrackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackDownloadLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackDownloadLinks_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
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
                    TypeId = table.Column<int>(nullable: false),
                    TrackArtistId = table.Column<int>(nullable: false)
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
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    AllowToPublish = table.Column<bool>(nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false),
                    UniqueId = table.Column<string>(nullable: true),
                    TrackId = table.Column<int>(nullable: false),
                    DownloadableAlbumId = table.Column<int>(nullable: true),
                    MovieId = table.Column<int>(nullable: true),
                    PurchasableAlbumId = table.Column<int>(nullable: true),
                    PurchasableSeriesEpisodeId = table.Column<int>(nullable: true),
                    PostKindId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_DownloadableAlbums_DownloadableAlbumId",
                        column: x => x.DownloadableAlbumId,
                        principalTable: "DownloadableAlbums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_PostKinds_PostKindId",
                        column: x => x.PostKindId,
                        principalTable: "PostKinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_PurchasableAlbums_PurchasableAlbumId",
                        column: x => x.PurchasableAlbumId,
                        principalTable: "PurchasableAlbums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_SeriesEpisode_PurchasableSeriesEpisodeId",
                        column: x => x.PurchasableSeriesEpisodeId,
                        principalTable: "SeriesEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseSeriesEpisodeLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tilte = table.Column<string>(nullable: true),
                    UrlForLink = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    PurchasableSeriesEpisodeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseSeriesEpisodeLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseSeriesEpisodeLinks_SeriesEpisode_PurchasableSeriesEpisodeId",
                        column: x => x.PurchasableSeriesEpisodeId,
                        principalTable: "SeriesEpisode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DownloadableAlbumArtist",
                columns: table => new
                {
                    AlbumId = table.Column<int>(nullable: false),
                    ArtistTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadableAlbumArtist", x => new { x.ArtistTypeId, x.AlbumId });
                    table.ForeignKey(
                        name: "FK_DownloadableAlbumArtist_DownloadableAlbums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "DownloadableAlbums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DownloadableAlbumArtist_ArtistTypes_ArtistTypeId",
                        column: x => x.ArtistTypeId,
                        principalTable: "ArtistTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieArtists",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false),
                    ArtistTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieArtists", x => new { x.ArtistTypeId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_MovieArtists_ArtistTypes_ArtistTypeId",
                        column: x => x.ArtistTypeId,
                        principalTable: "ArtistTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieArtists_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchasableAlbumArtists",
                columns: table => new
                {
                    AlbumId = table.Column<int>(nullable: false),
                    ArtistTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasableAlbumArtists", x => new { x.ArtistTypeId, x.AlbumId });
                    table.ForeignKey(
                        name: "FK_PurchasableAlbumArtists_PurchasableAlbums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "PurchasableAlbums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasableAlbumArtists_ArtistTypes_ArtistTypeId",
                        column: x => x.ArtistTypeId,
                        principalTable: "ArtistTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesArtist",
                columns: table => new
                {
                    SeriesId = table.Column<int>(nullable: false),
                    ArtistTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesArtist", x => new { x.ArtistTypeId, x.SeriesId });
                    table.ForeignKey(
                        name: "FK_SeriesArtist_ArtistTypes_ArtistTypeId",
                        column: x => x.ArtistTypeId,
                        principalTable: "ArtistTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeriesArtist_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackArtist",
                columns: table => new
                {
                    TrackId = table.Column<int>(nullable: false),
                    ArtistTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackArtist", x => new { x.ArtistTypeId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_TrackArtist_ArtistTypes_ArtistTypeId",
                        column: x => x.ArtistTypeId,
                        principalTable: "ArtistTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackArtist_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PostKinds",
                columns: new[] { "Id", "Kind" },
                values: new object[,]
                {
                    { 1, "تک آهنگ" },
                    { 3, "فیلم" },
                    { 4, "سریال" },
                    { 2, "آلبوم قابل دانلود" },
                    { 5, "آلبوم قابل خرید" }
                });

            migrationBuilder.InsertData(
                table: "TypeOfArtists",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 2, "بازیگر" },
                    { 3, "کارگردان" },
                    { 4, "نویسنده" },
                    { 1, "خواننده" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumDownloadLinks_AlbumId",
                table: "AlbumDownloadLinks",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistTypes_ArtistId",
                table: "ArtistTypes",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistTypes_TypeId",
                table: "ArtistTypes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadableAlbumArtist_AlbumId",
                table: "DownloadableAlbumArtist",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieArtists_MovieId",
                table: "MovieArtists",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieLinks_MovieId",
                table: "MovieLinks",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_DownloadableAlbumId",
                table: "Posts",
                column: "DownloadableAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_MovieId",
                table: "Posts",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostKindId",
                table: "Posts",
                column: "PostKindId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PurchasableAlbumId",
                table: "Posts",
                column: "PurchasableAlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PurchasableSeriesEpisodeId",
                table: "Posts",
                column: "PurchasableSeriesEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TrackId",
                table: "Posts",
                column: "TrackId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchasableAlbumArtists_AlbumId",
                table: "PurchasableAlbumArtists",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseAlbumLinks_AlbumId",
                table: "PurchaseAlbumLinks",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseSeriesEpisodeLinks_PurchasableSeriesEpisodeId",
                table: "PurchaseSeriesEpisodeLinks",
                column: "PurchasableSeriesEpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesArtist_SeriesId",
                table: "SeriesArtist",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesEpisode_SeriesId",
                table: "SeriesEpisode",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackArtist_TrackId",
                table: "TrackArtist",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackDownloadLinks_TrackId",
                table: "TrackDownloadLinks",
                column: "TrackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumDownloadLinks");

            migrationBuilder.DropTable(
                name: "DownloadableAlbumArtist");

            migrationBuilder.DropTable(
                name: "MovieArtists");

            migrationBuilder.DropTable(
                name: "MovieLinks");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "PurchasableAlbumArtists");

            migrationBuilder.DropTable(
                name: "PurchaseAlbumLinks");

            migrationBuilder.DropTable(
                name: "PurchaseSeriesEpisodeLinks");

            migrationBuilder.DropTable(
                name: "SeriesArtist");

            migrationBuilder.DropTable(
                name: "TrackArtist");

            migrationBuilder.DropTable(
                name: "TrackDownloadLinks");

            migrationBuilder.DropTable(
                name: "DownloadableAlbums");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "PostKinds");

            migrationBuilder.DropTable(
                name: "PurchasableAlbums");

            migrationBuilder.DropTable(
                name: "SeriesEpisode");

            migrationBuilder.DropTable(
                name: "ArtistTypes");

            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "TypeOfArtists");
        }
    }
}
