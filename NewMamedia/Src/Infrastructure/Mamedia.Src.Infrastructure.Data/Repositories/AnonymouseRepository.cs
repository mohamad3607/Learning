using Mamedia.Src.Domain.Application.Repositories;
using Mamedia.Src.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mamedia.Src.Infrastructure.Data.Repositories
{
    public class AnonymouseRepository : IAnonymouseRepository
    {
        MamediaDataContext _context;
        public AnonymouseRepository(MamediaDataContext context)
        {
            _context = context;
        }
        public IEnumerable<PostKind> GetAllPostKinds()
        {
            throw new NotImplementedException();
        }

        public Artist GetArtistByName(string name)
        {
            var artists = _context.Artists
                .Where(a => a.LatinName == name || a.Name == name)
                .Include(a => a.Types).ThenInclude(at => at.Type)
                .Include(a => a.Types).ThenInclude(at => at.Posts).ThenInclude(p => p.Post)
                .OrderBy(a => a.Name.Trim())
                .ThenBy(a => a.Id)
                .FirstOrDefault();
            return artists;
        }

        public IEnumerable<Artist> GetArtistList()
        {
            var artists = _context.Artists.Include(a => a.Types).ThenInclude(at => at.Type)
                .OrderBy(a => a.Name.Trim())
                .ThenBy(a => a.Id);
            return artists;
        }

        public IEnumerable<Artist> GetArtistListByType(string type)
        {
            var artists = _context.Artists
                .Where(a => a.Types.Any(at => at.Type.Type == type))
                .Include(a => a.Types)
                .ThenInclude(at => at.Type)
                .OrderBy(a => a.Name.Trim())
                .ThenBy(a => a.Id);
            return artists;
        }

        public MovieInfo GetMovieInfoByPostId(int postId)
        {
            return _context.MovieInfos.Where(t => t.PostId == postId).FirstOrDefault();
        }

        public PurchasableAlbumInfo GetPAlbumInfoByPostId(int postId)
        {
            return _context.PurchasableAlbumInfos.Where(t => t.PostId == postId).FirstOrDefault();
        }

        public Post GetPostByUniqueId(string uniqueId)
        {
            return _context.Posts.Where(p => p.UniqueId == uniqueId)
               .Include(p => p.PostKind)
                   .Include(p => p.Artists).ThenInclude(pa => pa.ArtistType).ThenInclude(at => at.Artist)
                   .Include(p => p.Artists).ThenInclude(pa => pa.ArtistType).ThenInclude(at => at.Type)
                   .Include(p => p.Links)
                   .OrderByDescending(p => p.PublishDate).ThenByDescending(p => p.Id).FirstOrDefault();
        }

        public IEnumerable<Post> GetPublishableAlbums()
        {
            return _context.Posts.OfType<Album>().Where(p => p.CanBePublished == true)
                 .Include(p => p.PostKind)
                 .Include(p => p.Artists)
                      .ThenInclude(pa => pa.ArtistType)
                          .ThenInclude(at => at.Artist)
                 .Include(p => p.Links)
                 .OrderByDescending(p => p.PublishDate).ThenByDescending(p => p.Id);
        }

        public IEnumerable<Post> GetPublishableMovies()
        {

            return _context.Posts.OfType<MoviePost>().Where(p => p.CanBePublished == true)
                 .Include(p => p.PostKind)
                 .Include(p => p.Artists)
                      .ThenInclude(pa => pa.ArtistType)
                          .ThenInclude(at => at.Artist)
                 .Include(p => p.Links)
                 .OrderByDescending(p => p.PublishDate).ThenByDescending(p => p.Id);
        }

        public IEnumerable<Post> GetPublishablePosts()
        {
            return _context.Posts.Where(p => p.CanBePublished == true)
                   .Include(p => p.PostKind)
                   .Include(p => p.Artists)
                        .ThenInclude(pa => pa.ArtistType)
                            .ThenInclude(at => at.Artist)
                   .Include(p => p.Links)
                   .OrderByDescending(p => p.PublishDate).ThenByDescending(p => p.Id);
        }

        public IEnumerable<Post> GetPublishablePostsByKind(string kind)
        {
            return _context.Posts.Where(p => p.CanBePublished == true && p.PostKind.Title == kind)
                  .Include(p => p.PostKind)
                  .Include(p => p.Artists)
                       .ThenInclude(pa => pa.ArtistType)
                           .ThenInclude(at => at.Artist)
                  .Include(p => p.Links)
                  .OrderByDescending(p => p.PublishDate).ThenByDescending(p => p.Id);
        }

        public IEnumerable<Post> GetPublishableSeries()
        {
            return _context.Posts.OfType<SeriesPost>().Where(p => p.CanBePublished == true)
                  .Include(p => p.PostKind)
                  .Include(p => p.Artists)
                       .ThenInclude(pa => pa.ArtistType)
                           .ThenInclude(at => at.Artist)
                  .Include(p => p.Links)
                  .OrderByDescending(p => p.PublishDate).ThenByDescending(p => p.Id);
        }

        public IEnumerable<Post> GetPublishableTracks()
        {
            return _context.Posts.OfType<TrackPost>().Where(p => p.CanBePublished == true)
                  .Include(p => p.PostKind)
                  .Include(p => p.Artists)
                       .ThenInclude(pa => pa.ArtistType)
                           .ThenInclude(at => at.Artist)
                  .Include(p => p.Links)
                  .OrderByDescending(p => p.PublishDate).ThenByDescending(p => p.Id);
        }

        public SeriesInfo GetSeriesInfoByPostId(int postId)
        {
            return _context.SeriesInfos.Where(t => t.PostId == postId).FirstOrDefault();
        }

        public TrackInfo GetTrackInfoByPostId(int postId)
        {
            return _context.TrackInfos.Where(t => t.PostId == postId).FirstOrDefault();
        }

        public MetaInfo GetUrlMetaInfo(string controller,string action)
        {
            return _context.MetaInfos.Where(m => string.Equals(m.ControllerName.ToUpper(),controller.ToUpper())
            && string.Equals(m.ActionName.ToUpper(), action.ToUpper())).FirstOrDefault();
        }

        public IEnumerable<Artist> SearchArtist(string searchTxt)
        {
            if(string.IsNullOrEmpty(searchTxt))
            {
                return GetArtistList();
            }
            var artists = _context.Artists
               .Where(a => a.LatinName.Contains(searchTxt) || a.Name.Contains(searchTxt))
               .Include(a => a.Types).ThenInclude(at => at.Type)
               .Include(a => a.Types).ThenInclude(at => at.Posts).ThenInclude(p => p.Post)
               .OrderBy(a => a.Name.Trim())
               .ThenBy(a => a.Id)
               .ToList();
            return artists;
        }

        public IEnumerable<Post> SearchPost(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return GetPublishablePosts();
            }
            return _context.Posts.
                 Where(p => p.CanBePublished == true && (
                 p.OpusName.Contains(search)
                 || p.OpusLatinName.Contains(search)
                 || p.Artists.Any(a => a.ArtistType.Artist.Name.Contains(search))
                 || p.Artists.Any(a => a.ArtistType.Artist.LatinName.Contains(search))))
                 .Include(p => p.Artists).ThenInclude(pa => pa.ArtistType)
                 .ThenInclude(at => at.Artist)
                 .Include(p => p.PostKind)
                 .Include(p => p.Links)
                 .OrderByDescending(p => p.PublishDate).ThenByDescending(p => p.Id); ;
        }
    }
}
