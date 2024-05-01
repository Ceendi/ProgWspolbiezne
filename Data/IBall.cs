
using System;

namespace Data
{
    public interface IBall : INotifyBallPositionChanged, IDisposable
    {
        double Top { get; set; }
        double Left { get; set; }
        double Diameter {  get; }
        double Mass {  get; }
        double SpeedX { get; set; }
        double SpeedY { get; set; }

        void Move();


    }
}
