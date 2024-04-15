using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public abstract class ILogicAPI
    {
        public bool IsRunning { get; protected set; }

        public static ILogicAPI CreateAPI()
        {
            return new LogicAPI();
        }

        public abstract void StartSimulation(double Height, double Width, int numberOfBalls);
        public abstract void StopSimulation();
        public abstract List<IBall> GetBalls();
        public abstract void SetHeight(double Height);
        public abstract void SetWidth(double Width);
    }
}
