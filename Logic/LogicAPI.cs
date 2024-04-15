using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;

namespace Logic
{
    public class LogicAPI : ILogicAPI
    {
        private readonly IDataAPI? _dataAPI;

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
            foreach (Ball ball in _dataAPI.GetBalls().Cast<Ball>())
            {
                ball.BallPositionChanged += OnBallPositionChanged;
            }
            StartBallMovement();
        }

        private void StartBallMovement()
        {
            IsRunning = true;
            foreach (Ball ball in _dataAPI.GetBalls().Cast<Ball>())
            {
                while (IsRunning)
                {
                    while (true)
                    {
                        ball.Move();
                        Thread.Sleep(10);
                    }
                }
            }
        }

        public void CheckBoardCollision(Ball ball)
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
        }
    }
}
