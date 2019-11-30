using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Application.Interfaces
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllPosts();
        IEnumerable<Post> GetAllPostsWithMultiMedia();

        Post GetPostByUniqueId(string uniqueId);
        Post GetPostById(int id);
        Post CreatePost(Post post);
        Post DeletePost(int id);
        IEnumerable<Post> GetPublishablePosts();
        IEnumerable<PostKind> GetAllPostKinds();
        IEnumerable<Track> GetTracks();
    }
}
