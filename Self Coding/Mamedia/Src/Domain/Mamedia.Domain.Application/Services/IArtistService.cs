using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Application.Services
{
    public interface IArtistService
    {
        IEnumerable<Artist> GetAllArtists();
        Artist GetArtistById(int id);
        Artist CreateArtist(Artist Artist);
        Artist DeleteArtist(int id);
        IEnumerable<TypeOfArtist> GetAllTypesOfArtist();

    }
}
