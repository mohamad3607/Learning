using Mamedia.Domain.Core.Common;
using Mamedia.Domain.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{

    public abstract class Link:IEntity
    {
        public int Id { get; set; }
        public string Tilte { get; set; }
        public string UrlForLink { get; set; }
        
    }
}
