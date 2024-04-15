using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public delegate void BallPositionChangedEventHandler(object sender, BallPositionChangedEventArgs e);
    public class BallPositionChangedEventArgs
    {
        public double Top { get; private set; }
        public double Left { get; private set; }
        public BallPositionChangedEventArgs(double top, double left)
        {
            Top = top;
            Left = left;
        }
    }
}
