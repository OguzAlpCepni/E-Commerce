﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    // temel voidler icin 
    public interface IResults
    {
        bool Success { get; }
        string Message { get; }
    }
}
