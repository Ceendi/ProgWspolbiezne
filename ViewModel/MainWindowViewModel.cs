using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

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
            _ballsCount = 10;
            ModelLayer = new ModelAPI();
            _balls = new ObservableCollection<BallModel>();
            _width = 1000;
            _height = 500;

            StartCommand = new RelayCommand(Start);
            StopCommand = new RelayCommand(Stop);
        }

        private void Start()
        {
            ModelLayer.Stop();
            ModelLayer.Start(_height, _width, _ballsCount);
            Balls = ModelLayer.GetBalls();
        }

        private void Stop()
        {
            ModelLayer.Stop();
            Balls = ModelLayer.GetBalls();
        }

        public ICommand StartCommand { get;}
        public ICommand StopCommand { get; }
    }
}
