using Data;
using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ModelAbstractApi ModelLayer;
        public ICommand CreateRandomBallsCommand { get; private set; }
        public ObservableCollection<IBallModel> Balls { get; } = new ObservableCollection<IBallModel>();

        public MainWindowViewModel()
        {
            ModelLayer = ModelAbstractApi.CreateApi();
            IDisposable observer = ModelLayer.Subscribe(x => Balls.Add(x));
            ModelLayer.Start();
        }
    }
}
