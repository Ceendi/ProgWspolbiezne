using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgWspolbiezne.Model
{
    public class BallManager(ushort maxX, ushort maxY, short MaxSpeed)
    {
        readonly Random random = new();

        private readonly List<Ball> _balls = [];
        readonly ushort MaxX = maxX;
        readonly ushort MaxY = maxY;
        readonly short MaxSpeed = MaxSpeed;

        public void CreateBall()
        {
            short vx = (short)random.Next(-MaxSpeed, MaxSpeed);
            short vy = (short)random.Next(-MaxSpeed, MaxSpeed);

            int red = random.Next(0, 256);
            int green = random.Next(0, 256);
            int blue = random.Next(0, 256);
            Color color = Color.FromArgb(red, green, blue);

            ushort radius = (ushort)random.Next(5, 20);

            ushort x = (ushort)random.Next(radius, MaxX - radius);
            ushort y = (ushort)random.Next(radius, MaxY - radius);
            Ball ball = new(radius, x, y, vx, vy, color);

            while (IsColliding(ball)) 
            {
                GenerateNewRandomCoordinates(ball);
            }

            _balls.Add(ball);
        }

        public void AddBall(Ball ball)
        {
            _balls.Add(ball);
        }

        public void RemoveBall(Ball ball)
        {
            _balls.Remove(ball);
        }

        public void UpdateBalls()
        {
            for (int i = 0; i < _balls.Count; i++)
            {
                _balls[i].Move();
            }
        }

        private bool IsColliding(Ball ball1) 
        {
            //checking for collision with walls
            if ((ball1.X - ball1.Radius) <= 0 || 
                (ball1.X + ball1.Radius ) >= MaxX ||
                (ball1.Y - ball1.Radius) <= 0 ||
                (ball1.Y + ball1.Radius) >= MaxY)
            {
                return true;
            }

            //checking for collision with balls
            //TO DO

            return false;
        }

        public void CheckForCollisions()
        {
            for (int i = 0; i < _balls.Count; i++)
            {
                while (IsColliding(_balls[i]))
                {
                    //change it later to physics, now its just random
                    //TO DO
                    GenerateNewRandomCoordinates(_balls[i]);
                }
            }
        }

        private void GenerateNewRandomCoordinates(Ball ball)
        {
            ushort newX = (ushort)random.Next(ball.Radius, MaxX - ball.Radius);
            ushort newY = (ushort)random.Next(ball.Radius, MaxY - ball.Radius);
            ball.X = newX;
            ball.Y = newY;
        }
    }
}
