using System.Collections.Generic;

namespace Data
{
    public class DataAPI : IDataAPI
    {
        public DataAPI()
        {
            Board = new Board(0, 0);
        }

        public override void CreateSimulation(double Width, double Height, int BallCount)
        {
            Board = new Board(Width, Height);
            Board.GenerateBalls(BallCount);
        }

        public override List<IBall> GetBalls()
        {
            return Board.GetBalls();
        }

        public override void RemoveAllBalls()
        {
            Board.RemoveAll();
        }
    }
}
