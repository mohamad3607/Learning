using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Src.Domain.Core.Entities
{
    public class Admin:User
    {
        public ICollection<Post> Posts { get; set; }
    }
}
