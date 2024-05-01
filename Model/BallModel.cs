using Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class BallModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly Ball ball;

        public BallModel(Ball ball)
        {
            this.ball = ball;
            ball.BallPositionChanged += OnBallPositionChanged;
        }

        public void OnBallPositionChanged(object sender, BallPositionChangedEventArgs args)
        {
            OnPropertyChanged(nameof(Top));
            OnPropertyChanged(nameof(Left));
        }

        public double Top
        {
            get { return ball.Top; }
            set
            {
                ball.Top = value;
                OnPropertyChanged();
            }
        }

        public double Left
        {
            get { return ball.Left; }
            set
            {
                ball.Left = value;
                OnPropertyChanged();
            }
        }

        public double Mass
        {
            get { return ball.Mass; }
        }
        public double Diameter
        {
            get { return ball.Diameter; }
        }
    }
}