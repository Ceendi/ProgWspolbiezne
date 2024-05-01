using Data;
using System;
using System.Collections.Generic;
using System.Linq;

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
                
                // Obliczanie odległości między środkami kul
                double dx = ballTemp.Left + ballTemp.Diameter / 2 - (ball.Left + ball.Diameter / 2);
                double dy = ballTemp.Top + ballTemp.Diameter / 2 - (ball.Top + ball.Diameter / 2);
                double distance = Math.Sqrt(dx * dx + dy * dy);

                // Sprawdź kolizję
                if (distance < ball.Diameter / 2 + ballTemp.Diameter / 2)
                {
                    // Oblicz kąt uderzenia
                    double angle = Math.Atan2(dy, dx);

                    // Oblicz prędkości wzdłuż i prostopadle do osi uderzenia
                    double v1x = ball.SpeedX * Math.Cos(angle) + ball.SpeedY * Math.Sin(angle);
                    double v1y = ball.SpeedY * Math.Cos(angle) - ball.SpeedX * Math.Sin(angle);
                    double v2x = ballTemp.SpeedX * Math.Cos(angle) + ballTemp.SpeedY * Math.Sin(angle);
                    double v2y = ballTemp.SpeedY * Math.Cos(angle) - ballTemp.SpeedX * Math.Sin(angle);

                    // Oblicz nowe prędkości po zderzeniu zgodnie z zachowaniem pędu
                    double newV1x = ((ball.Mass - ballTemp.Mass) * v1x + 2 * ballTemp.Mass * v2x) / (ball.Mass + ballTemp.Mass);
                    double newV2x = ((ballTemp.Mass - ball.Mass) * v2x + 2 * ball.Mass * v1x) / (ball.Mass + ballTemp.Mass);

                    // Przekształć prędkości z powrotem do układu współrzędnych
                    double finalV1x = newV1x * Math.Cos(angle) - v1y * Math.Sin(angle);
                    double finalV1y = v1y * Math.Cos(angle) + newV1x * Math.Sin(angle);
                    double finalV2x = newV2x * Math.Cos(angle) - v2y * Math.Sin(angle);
                    double finalV2y = v2y * Math.Cos(angle) + newV2x * Math.Sin(angle);

                    if ((finalV1x - ball.SpeedX) * (ballTemp.Left - ball.Left) + (finalV1y - ball.SpeedY) * (ballTemp.Top - ball.Top) < 0 &&
                        (finalV2x - ballTemp.SpeedX) * (ball.Left - ballTemp.Left) + (finalV2y - ballTemp.SpeedY) * (ball.Top - ballTemp.Top) < 0)
                    {
                        ball.SpeedX = finalV1x;
                        ball.SpeedY = finalV1y;
                        ballTemp.SpeedX = finalV2x;
                        ballTemp.SpeedY = finalV2y;
                    }
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
