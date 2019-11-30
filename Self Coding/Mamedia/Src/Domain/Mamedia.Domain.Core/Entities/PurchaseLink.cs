using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public abstract class PurchaseLink : Link
    {
        public int Price { get; set; }
    }
}
