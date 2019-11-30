using Mamedia.Domain.Application.Interfaces;
using Mamedia.Domain.Application.Services;
using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Application.Interactors
{
    public class PostInteractor:IPostService
    {
        IPostRepository _repository;
        public PostInteractor(IPostRepository repository)
        {
            _repository = repository;
        }

        public Post CreatePost(Post post)
        {
           return _repository.CreatePost(post);
        }

        public Post DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostKind> GetAllPostKinds()
        {
            return _repository.GetAllPostKinds();
        }

        public IEnumerable<Post> GetAllPosts()
        {
           return _repository.GetAllPosts();
        }

        public IEnumerable<Post> GetAllPostsWithMultiMedia()
        {
            return _repository.GetAllPostsWithMultiMedia();
        }

        public IEnumerable<Track> GetAllTracks()
        {
            return _repository.GetTracks();
        }

        public Post GetPostById(int id)
        {
            return _repository.GetPostById(id);
        }

        public Post GetPostByUniqueId(string uniqueId)
        {
            return _repository.GetPostByUniqueId(uniqueId);
        }

        public IEnumerable<Post> GetPublishablePosts()
        {
            List<Post> publishedPostWithProperMultiMedia = new List<Post>();
            var list= _repository.GetPublishablePosts();
            foreach(Post post in list)
            {
               
            }

            return list;
        }

    }
}
