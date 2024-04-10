using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProgWspolbiezne.ViewModel
{
    internal class CreateBallsMenuViewModel : ViewModelBase
    {
        private int _ballCount;

        public int BallCount
        {
            get
            {
                return _ballCount;
            }
            set
            {
                _ballCount = value;
                OnPropertyChanged(nameof(BallCount));
            }
        }

        public ICommand StartCommand { get;  }  
        public ICommand ExitCommand { get;  }

        public CreateBallsMenuViewModel()
        {

        }
    }
}
