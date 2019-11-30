using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.UI.Models.PurchasableAlbumModel
{
    public class AllAlbumsViewModel
    {
        
            public AllAlbumsViewModel(PurchasableAlbum album)
            {
                Id = album.Id;
                Name = album.Name;

                if (album.Artists != null)
                    if (album.Artists.Count > 0)
                    {
                        var names = album.Artists.GroupBy(ta => ta.ArtistType.Artist.Name).ToList();
                        foreach (IGrouping<string, PurchasableAlbumArtists> ta in names)
                        {
                            MainArtistName += ta.Key + " و ";
                        }
                        MainArtistName = MainArtistName.Remove(MainArtistName.Length - 3, 3);
                    }
                    else
                    {
                        MainArtistName = "تعریف نشده";
                    }

            }
        [Display(Name = "شناسه آهنگ")]
        public int Id { get; set; }
        [Display(Name = "نام آهنگ")]
        public string Name { get; set; }
        [Display(Name = "هنرمندان")]
       public string MainArtistName { get; set; }
    
    }
}
