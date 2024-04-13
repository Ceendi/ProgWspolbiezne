using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class BallData : IBallData
    {
        private List<Ball> balls;

        public BallData()
        {
            balls = new List<Ball>();
        }

        public List<Ball> GetAllBalls()
        {
            return balls;
        }

        public void AddBall(Ball ball)
        {
            balls.Add(ball);
        }
    }
}
