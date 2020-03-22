using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.Src.UI.Web.Models.ArtistModel
{
    public class ArtistsListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LatinName { get; set; }
        public string Image { get; set; }
        public List<string> Types { get; set; }

        public ArtistsListViewModel(Artist artist)
        {
            Id = artist.Id;
            Name = artist.Name;
            LatinName = artist.LatinName;
            Image = artist.Image;
            Types = new List<string>();
            foreach(ArtistType type in artist.Types)
            {
                Types.Add(type.Type.Type);
            }
        }
    }
}
