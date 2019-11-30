using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Application.Interfaces
{
    public interface IRepositories
    {
        IPostRepository PostRepository { get; set; }
    }
}
