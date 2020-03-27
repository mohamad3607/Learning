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

        public Artist GetArtistByName(string name)
        {
            return _repository.GetArtistByName(name);
        }

        public IEnumerable<Artist> GetArtistList()
        {
            return _repository.GetArtistList();
        }

        public IEnumerable<Artist> GetArtistListByType(string type)
        {
            return _repository.GetArtistListByType(type);
        }

        public MovieInfo GetMovieInfoByPostId(int postId)
        {
            return _repository.GetMovieInfoByPostId(postId);
        }

        public PurchasableAlbumInfo GetPAlbumInfoByPostId(int postId)
        {
            return _repository.GetPAlbumInfoByPostId(postId);
        }

        public Post GetPostByUniqueId(string uniqueId)
        {
            return _repository.GetPostByUniqueId(uniqueId);
        }

        public IEnumerable<Post> GetPublishableAlbums()
        {
            return _repository.GetPublishableAlbums();
        }

        public IEnumerable<Post> GetPublishableMovies()
        {
            return _repository.GetPublishableMovies();
        }

        public IEnumerable<Post> GetPublishablePosts()
        {
            return _repository.GetPublishablePosts();
        }

        public IEnumerable<Post> GetPublishablePostsByKind(string kind)
        {
            return _repository.GetPublishablePostsByKind(kind);
        }

        public IEnumerable<Post> GetPublishableSeries()
        {
            return _repository.GetPublishableSeries();
        }

        public IEnumerable<Post> GetPublishableTracks()
        {
            return _repository.GetPublishableTracks();
        }

        public SeriesInfo GetSeriesInfoByPostId(int postId)
        {
            return _repository.GetSeriesInfoByPostId(postId);
        }

        public TrackInfo GetTrackInfoByPostId(int postId)
        {
            return _repository.GetTrackInfoByPostId(postId);
        }

        public MetaInfo GetUrlMetaInfo(string controller,string action)
        {
            return _repository.GetUrlMetaInfo(controller,action);
        }

        public IEnumerable<Artist> SearchArtist(string searchTxt)
        {
            return _repository.SearchArtist(searchTxt);
        }

        public IEnumerable<Post> SearchPost(string search)
        {
            return _repository.SearchPost(search);
        }
    }
}
