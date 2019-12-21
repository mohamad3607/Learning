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

        public Artist CreateArtist(Artist artist)
        {
            return _repository.CreateArtist(artist);
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

        public Artist GetArtistById(int artistId)
        {
            return _repository.GetArtistById(artistId);
        }

        public IEnumerable<ArtistType> GetAllArtistTypes()
        {
            return _repository.GetAllArtistTypes();
        }

        public IEnumerable<Artist> GetAllArtitsts()
        {
            return _repository.GetAllArtitsts();
        }

        public IEnumerable<PostKind> GetAllPostKinds()
        {
            return _repository.GetAllPostKinds();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _repository.GetAllPosts();
        }

        public IEnumerable<TypeOfArtist> GetAllTypeOfArtists()
        {
            return _repository.GetAllTypeOfArtists();
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

        public Artist EditArtist(Artist artist)
        {
            return _repository.EditArtist(artist);
        }

        public Post EditPost(Post post)
        {
            throw new NotImplementedException();
        }

       
    }
}
