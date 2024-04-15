using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Ball : IBall
    {
        public int Id { get; set; }

        private double _top;
        private double _left;
        private double _speedX;
        private double _speedY;

        public Ball(double top, double left, double diameter, int id)
        {
            Random Random = new Random();
            Top = top;
            Left = left;
            Diameter = diameter;
            Id = id;
            SpeedX = Random.NextDouble() - 0.5;
            SpeedY = Random.NextDouble() - 0.5;
        }

        public double Top
        {
            get { return _top; }
            set { _top = value; }
        }
        public double Left
        {
            get { return _left; }
            set { _left = value; }
        }
        public double Diameter { get; }
        public double SpeedX
        {
            get { return _speedX; }
            set { _speedY = value; }
        }
        public double SpeedY
        {
            get { return _speedY; }
            set { _speedY = value; }
        }

        public event BallPositionChangedEventHandler? BallPositionChanged;



        public void Move()
        {
            Top += SpeedY;
            Left += SpeedX;

            BallPositionChanged?.Invoke(this, new BallPositionChangedEventArgs(Top, Left));
        }
    }
}
