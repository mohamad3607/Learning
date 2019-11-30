using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Application.Interfaces
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> GetAllArtists();
        //IEnumerable<Artist> GetAllArtistsWithMultiMedia();
        //Artist GetArtistByUniqueId(string uniqueId);
        Artist GetArtistById(int id);
        Artist CreateArtist(Artist track);
        Artist DeleteArtist(int id);
        //IEnumerable<Artist> GetPublishableArtists();
        IEnumerable<TypeOfArtist> GetAllTypesOfArtist();
    }
}
