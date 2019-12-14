using Mamedia.Src.Domain.Application.Repositories;
using Mamedia.Src.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mamedia.Src.Infrastructure.Data.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        MamediaDataContext _context;
        public AdminRepository(MamediaDataContext context)
        {
            _context = context;
        }

        public Artist CreateArtist(Artist artist)
        {
            var addedArtist= _context.Artists.Add(artist).Entity;
            _context.SaveChanges();
            return addedArtist;
        }

        public TrackPost CreatePurchasableAlbumPost(PurchasableAlbumPost post)
        {
            throw new NotImplementedException();
        }

        public TrackPost CreateTrackPost(TrackPost post)
        {
            var addedPost = (TrackPost)_context.Posts.Add(post).Entity;
            _context.SaveChanges();
            return addedPost;
        }

        public Post DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public Artist EditArtist(Artist artist)
        {
            var result = _context.Artists.Update(artist).Entity;
            _context.SaveChanges();
            return result;
        }

        public IEnumerable<ArtistType> GetAllArtistTypes()
        {
            return _context.ArtistTypes
                .Include(at => at.Artist)
                .Include(at => at.Type)
                .OrderBy(at => at.Artist.Name);
        }

        public IEnumerable<Artist> GetAllArtitsts()
        {
            return _context.Artists.OrderBy(a=>a.Name);
        }

        public IEnumerable<PostKind> GetAllPostKinds()
        {
            return _context.PostKinds;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts
                .Include(p => p.PostKind);
        }

        public IEnumerable<TypeOfArtist> GetAllTypeOfArtists()
        {
            return _context.TypeOfArtists;
        }

        public Artist GetArtistById(int artistId)
        {
            return _context.Artists.Where(a => a.Id == artistId)
                            .Include(a => a.Types)
                            .FirstOrDefault();
        }

        public Post GetPostById(int id)
        {
            throw new NotImplementedException();
        }

        public Post GetPostByUniqueId(string uniqueId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPublishablePosts()
        {
            throw new NotImplementedException();
        }
    }
}
