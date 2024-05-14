using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logic
{
    public class LogicAPI : ILogicAPI
    {
        private readonly IDataAPI? _dataAPI;
        private object lockObject = new object();
        List<Tuple<IBall, IBall>> collidingPairs = new List<Tuple<IBall, IBall>>();


        public LogicAPI(IDataAPI? dataAPI = null)
        {
            if (dataAPI == null)
            {
                this._dataAPI = IDataAPI.CreateDataAPI();
            }
            else
            {
                this._dataAPI = dataAPI;
            }
        }

        public override List<IBall> GetBalls()
        {
            return _dataAPI.GetBalls();
        }

        public override void SetHeight(double height)
        {
            _dataAPI.Board.Width = height;
        }

        public override void SetWidth(double width)
        {
            _dataAPI.Board.Width = width;
        }

        public override void StartSimulation(double Height, double Width, int numberOfBalls)
        {
            _dataAPI.CreateSimulation(Width, Height, numberOfBalls);
            IsRunning = true;
            foreach (Ball ball in _dataAPI.GetBalls().Cast<Ball>())
            {
                ball.BallPositionChanged += OnBallPositionChanged;
                Task.Run(async () =>
                    {
                        while (IsRunning)
                        {
                            await Task.Delay(TimeSpan.FromMilliseconds(10));
                            ball.Move();
                        }
                    }
                );
            }
        }

        public void CheckBoardCollision(IBall ball)
        {
            if (ball.Top + ball.SpeedY <= 0)
            {
                ball.Top = 0;
                ball.SpeedY *= -1;
            }
            else if (ball.Top + ball.SpeedY + ball.Diameter >= _dataAPI.Board.Height)
            {
                ball.Top = _dataAPI.Board.Height - ball.Diameter;
                ball.SpeedY *= -1;
            }
            if (ball.Left + ball.SpeedX <= 0)
            {
                ball.Left = 0;
                ball.SpeedX *= -1;
            } else if (ball.Left + ball.SpeedX + ball.Diameter >= _dataAPI.Board.Width)
            {
                ball.Left = _dataAPI.Board.Width - ball.Diameter;
                ball.SpeedX *= -1;
            }
        }

        public void CheckBallCollision(IBall ball)
        {
            foreach (IBall ballTemp in _dataAPI.GetBalls().Where(x => !x.Equals(ball)).ToList())
            {
                Tuple<IBall, IBall> collision = new Tuple<IBall, IBall>(ball, ballTemp);
                bool isColliding = collidingPairs.Contains(collision, new TupleComparer<IBall, IBall>());

                double dx = ballTemp.Left + ballTemp.Diameter / 2 - (ball.Left + ball.Diameter / 2);
                double dy = ballTemp.Top + ballTemp.Diameter / 2 - (ball.Top + ball.Diameter / 2);
                double distance = Math.Sqrt(dx * dx + dy * dy);

                if (distance <= ball.Diameter / 2 + ballTemp.Diameter / 2 && !isColliding)
                {
                    collidingPairs.Add(collision);

                    double angle = Math.Atan2(dy, dx);

                    double v1x = ball.SpeedX * Math.Cos(angle) + ball.SpeedY * Math.Sin(angle);
                    double v1y = ball.SpeedY * Math.Cos(angle) - ball.SpeedX * Math.Sin(angle);
                    double v2x = ballTemp.SpeedX * Math.Cos(angle) + ballTemp.SpeedY * Math.Sin(angle);
                    double v2y = ballTemp.SpeedY * Math.Cos(angle) - ballTemp.SpeedX * Math.Sin(angle);

                    double newV1x = ((ball.Mass - ballTemp.Mass) * v1x + 2 * ballTemp.Mass * v2x) / (ball.Mass + ballTemp.Mass);
                    double newV2x = ((ballTemp.Mass - ball.Mass) * v2x + 2 * ball.Mass * v1x) / (ball.Mass + ballTemp.Mass);

                    double finalV1x = newV1x * Math.Cos(angle) - v1y * Math.Sin(angle);
                    double finalV1y = v1y * Math.Cos(angle) + newV1x * Math.Sin(angle);
                    double finalV2x = newV2x * Math.Cos(angle) - v2y * Math.Sin(angle);
                    double finalV2y = v2y * Math.Cos(angle) + newV2x * Math.Sin(angle);
                    
                    ball.SpeedX = finalV1x;
                    ball.SpeedY = finalV1y;
                    ballTemp.SpeedX = finalV2x;
                    ballTemp.SpeedY = finalV2y;
                } 
                else if (distance > (ball.Diameter / 2 + ballTemp.Diameter / 2) && isColliding)
                {
                    collidingPairs.Remove(collision);
                }
            }
        }

        public override void StopSimulation()
        {
            StopMovement();
            _dataAPI.RemoveAllBalls();
        }

        private void StopMovement()
        {
            IsRunning = false;
        }

        private void OnBallPositionChanged(object sender, BallPositionChangedEventArgs args)
        {
            Ball ball = (Ball)sender;
            CheckBoardCollision(ball);
            CheckBallCollision(ball);
        }
    }
}

public class TupleComparer<T1, T2> : IEqualityComparer<Tuple<T1, T2>>
{
    public bool Equals(Tuple<T1, T2> x, Tuple<T1, T2> y)
    {
        return (x.Item1.Equals(y.Item1) && x.Item2.Equals(y.Item2)) || (x.Item1.Equals(y.Item2) && x.Item2.Equals(y.Item1));
    }

    public int GetHashCode(Tuple<T1, T2> obj)
    {
        return obj.Item1.GetHashCode() ^ obj.Item2.GetHashCode();
    }
}