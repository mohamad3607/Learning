using Mamedia.Src.Domain.Application.Repositories;
using Mamedia.Src.Domain.Application.Services;
using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Src.Domain.Application.Interactors
{
    public class AnonymouseInteractor : IAnonymouseService
    {
        IAnonymouseRepository _repository;
        public AnonymouseInteractor(IAnonymouseRepository repository)
        {
            _repository = repository;
        }
        public IEnumerable<PostKind> GetAllPostKinds()
        {
            throw new NotImplementedException();
        }

        public Post GetPostByUniqueId(string uniqueId)
        {
            return _repository.GetPostByUniqueId(uniqueId);
        }

        public IEnumerable<Post> GetPublishableAlbums()
        {
            return _repository.GetPublishableAlbums();
        }

        public IEnumerable<Post> GetPublishablePosts()
        {
            return _repository.GetPublishablePosts();
        }

        public IEnumerable<Post> GetPublishablePostsByKind(string kind)
        {
            return _repository.GetPublishablePostsByKind(kind);
        }

        public IEnumerable<Post> GetPublishableTracks()
        {
            return _repository.GetPublishableTracks();
        }

        public TrackInfo GetTrackInfoByPostId(int postId)
        {
            return _repository.GetTrackInfoByPostId(postId);
        }
        public IEnumerable<Post> SearchPost(string search)
        {
            return _repository.SearchPost(search);
        }
    }
}
