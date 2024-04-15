using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IBall : INotifyBallPositionChanged
    {
        double Top { get; set; }
        double Left { get; set; }
        double Diameter {  get; }
        double SpeedX { get; set; }
        double SpeedY { get; set; }

        void Move();
    }
}
