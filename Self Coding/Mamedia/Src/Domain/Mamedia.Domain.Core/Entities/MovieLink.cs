using Mamedia.Domain.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public class MovieLink:PurchaseLink
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
