using Mamedia.Src.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Src.Infrastructure.Data
{
    public class MamediaDataContext : DbContext
    {
        public MamediaDataContext(DbContextOptions<MamediaDataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateInheritances(modelBuilder);

            modelBuilder.Entity<TypeOfArtist>().HasData(
                new TypeOfArtist() { Type = "بازیگر", Id = 2 },
                new TypeOfArtist() { Type = "کارگردان", Id = 3 },
                new TypeOfArtist() { Type = "نویسنده", Id = 4 },
                new TypeOfArtist() { Type = "خواننده", Id = 1 }
                );
            modelBuilder.Entity<PostKind>().HasData(
                new PostKind() { Title = "آهنگ جدید", Id = 1 },
                new PostKind() { Title = "فیلم جدید", Id = 3 },
                new PostKind() { Title = "سریال جدید", Id = 4 },
                new PostKind() { Title = "آلبوم جدید", Id = 2 },
                new PostKind() { Title = "ورژن جدید", Id = 5 }
                );
            ArtistModelCreating(modelBuilder);
            LinkModelCreating(modelBuilder);
            PostModelCreating(modelBuilder);
        }

       
        private void CreateInheritances(ModelBuilder builder)
        {
            builder.Entity<TrackPost>().HasBaseType<Post>();
            builder.Entity<PurchasableAlbumPost>().HasBaseType<Post>();  
        }
        private void LinkModelCreating(ModelBuilder builder)
        {
            builder.Entity<Link>()
                .HasOne(l => l.Post)
                .WithMany(p => p.Links)
                .HasForeignKey(l => l.PostId);

        }
        private void ArtistModelCreating(ModelBuilder builder)
        {
            //builder.Entity<ArtistType>().HasKey(at => new { at.ArtistId, at.TypeId });
            builder.Entity<Artist>()
                .HasMany(c => c.Types)
                .WithOne(x => x.Artist)
                .HasForeignKey(x => x.ArtistId);
            builder.Entity<TypeOfArtist>()
                .HasMany(c => c.Artists)
                .WithOne(x => x.Type)
                .HasForeignKey(x => x.TypeId);
            builder.Entity<ArtistType>()
                .HasMany(c => c.Posts)
                .WithOne(x => x.ArtistType)
                .HasForeignKey(x => x.ArtistTypeId);

        }
        private void PostModelCreating(ModelBuilder builder)
        {
            builder.Entity<PostArtist>().HasKey(pa => new { pa.PostId, pa.ArtistTypeId });
            builder.Entity<TrackInfo>().HasKey(x =>x.PostId);
            builder.Entity<PurchasableAlbumInfo>().HasKey(x =>x.PostId);

            builder.Entity<Post>()
                .HasMany(p => p.Artists)
                .WithOne(pa => pa.Post)
                .HasForeignKey(pa => pa.PostId);
            builder.Entity<TrackPost>()
                .HasOne(tp => tp.Info)
                .WithOne(ti => ti.Post)
                .HasForeignKey<TrackInfo>(ti => ti.PostId);
            builder.Entity<PurchasableAlbumPost>()
                .HasOne(tp => tp.Info)
                .WithOne(ti => ti.Post)
                .HasForeignKey<PurchasableAlbumInfo>(ti => ti.PostId);
            builder.Entity<Post>()
               .HasOne(p => p.PostKind)
               .WithMany(pa => pa.Posts)
               .HasForeignKey(pa => pa.PostKindId);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ArtistType> ArtistTypes { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<PostArtist> PostArtists { get; set; }
        public DbSet<TypeOfArtist> TypeOfArtists { get; set; }
        public DbSet<PostKind> PostKinds { get; set; }
        public DbSet<TrackInfo> TrackInfos { get; set; }
        
    }
}
