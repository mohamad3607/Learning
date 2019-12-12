namespace Mamedia.Src.Domain.Core.Entities
{
    public class PurchasableAlbumInfo
    {
        public int PostId { get; set; }
        public PurchasableAlbumPost Post { get; set; }
        public string Summary { get; set; }
        public int Price { get; set; }
    }
}