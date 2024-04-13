using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class BallLogic : IBallLogic
    {
        private readonly IBallData ballData;

        public BallLogic(IBallData ballData)
        {
            this.ballData = ballData;
        }

        public void CreateRandomBalls(int numberOfBalls)
        {
            Random random = new Random();
            for(int i = 0; i < numberOfBalls; i++)
            {
                Ball ball = new Ball
                {
                    Id = i,
                    X = random.NextDouble() * 680,
                    Y = random.NextDouble() * 280,
                    Radius = 20
                };
                ballData.AddBall(ball);
            }
        }

        public List<Ball> GetAllBalls()
        {
            return ballData.GetAllBalls();
        }

        public void MoveBalls()
        {
            List<Ball> balls = ballData.GetAllBalls();
            foreach (var ball in balls)
            {
                double newX = ball.X + 10;
                double newY = ball.Y + 10;

                ball.X = newX; 
                ball.Y = newY;
            }
        }
    }
}
