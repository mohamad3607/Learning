using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Application.Services
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPosts();
        IEnumerable<Post> GetAllPostsWithMultiMedia();
        IEnumerable<Post> GetPublishablePosts();
        Post GetPostByUniqueId(string uniqueId);
        Post GetPostById(int id);
        Post CreatePost(Post post);
        Post DeletePost(int id);
        IEnumerable<PostKind> GetAllPostKinds();

        IEnumerable<Track> GetAllTracks();

    }
}
