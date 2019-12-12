using Mamedia.Src.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mamedia.Src.UI.Web.Models.PurchasableAlbumModel
{
    public class AllAlbumsViewModel
    {
        
            public AllAlbumsViewModel(PurchasableAlbumPost album)
            {
                Id = album.Id;
                Name = album.OpusLatinName;

             

            }
        [Display(Name = "شناسه آهنگ")]
        public int Id { get; set; }
        [Display(Name = "نام آهنگ")]
        public string Name { get; set; }
        [Display(Name = "هنرمندان")]
       public string MainArtistName { get; set; }
    
    }
}
