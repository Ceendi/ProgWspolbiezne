using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Timers;

namespace Data
{
    public class DataAPI : IDataAPI
    {
        private ILogger logger;
        private Timer timer;

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

        public override void EnableLogging(ILogger logger)
        {
            this.logger = logger;
            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            List<BallJsonData> balls = Board.GetBalls().Select(ball => new BallJsonData(ball)).ToList();
            logger.LogData(new LoggerData(DateTime.Now, balls));
        }

        public override void StopLogging()
        {
            if (timer != null)
            {
                timer.Stop();
            }
        }
    }
}
