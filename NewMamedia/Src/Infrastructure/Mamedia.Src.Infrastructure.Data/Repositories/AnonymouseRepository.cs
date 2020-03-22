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
                .Where(a => a.LatinName==name || a.Name==name)
                .Include(a => a.Types).ThenInclude(at => at.Type)
                .Include(a=>a.Types).ThenInclude(at=>at.Posts).ThenInclude(p=>p.Post)
                .OrderBy(a => a.Name.Trim())
                .ThenBy(a => a.Id)
                .FirstOrDefault();
            return artists;
        }

        public IEnumerable<Artist> GetArtistList()
        {
            var artists = _context.Artists.Include(a => a.Types).ThenInclude(at => at.Type)
                .OrderBy(a=>a.Name.Trim())
                .ThenBy(a=>a.Id);
            return artists;            
        }

        public IEnumerable<Artist> GetArtistListByType(string type)
        {
            var artists = _context.Artists
                .Where(a=>a.Types.Any(at => at.Type.Type == type))
                .Include(a => a.Types)
                .ThenInclude(at => at.Type)
                .OrderBy(a => a.Name.Trim())
                .ThenBy(a => a.Id);
            return artists;
        }

        public PurchasableAlbumInfo GetPAlbumInfoByPostId(int postId)
        {
            return _context.PurchasableAlbumInfos.Where(t => t.PostId == postId).FirstOrDefault();
        }

        public Post GetPostByUniqueId(string uniqueId)
        {
            return _context.Posts.Where(p => p.UniqueId == uniqueId)
               .Include(p => p.PostKind)
                   .Include(p => p.Artists)
                        .ThenInclude(pa => pa.ArtistType)
                            .ThenInclude(at => at.Artist)
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
            return _context.Posts.Where(p => p.CanBePublished == true && p.PostKind.Title==kind)
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

        public TrackInfo GetTrackInfoByPostId(int postId)
        {
            return _context.TrackInfos.Where(t => t.PostId == postId).FirstOrDefault();
        }
        public IEnumerable<Post> SearchPost(string search)
        {
            return _context.Posts.
                 Where(p => p.OpusName.Contains(search)
                 || p.OpusLatinName.Contains(search))
                 .Include(p => p.Artists.Where(a => a.ArtistType.Artist.Name.Contains(search)))
                      .ThenInclude(pa => pa.ArtistType)
                             .ThenInclude(at => at.Artist);
        }
    }
}
