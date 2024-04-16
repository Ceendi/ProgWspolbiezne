using System;
using System.Collections.Generic;

namespace Data
{
    public class Board : IBoard
    {
        public double Width { get; set; }
        public double Height { get; set; }
        private IBallRepository ballRepository;

        public Board(double Width, double Height)
        {
            this.Width = Width;
            this.Height = Height;
            ballRepository = new BallRepository();
        }

        private Ball GenerateBall(int Id)
        {
            Random random = new Random();

            double Diameter;
            double Top;
            double Left;

            Diameter = random.Next(25, 50);
            Top = random.NextDouble() * (Height - Diameter);
            Left = random.NextDouble() * (Width - Diameter);

            Ball ball = new Ball(Top, Left, Diameter, Id);

            return ball;
        }

        public void GenerateBalls(int BallsCount)
        {
            ballRepository.RemoveAll();
            for (int i = 0; i < BallsCount; i++)
            {
                Ball ball = GenerateBall(i);
                ballRepository.Add(ball);
            }
        }

        public List<IBall> GetBalls() { return ballRepository.GetAll(); }
        public void RemoveAll() {  ballRepository.RemoveAll(); }
    }
}
