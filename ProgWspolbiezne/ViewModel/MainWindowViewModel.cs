namespace ProgWspolbiezne.ViewModel;

public class MainWindowViewModel : ViewModelBase
{
    public ViewModelBase CurrentViewModel { get; }

    public MainWindowViewModel()
    {
        CurrentViewModel = new CreateBallsMenuViewModel();
    }
}