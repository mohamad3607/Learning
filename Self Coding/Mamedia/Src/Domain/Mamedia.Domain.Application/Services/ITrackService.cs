using Mamedia.Domain.Core.Entities;
using System.Collections.Generic;

namespace Mamedia.Domain.Application.Services
{
    public interface ITrackService
    {
        IEnumerable<Track> GetAllTracks();
        //Track GetTrackByUniqueId(string uniqueId);
        Track GetTrackById(int id);
        Track CreateTrack(Track Track);
        Track DeleteTrack(int id);
        IEnumerable<ArtistType> GetAllArtistTypes();
    }
}
