using Mamedia.Domain.Core.Common;
using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public abstract class MultiMedia : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }

    }
}
