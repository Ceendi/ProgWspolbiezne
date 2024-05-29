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

            bool isWithin;

            double Diameter;
            double Top;
            double Left;
            double Mass;

            Diameter = random.Next(25, 50);
            Mass = Math.Floor(Math.Pow(Diameter, 2)*0.1);

            Top = random.NextDouble() * (Height - Diameter);
            Left = random.NextDouble() * (Width - Diameter);
            double centreX = Left + Diameter / 2;
            double centreY = Top + Diameter / 2;
            while (true)
            {
                isWithin = false;
                foreach (IBall ballTemp in ballRepository.GetAll())
                {
                    double centreXTemp = ballTemp.Left + ballTemp.Diameter / 2;
                    double centreYTemp = ballTemp.Top + ballTemp.Diameter / 2;
                    double distance = Math.Sqrt(Math.Pow(centreX - centreXTemp, 2) + Math.Pow(centreY - centreYTemp, 2));
                    if (distance <= Diameter/2+ballTemp.Diameter/2)
                    {
                        isWithin = true;
                        break;
                    }
                }

                if (!isWithin)
                {
                    break;
                }

                Top = random.NextDouble() * (Height - Diameter);
                Left = random.NextDouble() * (Width - Diameter);
                centreX = Left + Diameter / 2;
                centreY = Top + Diameter / 2;
            }

            Ball ball = new Ball(Top, Left, Diameter, Mass,  Id);

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
