﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface INotifyBallPositionChanged
    {
        event BallPositionChangedEventHandler BallPositionChanged;
    }
}
