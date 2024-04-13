using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public interface IBallLogic
    {
        void CreateRandomBalls(int numberOfBalls);
        void MoveBalls();
        List<Ball> GetAllBalls();
    }
}
