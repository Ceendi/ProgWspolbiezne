using System.Drawing;

namespace ProgWspolbiezne.ViewModel;

public class BallViewModel : ViewModelBase
{
    public ushort radius { get; }
    public ushort x { get; }
    public ushort y { get; }
    public short Vx { get; }
    public short Vy { get; }
    public Color Color { get; }
}