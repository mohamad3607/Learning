using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mamedia.Src.Domain.Core.Entities
{
    [Table("MetaInfos")]
    public class MetaInfo
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Url { get; set; }
        [MaxLength(200)]
        public string ActionName { get; set; }
        [MaxLength(200)]
        public string ControllerName { get; set; }
        [MaxLength(500)]
        public string MetaDescription { get; set; }
        [MaxLength(200)]
        public string H1Tag { get; set; }
        [MaxLength(400)]
        public string H2Tag { get; set; }
        [MaxLength(200)]
        public string PageTitle { get; set; }
    }

}
