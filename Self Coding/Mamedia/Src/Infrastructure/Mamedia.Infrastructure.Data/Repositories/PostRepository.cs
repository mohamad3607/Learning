using Mamedia.Domain.Application.Interfaces;
using Mamedia.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mamedia.Infrastructure.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        MamediaDataContext _context;
        public PostRepository(MamediaDataContext context)
        {
            _context = context;
        }

        public Post CreatePost(Post post)
        {
            var returnPost = _context.Posts.Add(post).Entity;
            _context.SaveChanges();
            return returnPost;

        }

        public Post DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostKind> GetAllPostKinds()
        {
            return _context.PostKinds;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts
                .Include(p=>p.PostKind)
                .OrderByDescending(p => p.PublishDate).ThenByDescending(p => p.Id);
        }

        public IEnumerable<Post> GetAllPostsWithMultiMedia()
        {
            return _context.Posts.Include(p => p.Track).OrderByDescending(p => p.PublishDate).ThenByDescending(p => p.Id); 
        }

        public Post GetPostById(int id)
        {
            
            return _context.Posts.FirstOrDefault(p => p.Id == id);
        }

        public Post GetPostByUniqueId(string uniqueId)
        {
            return _context.Posts.FirstOrDefault(p => p.UniqueId == uniqueId);
        }

        public IEnumerable<Post> GetPublishablePosts()
        {
            return _context.Posts.Where(p => p.CanBePublished == true)
                          .Include(p => p.Track)
                              .ThenInclude(t => t.TrackArtists)
                                  .ThenInclude(t=>t.ArtistType)
                                     .ThenInclude(t=>t.Artist)
                          .Include(p=>p.Track)
                              .ThenInclude(t=>t.DownloadLinks)
                          .Include(p => p.Movie)
                          .Include(p => p.PostKind)
                          .OrderByDescending(p => p.PublishDate).ThenByDescending(p => p.Id);

        }

        public IEnumerable<Track> GetTracks()
        {
            return _context.Tracks.OrderByDescending(t=>t.Id);
        }
    }
}
