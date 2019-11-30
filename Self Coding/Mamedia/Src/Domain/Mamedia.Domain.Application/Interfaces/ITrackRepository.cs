using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Application.Interfaces
{
    public interface ITrackRepository
    {
        IEnumerable<Track> GetAllTracks();
        //IEnumerable<Track> GetAllTracksWithMultiMedia();
        //Track GetTrackByUniqueId(string uniqueId);
        Track GetTrackById(int id);
        Track CreateTrack(Track track);
        Track DeleteTrack(int id);
        IEnumerable<ArtistType> GetArtistTypes();
    }
}
