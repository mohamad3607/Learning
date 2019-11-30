using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public abstract class Album:Audio
    {
        public string Summary { get; set; }
        
    }
}
