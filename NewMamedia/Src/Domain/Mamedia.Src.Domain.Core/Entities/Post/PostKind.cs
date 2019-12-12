using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mamedia.Src.Domain.Core.Entities
{
    public class PostKind
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}