using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class LoggerData
    {
        public DateTime Timestamp { get; set; }
        public List<BallJsonData> Balls { get; set; }
    }

    public class BallJsonData
    {
        public int Id { get; set; }
        public double Top { get; set; }
        public double Left { get; set; }
        public double SpeedX { get; set; }
        public double SpeedY { get; set; }
        public BallJsonData(int id, double top, double left, double speedX, double speedY)
        {
            Id = id;
            Top = top;
            Left = left;
            SpeedX = speedX;
            SpeedY = speedY;
        }
    }
}
