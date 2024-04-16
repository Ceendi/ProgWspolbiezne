using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IBoard
    {
        double Width { get; set; }
        double Height { get; set; }
        void GenerateBalls(int BallsCount);
        List<IBall> GetBalls();
        void RemoveAll();
    }
}
