using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class PostKind
    {
        public int Id { get; set; }
        public string Kind { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
