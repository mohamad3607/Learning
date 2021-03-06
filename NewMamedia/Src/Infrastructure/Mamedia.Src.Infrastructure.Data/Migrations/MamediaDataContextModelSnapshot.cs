﻿// <auto-generated />
using System;
using Mamedia.Src.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mamedia.Src.Infrastructure.Data.Migrations
{
    [DbContext(typeof(MamediaDataContext))]
    partial class MamediaDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Email")
                        .HasMaxLength(200);

                    b.Property<string>("Password")
                        .HasMaxLength(20);

                    b.Property<DateTime>("RegisterDate");

                    b.Property<string>("Username")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio");

                    b.Property<string>("Image")
                        .HasMaxLength(200);

                    b.Property<string>("LatinName")
                        .HasMaxLength(150);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.ArtistType", b =>
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

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PostId");

                    b.Property<string>("Tilte")
                        .HasMaxLength(50);

                    b.Property<string>("UrlForLink")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.MetaInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionName")
                        .HasMaxLength(200);

                    b.Property<string>("ControllerName")
                        .HasMaxLength(200);

                    b.Property<string>("H1Tag")
                        .HasMaxLength(200);

                    b.Property<string>("H2Tag")
                        .HasMaxLength(400);

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(500);

                    b.Property<string>("PageTitle")
                        .HasMaxLength(200);

                    b.Property<string>("Url")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("MetaInfos");
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.MovieInfo", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<int>("Duration");

                    b.Property<int>("Price");

                    b.Property<int>("ProductionYear");

                    b.Property<string>("Summary")
                        .HasMaxLength(1000);

                    b.HasKey("PostId");

                    b.ToTable("MovieInfos");
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<string>("CoverPhotoTag")
                        .HasMaxLength(150);

                    b.Property<string>("CoverPhotoUrl")
                        .HasMaxLength(500);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("MetaDescription")
                        .HasMaxLength(200);

                    b.Property<string>("OpusLatinName")
                        .HasMaxLength(150);

                    b.Property<string>("OpusName")
                        .HasMaxLength(150);

                    b.Property<int>("PostKindId");

                    b.Property<DateTime>("PublishDate");

                    b.Property<bool>("PublishPermission");

                    b.Property<string>("Title")
                        .HasMaxLength(500);

                    b.Property<string>("UniqueId")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("PostKindId");

                    b.ToTable("Posts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Post");
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.PostArtist", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<int>("ArtistTypeId");

                    b.Property<bool>("ShowInPost");

                    b.HasKey("PostId", "ArtistTypeId");

                    b.HasIndex("ArtistTypeId");

                    b.ToTable("PostArtists");
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.PostKind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("PostKinds");

                    b.HasData(
                        new { Id = 1, Title = "آهنگ جدید" },
                        new { Id = 3, Title = "فیلم جدید" },
                        new { Id = 4, Title = "سریال جدید" },
                        new { Id = 2, Title = "آلبوم جدید" },
                        new { Id = 5, Title = "ورژن جدید" }
                    );
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.PurchasableAlbumInfo", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<int>("Price");

                    b.Property<string>("Summary")
                        .HasMaxLength(1000);

                    b.HasKey("PostId");

                    b.ToTable("PurchasableAlbumInfos");
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.SeriesInfo", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<int>("Duration");

                    b.Property<int>("Price");

                    b.Property<int>("ProductionYear");

                    b.Property<string>("Summary")
                        .HasMaxLength(1000);

                    b.HasKey("PostId");

                    b.ToTable("SeriesInfos");
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.TrackInfo", b =>
                {
                    b.Property<int>("PostId");

                    b.Property<string>("Cross")
                        .HasMaxLength(500);

                    b.Property<string>("Lyric")
                        .HasMaxLength(3000);

                    b.HasKey("PostId");

                    b.ToTable("TrackInfos");
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.TypeOfArtist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("TypeOfArtists");

                    b.HasData(
                        new { Id = 2, Type = "بازیگر" },
                        new { Id = 3, Type = "کارگردان" },
                        new { Id = 4, Type = "نویسنده" },
                        new { Id = 1, Type = "خواننده" }
                    );
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.Album", b =>
                {
                    b.HasBaseType("Mamedia.Src.Domain.Core.Entities.Post");


                    b.ToTable("Album");

                    b.HasDiscriminator().HasValue("Album");
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.MoviePost", b =>
                {
                    b.HasBaseType("Mamedia.Src.Domain.Core.Entities.Post");


                    b.ToTable("MoviePost");

                    b.HasDiscriminator().HasValue("MoviePost");
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.SeriesPost", b =>
                {
                    b.HasBaseType("Mamedia.Src.Domain.Core.Entities.Post");


                    b.ToTable("SeriesPost");

                    b.HasDiscriminator().HasValue("SeriesPost");
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.TrackPost", b =>
                {
                    b.HasBaseType("Mamedia.Src.Domain.Core.Entities.Post");


                    b.ToTable("TrackPost");

                    b.HasDiscriminator().HasValue("TrackPost");
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.PurchasableAlbumPost", b =>
                {
                    b.HasBaseType("Mamedia.Src.Domain.Core.Entities.Album");


                    b.ToTable("PurchasableAlbumPost");

                    b.HasDiscriminator().HasValue("PurchasableAlbumPost");
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.ArtistType", b =>
                {
                    b.HasOne("Mamedia.Src.Domain.Core.Entities.Artist", "Artist")
                        .WithMany("Types")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mamedia.Src.Domain.Core.Entities.TypeOfArtist", "Type")
                        .WithMany("Artists")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.Link", b =>
                {
                    b.HasOne("Mamedia.Src.Domain.Core.Entities.Post", "Post")
                        .WithMany("Links")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.MovieInfo", b =>
                {
                    b.HasOne("Mamedia.Src.Domain.Core.Entities.MoviePost", "Post")
                        .WithOne("Info")
                        .HasForeignKey("Mamedia.Src.Domain.Core.Entities.MovieInfo", "PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.Post", b =>
                {
                    b.HasOne("Mamedia.Src.Domain.Core.Entities.Admin", "Author")
                        .WithMany("Posts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mamedia.Src.Domain.Core.Entities.PostKind", "PostKind")
                        .WithMany("Posts")
                        .HasForeignKey("PostKindId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.PostArtist", b =>
                {
                    b.HasOne("Mamedia.Src.Domain.Core.Entities.ArtistType", "ArtistType")
                        .WithMany("Posts")
                        .HasForeignKey("ArtistTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mamedia.Src.Domain.Core.Entities.Post", "Post")
                        .WithMany("Artists")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.PurchasableAlbumInfo", b =>
                {
                    b.HasOne("Mamedia.Src.Domain.Core.Entities.PurchasableAlbumPost", "Post")
                        .WithOne("Info")
                        .HasForeignKey("Mamedia.Src.Domain.Core.Entities.PurchasableAlbumInfo", "PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.SeriesInfo", b =>
                {
                    b.HasOne("Mamedia.Src.Domain.Core.Entities.SeriesPost", "Post")
                        .WithOne("Info")
                        .HasForeignKey("Mamedia.Src.Domain.Core.Entities.SeriesInfo", "PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mamedia.Src.Domain.Core.Entities.TrackInfo", b =>
                {
                    b.HasOne("Mamedia.Src.Domain.Core.Entities.TrackPost", "Post")
                        .WithOne("Info")
                        .HasForeignKey("Mamedia.Src.Domain.Core.Entities.TrackInfo", "PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
