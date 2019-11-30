using Mamedia.Domain.Application.Interfaces;
using Mamedia.Domain.Application.Services;
using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;

namespace Mamedia.Domain.Application.Interactors
{
    public class TrackInteractor : ITrackService
    {
        ITrackRepository _repository;
        public TrackInteractor(ITrackRepository repository)
        {
            _repository = repository;
        }
        public Track CreateTrack(Track track)
        {
            return _repository.CreateTrack(track);
        }

        public Track DeleteTrack(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ArtistType> GetAllArtistTypes()
        {
            return _repository.GetArtistTypes();
        }

        public IEnumerable<Track> GetAllTracks()
        {
            return _repository.GetAllTracks();
        }

        public Track GetTrackById(int id)
        {
            return _repository.GetTrackById(id);
        }


    }
}
