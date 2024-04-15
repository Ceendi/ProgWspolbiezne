using System;
using System.Threading;

namespace Data
{
    public class Ball : IBall
    {
        public int Id { get; set; }

        private double _top;
        private double _left;
        private double _speedX;
        private double _speedY;
        private readonly Timer MoveTimer;

        public Ball(double top, double left, double diameter, int id)
        {
            Random Random = new Random();
            Top = top;
            Left = left;
            Diameter = diameter;
            Id = id;
            SpeedX = Random.NextDouble();
            SpeedY = Random.NextDouble();
            MoveTimer = new Timer(Move, null, TimeSpan.FromMilliseconds(10), TimeSpan.FromMilliseconds(10));
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
            set { _speedX = value; }
        }
        public double SpeedY
        {
            get { return _speedY; }
            set { _speedY = value; }
        }

        public event BallPositionChangedEventHandler? BallPositionChanged;



        public void Move(object state)
        {
            Top += SpeedY;
            Left += SpeedX;

            BallPositionChanged?.Invoke(this, new BallPositionChangedEventArgs(Top, Left));
        }
    }
}
