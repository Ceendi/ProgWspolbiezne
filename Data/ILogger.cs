﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface ILogger
    {
        Task Log(string message);
    }
}
