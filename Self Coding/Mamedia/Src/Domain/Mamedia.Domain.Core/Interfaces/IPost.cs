using Mamedia.Domain.Core.Common;
using System;

namespace Mamedia.Domain.Core.Entities
{
    public interface IPost:IEntity
    {
        bool AllowToPublish { get; set; }
        bool CanBePublished { get; }
        DateTime PublishDate { get; set; }
        string Title { get; set; }
    }
}