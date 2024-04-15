using System.Collections.Generic;

namespace Data
{
    public abstract class IDataAPI
    {
        public Board? Board { get; set; }
        public static IDataAPI CreateDataAPI()
        {
            return new DataAPI();
        }

        public abstract List<IBall> GetBalls();
        public abstract void RemoveAllBalls();
        public abstract void CreateSimulation(double Width, double Height, int BallCount);
    }
}
