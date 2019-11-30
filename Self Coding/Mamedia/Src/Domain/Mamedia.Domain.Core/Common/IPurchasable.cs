using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Common
{
    public interface IPurchasable:IPostable
    {
        ICollection<IPurchaseLink> PurchaseLinks { get; }
    }
}
