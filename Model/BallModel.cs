using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Model
{
    public class BallModel : IBallModel
    {
        public BallModel(double top, double left)
        {
            _top = top;
            _left = left;
            MoveTimer = new Timer(Move, null, TimeSpan.FromMilliseconds(10), TimeSpan.FromMilliseconds(10));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double Top
        {
            get { return _top; }
            set
            {
                _top = value;
                RaisePropertyChanged("Top");
            }
        }

        public double Left
        {
            get { return _left; }
            set
            {
                _left = value;
                RaisePropertyChanged("Left");
            }
        }

        public double Diameter { get; internal set; }

        private double _top;
        private double _left;
        private readonly Timer MoveTimer;
        private readonly Random Random = new Random();

        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Move(object state)
        {
            if (Top > 50 && Top < (350 - Diameter)) {
                Top += (Random.NextDouble() - 0.5) * 10;
            } 
            else
            {
                Top = 150;
            }

            if (Left > 50 && Left < (750 - Diameter))
            {
                Left += (Random.NextDouble() - 0.5) * 10;
            }
            else
            {
                Left = 350;
            }
        }
    }
}
