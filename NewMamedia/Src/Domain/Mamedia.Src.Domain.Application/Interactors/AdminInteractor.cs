using Mamedia.Src.Domain.Application.Repositories;
using Mamedia.Src.Domain.Application.Services;
using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Src.Domain.Application.Interactors
{
    public class AdminInteractor : IAdminService
    {
        IAdminRepository _repository;
        public AdminInteractor(IAdminRepository repository)
        {
            _repository = repository;
        }
        public TrackPost CreatePurchasableAlbumPost(PurchasableAlbumPost post)
        {
            throw new NotImplementedException();
        }

        public TrackPost CreateTrackPost(TrackPost post)
        {
            return _repository.CreateTrackPost(post);
        }

        public Post DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArtistType> GetAllArtistTypes()
        {
            return _repository.GetAllArtistTypes();
        }

        public IEnumerable<PostKind> GetAllPostKinds()
        {
            return _repository.GetAllPostKinds();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _repository.GetAllPosts();
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
