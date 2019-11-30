﻿// <auto-generated />
using System;
using Mamedia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mamedia.Infrastructure.Data.Migrations
{
    [DbContext(typeof(MamediaDataContext))]
    [Migration("20191127124138_Post Track Foreign Key")]
    partial class PostTrackForeignKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.AlbumDownloadLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlbumId");

                    b.Property<string>("Tilte");

                    b.Property<string>("UrlForLink");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("AlbumDownloadLinks");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography");

                    b.Property<string>("EnglishName");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.ArtistType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArtistId");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("TypeId");

                    b.ToTable("ArtistTypes");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.DownloadableAlbum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoverPhotoAddress");

                    b.Property<string>("CoverPhotoAlterText");

                    b.Property<string>("EnglishName");

                    b.Property<string>("Name");

                    b.Property<string>("Summary");

                    b.HasKey("Id");

                    b.ToTable("DownloadableAlbums");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.DownloadableAlbumArtist", b =>
                {
                    b.Property<int>("ArtistTypeId");

                    b.Property<int>("AlbumId");

                    b.HasKey("ArtistTypeId", "AlbumId");

                    b.HasIndex("AlbumId");

                    b.ToTable("DownloadableAlbumArtist");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArtistTypeId");

                    b.Property<string>("CoverPhotoAddress");

                    b.Property<string>("CoverPhotoAlterText");

                    b.Property<string>("EnglishName");

                    b.Property<string>("Name");

                    b.Property<string>("ProductionCountry");

                    b.Property<int>("ProductionYear");

                    b.Property<string>("Summary");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.MovieArtists", b =>
                {
                    b.Property<int>("ArtistTypeId");

                    b.Property<int>("MovieId");

                    b.HasKey("ArtistTypeId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieArtists");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.MovieLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MovieId");

                    b.Property<int>("Price");

                    b.Property<string>("Tilte");

                    b.Property<string>("UrlForLink");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieLinks");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AllowToPublish");

                    b.Property<int?>("DownloadableAlbumId");

                    b.Property<int?>("MovieId");

                    b.Property<int>("PostKindId");

                    b.Property<DateTime>("PublishDate");

                    b.Property<int?>("PurchasableAlbumId");

                    b.Property<int?>("PurchasableSeriesEpisodeId");

                    b.Property<string>("Title");

                    b.Property<int>("TrackId");

                    b.Property<string>("UniqueId");

                    b.HasKey("Id");

                    b.HasIndex("DownloadableAlbumId");

                    b.HasIndex("MovieId");

                    b.HasIndex("PostKindId");

                    b.HasIndex("PurchasableAlbumId");

                    b.HasIndex("PurchasableSeriesEpisodeId");

                    b.HasIndex("TrackId")
                        .IsUnique();

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.PostKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kind");

                    b.HasKey("Id");

                    b.ToTable("PostKinds");

                    b.HasData(
                        new { Id = 1, Kind = "تک آهنگ" },
                        new { Id = 3, Kind = "فیلم" },
                        new { Id = 4, Kind = "سریال" },
                        new { Id = 2, Kind = "آلبوم قابل دانلود" },
                        new { Id = 5, Kind = "آلبوم قابل خرید" }
                    );
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.PurchasableAlbum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoverPhotoAddress");

                    b.Property<string>("CoverPhotoAlterText");

                    b.Property<string>("EnglishName");

                    b.Property<string>("Name");

                    b.Property<string>("Summary");

                    b.HasKey("Id");

                    b.ToTable("PurchasableAlbums");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.PurchasableAlbumArtists", b =>
                {
                    b.Property<int>("ArtistTypeId");

                    b.Property<int>("AlbumId");

                    b.HasKey("ArtistTypeId", "AlbumId");

                    b.HasIndex("AlbumId");

                    b.ToTable("PurchasableAlbumArtists");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.PurchaseAlbumLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AlbumId");

                    b.Property<int>("Price");

                    b.Property<string>("Tilte");

                    b.Property<string>("UrlForLink");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("PurchaseAlbumLinks");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.PurchaseSeriesEpisodeLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Price");

                    b.Property<int>("PurchasableSeriesEpisodeId");

                    b.Property<string>("Tilte");

                    b.Property<string>("UrlForLink");

                    b.HasKey("Id");

                    b.HasIndex("PurchasableSeriesEpisodeId");

                    b.ToTable("PurchaseSeriesEpisodeLinks");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EnglishName");

                    b.Property<string>("Name");

                    b.Property<string>("ProductionCountry");

                    b.Property<int>("ProductionYear");

                    b.Property<string>("Summary");

                    b.HasKey("Id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.SeriesArtist", b =>
                {
                    b.Property<int>("ArtistTypeId");

                    b.Property<int>("SeriesId");

                    b.HasKey("ArtistTypeId", "SeriesId");

                    b.HasIndex("SeriesId");

                    b.ToTable("SeriesArtist");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.SeriesEpisode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("EnglishName");

                    b.Property<string>("Name");

                    b.Property<string>("ProductionCountry");

                    b.Property<int>("ProductionYear");

                    b.Property<int?>("SeriesId");

                    b.HasKey("Id");

                    b.HasIndex("SeriesId");

                    b.ToTable("SeriesEpisode");

                    b.HasDiscriminator<string>("Discriminator").HasValue("SeriesEpisode");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoverPhotoAddress");

                    b.Property<string>("CoverPhotoAlterText");

                    b.Property<string>("Cross");

                    b.Property<string>("EnglishName");

                    b.Property<string>("Lyric");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.TrackArtist", b =>
                {
                    b.Property<int>("ArtistTypeId");

                    b.Property<int>("TrackId");

                    b.HasKey("ArtistTypeId", "TrackId");

                    b.HasIndex("TrackId");

                    b.ToTable("TrackArtist");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.TrackDownloadLink", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tilte");

                    b.Property<int>("TrackId");

                    b.Property<string>("UrlForLink");

                    b.HasKey("Id");

                    b.HasIndex("TrackId");

                    b.ToTable("TrackDownloadLinks");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.TypeOfArtist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("TypeOfArtists");

                    b.HasData(
                        new { Id = 2, Title = "بازیگر" },
                        new { Id = 3, Title = "کارگردان" },
                        new { Id = 4, Title = "نویسنده" },
                        new { Id = 1, Title = "خواننده" }
                    );
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.PurchasableSeriesEpisode", b =>
                {
                    b.HasBaseType("Mamedia.Domain.Core.Entities.SeriesEpisode");

                    b.Property<string>("CoverPhotoAddress");

                    b.Property<string>("CoverPhotoAlterText");

                    b.Property<string>("Summary");

                    b.ToTable("PurchasableSeriesEpisode");

                    b.HasDiscriminator().HasValue("PurchasableSeriesEpisode");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.AlbumDownloadLink", b =>
                {
                    b.HasOne("Mamedia.Domain.Core.Entities.DownloadableAlbum", "Album")
                        .WithMany("DownloadLinks")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.ArtistType", b =>
                {
                    b.HasOne("Mamedia.Domain.Core.Entities.Artist", "Artist")
                        .WithMany("ArtistTypes")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mamedia.Domain.Core.Entities.TypeOfArtist", "TypeOfArtist")
                        .WithMany("ArtistTypes")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.DownloadableAlbumArtist", b =>
                {
                    b.HasOne("Mamedia.Domain.Core.Entities.DownloadableAlbum", "DownloadableAlbum")
                        .WithMany("Artists")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mamedia.Domain.Core.Entities.ArtistType", "ArtistType")
                        .WithMany("DownloadableAlbumArtists")
                        .HasForeignKey("ArtistTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.MovieArtists", b =>
                {
                    b.HasOne("Mamedia.Domain.Core.Entities.ArtistType", "ArtistType")
                        .WithMany("MovieArtists")
                        .HasForeignKey("ArtistTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mamedia.Domain.Core.Entities.Movie", "Movie")
                        .WithMany("Artists")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.MovieLink", b =>
                {
                    b.HasOne("Mamedia.Domain.Core.Entities.Movie", "Movie")
                        .WithMany("PurchaseLinks")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.Post", b =>
                {
                    b.HasOne("Mamedia.Domain.Core.Entities.DownloadableAlbum", "DownloadableAlbum")
                        .WithMany()
                        .HasForeignKey("DownloadableAlbumId");

                    b.HasOne("Mamedia.Domain.Core.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId");

                    b.HasOne("Mamedia.Domain.Core.Entities.PostKind", "PostKind")
                        .WithMany("Posts")
                        .HasForeignKey("PostKindId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mamedia.Domain.Core.Entities.PurchasableAlbum", "PurchasableAlbum")
                        .WithMany()
                        .HasForeignKey("PurchasableAlbumId");

                    b.HasOne("Mamedia.Domain.Core.Entities.PurchasableSeriesEpisode", "PurchasableSeriesEpisode")
                        .WithMany()
                        .HasForeignKey("PurchasableSeriesEpisodeId");

                    b.HasOne("Mamedia.Domain.Core.Entities.Track", "Track")
                        .WithOne()
                        .HasForeignKey("Mamedia.Domain.Core.Entities.Post", "TrackId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.PurchasableAlbumArtists", b =>
                {
                    b.HasOne("Mamedia.Domain.Core.Entities.PurchasableAlbum", "PurchasableAlbum")
                        .WithMany("Artists")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mamedia.Domain.Core.Entities.ArtistType", "ArtistType")
                        .WithMany("PurchasableAlbumArtists")
                        .HasForeignKey("ArtistTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.PurchaseAlbumLink", b =>
                {
                    b.HasOne("Mamedia.Domain.Core.Entities.PurchasableAlbum", "Album")
                        .WithMany("PurchaseLinks")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.PurchaseSeriesEpisodeLink", b =>
                {
                    b.HasOne("Mamedia.Domain.Core.Entities.PurchasableSeriesEpisode", "PurchasableSeriesEpisode")
                        .WithMany("PurchaseLinks")
                        .HasForeignKey("PurchasableSeriesEpisodeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.SeriesArtist", b =>
                {
                    b.HasOne("Mamedia.Domain.Core.Entities.ArtistType", "ArtistType")
                        .WithMany("SeriesArtists")
                        .HasForeignKey("ArtistTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mamedia.Domain.Core.Entities.Series", "Series")
                        .WithMany("Artists")
                        .HasForeignKey("SeriesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.SeriesEpisode", b =>
                {
                    b.HasOne("Mamedia.Domain.Core.Entities.Series")
                        .WithMany("Episodes")
                        .HasForeignKey("SeriesId");
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.TrackArtist", b =>
                {
                    b.HasOne("Mamedia.Domain.Core.Entities.ArtistType", "ArtistType")
                        .WithMany("TrackArtists")
                        .HasForeignKey("ArtistTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mamedia.Domain.Core.Entities.Track", "Track")
                        .WithMany("TrackArtists")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Domain.Core.Entities.TrackDownloadLink", b =>
                {
                    b.HasOne("Mamedia.Domain.Core.Entities.Track", "Track")
                        .WithMany("DownloadLinks")
                        .HasForeignKey("TrackId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
