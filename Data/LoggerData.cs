using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class LoggerData
    {
        public DateTime Timestamp { get; set; }
        public List<BallJsonData> Balls { get; set; }
        public LoggerData(DateTime timestamp, List<BallJsonData> balls)
        {
            Timestamp = timestamp;
            Balls = balls;
        }
    }

    public class BallJsonData
    {
        public int Id { get; set; }
        public double Top { get; set; }
        public double Left { get; set; }
        public double SpeedX { get; set; }
        public double SpeedY { get; set; }
        public BallJsonData(IBall ball)
        {
            Id = ball.Id;
            Top = ball.Top;
            Left = ball.Left;
            SpeedX = ball.SpeedX;
            SpeedY = ball.SpeedY;
        }
    }
}
