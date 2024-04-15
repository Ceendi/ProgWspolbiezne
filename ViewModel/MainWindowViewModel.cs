using Model;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ModelAPI ModelLayer;

        private ObservableCollection<BallModel> _balls;
        private int _ballsCount;
        private double _height;
        private double _width;

        public ObservableCollection<BallModel> Balls
        {
            get => _balls;
            set
            {
                _balls = value;
                OnPropertyChanged();
            }
        }

        public int BallsCount
        {
            get => _ballsCount;
            set
            {
                _ballsCount = value;
                OnPropertyChanged();
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                OnPropertyChanged();
            }
        }

        public double Width
        {
            get => _width;
            set
            {
                _width = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            _ballsCount = 5;
            ModelLayer = new ModelAPI();
            _balls = new ObservableCollection<BallModel>();

            ModelLayer.Stop();
            ModelLayer.Start(300, 700, 5);
            Balls = ModelLayer.GetBalls();
        }
    }
}
