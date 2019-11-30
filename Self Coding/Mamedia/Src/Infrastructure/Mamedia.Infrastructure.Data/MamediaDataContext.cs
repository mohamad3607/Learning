using Mamedia.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Infrastructure.Data
{
    public class MamediaDataContext : DbContext
    {
        public MamediaDataContext(DbContextOptions<MamediaDataContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostKind> PostKinds { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<TrackDownloadLink> TrackDownloadLinks { get; set; }
        public DbSet<MovieLink> MovieLinks { get; set; }
        public DbSet<PurchaseAlbumLink> PurchaseAlbumLinks { get; set; }
        public DbSet<PurchaseSeriesEpisodeLink> PurchaseSeriesEpisodeLinks { get; set; }
        public DbSet<AlbumDownloadLink> AlbumDownloadLinks { get; set; }
        public DbSet<DownloadableAlbum> DownloadableAlbums { get; set; }
        public DbSet<PurchasableAlbum> PurchasableAlbums { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<PurchasableSeriesEpisode> PurchasableSeriesEpisodes { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistType> ArtistTypes { get; set; }
        public DbSet<TypeOfArtist> TypeOfArtists { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<TypeOfArtist>().HasData(
                new TypeOfArtist() { Title = "بازیگر",Id=2 },
                new TypeOfArtist() { Title = "کارگردان",Id=3 },
                new TypeOfArtist() { Title = "نویسنده",Id=4 },
                new TypeOfArtist() { Title = "خواننده",Id=1 }
                );
            modelBuilder.Entity<PostKind>().HasData(
                new PostKind() { Kind = "تک آهنگ", Id = 1 },
                new PostKind() { Kind = "فیلم", Id = 3 },
                new PostKind() { Kind = "سریال", Id = 4 },
                new PostKind() { Kind = "آلبوم قابل دانلود", Id = 2 },
                new PostKind() { Kind = "آلبوم قابل خرید", Id = 5 }
                );
            modelBuilder.Entity<PostKind>()
                .HasMany<Post>(pk => pk.Posts)
                .WithOne(p => p.PostKind)
                .HasForeignKey(p => p.PostKindId);

            modelBuilder.Entity<ArtistType>().HasKey(bp => bp.Id);
            modelBuilder.Entity<ArtistType>().HasOne<Artist>(at => at.Artist).WithMany(a => a.ArtistTypes).HasForeignKey(at => at.ArtistId);
            modelBuilder.Entity<ArtistType>().HasOne<TypeOfArtist>(at => at.TypeOfArtist).WithMany(a => a.ArtistTypes).HasForeignKey(at => at.TypeId);

            modelBuilder.Entity<MovieArtists>().HasKey(bp => new { bp.ArtistTypeId, bp.MovieId });
            modelBuilder.Entity<MovieArtists>().HasOne<Movie>(at => at.Movie).WithMany(a => a.Artists).HasForeignKey(at => at.MovieId);
            modelBuilder.Entity<MovieArtists>().HasOne<ArtistType>(at => at.ArtistType).WithMany(a => a.MovieArtists).HasForeignKey(at => at.ArtistTypeId);

            modelBuilder.Entity<TrackArtist>().HasKey(bp => new { bp.ArtistTypeId, bp.TrackId });
            modelBuilder.Entity<TrackArtist>().HasOne<Track>(at => at.Track).WithMany(a => a.TrackArtists).HasForeignKey(at => at.TrackId);
            modelBuilder.Entity<TrackArtist>().HasOne<ArtistType>(at => at.ArtistType).WithMany(a => a.TrackArtists).HasForeignKey(at => at.ArtistTypeId);

            modelBuilder.Entity<DownloadableAlbumArtist>().HasKey(bp => new { bp.ArtistTypeId, bp.AlbumId });
            modelBuilder.Entity<DownloadableAlbumArtist>().HasOne<DownloadableAlbum>(at => at.DownloadableAlbum).WithMany(a => a.Artists).HasForeignKey(at => at.AlbumId);
            modelBuilder.Entity<DownloadableAlbumArtist>().HasOne<ArtistType>(at => at.ArtistType).WithMany(a => a.DownloadableAlbumArtists).HasForeignKey(at => at.ArtistTypeId);

            modelBuilder.Entity<PurchasableAlbumArtists>().HasKey(bp => new { bp.ArtistTypeId, bp.AlbumId });
            modelBuilder.Entity<PurchasableAlbumArtists>().HasOne<PurchasableAlbum>(at => at.PurchasableAlbum).WithMany(a => a.Artists).HasForeignKey(at => at.AlbumId);
            modelBuilder.Entity<PurchasableAlbumArtists>().HasOne<ArtistType>(at => at.ArtistType).WithMany(a => a.PurchasableAlbumArtists).HasForeignKey(at => at.ArtistTypeId);

            modelBuilder.Entity<SeriesArtist>().HasKey(bp => new { bp.ArtistTypeId, bp.SeriesId });
            modelBuilder.Entity<SeriesArtist>().HasOne<Series>(at => at.Series).WithMany(a => a.Artists).HasForeignKey(at => at.SeriesId);
            modelBuilder.Entity<SeriesArtist>().HasOne<ArtistType>(at => at.ArtistType).WithMany(a => a.SeriesArtists).HasForeignKey(at => at.ArtistTypeId);

            modelBuilder.Entity<Track>().HasMany<TrackDownloadLink>(t => t.DownloadLinks)
                .WithOne(td => td.Track).HasForeignKey(td => td.TrackId);
            modelBuilder.Entity<DownloadableAlbum>().HasMany<AlbumDownloadLink>(t => t.DownloadLinks)
                .WithOne(td => td.Album).HasForeignKey(td => td.AlbumId);
            modelBuilder.Entity<PurchasableAlbum>().HasMany<PurchaseAlbumLink>(t => t.PurchaseLinks)
                .WithOne(td => td.Album).HasForeignKey(td => td.AlbumId);
            modelBuilder.Entity<Movie>().HasMany<MovieLink>(t => t.PurchaseLinks)
              .WithOne(td => td.Movie).HasForeignKey(td => td.MovieId);
            modelBuilder.Entity<PurchasableSeriesEpisode>().HasMany<PurchaseSeriesEpisodeLink>(t => t.PurchaseLinks)
              .WithOne(td => td.PurchasableSeriesEpisode).HasForeignKey(td => td.PurchasableSeriesEpisodeId);


            modelBuilder.Entity<Post>()
                .HasOne<Track>(p => p.Track).WithOne().HasForeignKey<Post>(p => p.TrackId);
           

        }
    }
}
