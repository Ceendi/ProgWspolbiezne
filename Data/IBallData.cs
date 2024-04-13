using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IBallData
    {
        List<Ball> GetAllBalls();
        void AddBall(Ball ball);
    }
}
