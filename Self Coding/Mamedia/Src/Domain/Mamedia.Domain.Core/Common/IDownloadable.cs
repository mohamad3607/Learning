using Mamedia.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Common
{
    public interface IDownloadable:IPostable
    {
        ICollection<DownloadLink> DownloadLinks { get; set; }
    }
}
