using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Common
{
    public interface IPostable
    {
        string CoverPhotoAddress { get; set; }
        string CoverPhotoAlterText { get; set; }
    }
}
