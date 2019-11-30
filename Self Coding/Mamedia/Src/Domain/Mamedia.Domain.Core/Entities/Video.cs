﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mamedia.Domain.Core.Entities
{
    public abstract class Video:MultiMedia
    {
        public int ProductionYear { get; set; }
        public string ProductionCountry { get; set; }
    }
}
