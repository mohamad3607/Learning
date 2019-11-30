using Mamedia.Domain.Application.Interfaces;
using Mamedia.Domain.Application.Services;
using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Application.Interactors
{
    public class ArtistInteractor:IArtistService
    {
        IArtistRepository _repository;
        public ArtistInteractor(IArtistRepository repository)
        {
            _repository = repository;
        }
        public Artist CreateArtist(Artist artist)
        {
            return _repository.CreateArtist(artist);
        }

        public Artist DeleteArtist(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Artist> GetAllArtists()
        {
            return _repository.GetAllArtists();
        }

        public IEnumerable<TypeOfArtist> GetAllTypesOfArtist()
        {
            return _repository.GetAllTypesOfArtist();
        }

        public Artist GetArtistById(int id)
        {
            return _repository.GetArtistById(id);
        }
    }
}
