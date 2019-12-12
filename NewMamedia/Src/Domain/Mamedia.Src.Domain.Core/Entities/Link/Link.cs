using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mamedia.Src.Domain.Core.Entities
{
    public class Link
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Tilte { get; set; }
        [MaxLength(500)]
        public string UrlForLink { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
       
    }
}
