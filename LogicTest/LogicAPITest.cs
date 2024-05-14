using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using Data;

namespace Logic.Tests
{
    [TestFixture]
    public class LogicAPITests
    {
        [Test]
        public void StartSimulation()
        {
            double width = 100;
            double height = 100;
            int ballsCount = 5;

            var mockDataAPI = new Mock<IDataAPI>();

            mockDataAPI.Setup(api => api.CreateSimulation(width, height, ballsCount));
            mockDataAPI.Setup(api => api.GetBalls()).Returns(new List<IBall>());

            var mockBoard = new Mock<IBoard>();
            mockBoard.SetupGet(b => b.Width).Returns(width);
            mockBoard.SetupGet(b => b.Height).Returns(height);

            var logicAPI = new LogicAPI(mockDataAPI.Object);

            logicAPI.StartSimulation(height, width, ballsCount);

            mockDataAPI.Verify(api => api.CreateSimulation(width, height, ballsCount), Times.Once);
        }

        [Test]
        public void StopSimulation()
        {
            var mockDataAPI = new Mock<IDataAPI>();

            mockDataAPI.Setup(api => api.RemoveAllBalls());

            var logicAPI = new LogicAPI(mockDataAPI.Object);

            logicAPI.StopSimulation();

            mockDataAPI.Verify(api => api.RemoveAllBalls(), Times.Once);
        }

        [Test]
        public void CheckBoardCollision()
        {
            double boardWidth = 100;
            double boardHeight = 100;
            var mockDataAPI = new Mock<IDataAPI>();

            var mockBoard = new Mock<IBoard>();
            mockBoard.SetupGet(b => b.Width).Returns(boardWidth);
            mockBoard.SetupGet(b => b.Height).Returns(boardHeight);

            mockDataAPI.Setup(api => api.Board).Returns(mockBoard.Object);

            var logicAPI = new LogicAPI(mockDataAPI.Object);

            Ball ball = new Ball(0, 0, 20, 1, 1) { SpeedX = -5, SpeedY = -5 };

            logicAPI.CheckBoardCollision(ball);

            Assert.AreEqual(5, ball.SpeedX);
            Assert.AreEqual(5, ball.SpeedY);
        }

        [Test]
        public void CheckBallCollision_BallsCollide_VelocitiesUpdated()
        {
            // Arrange
            Mock<IBall> ballMock = new Mock<IBall>();
            Mock<IBall> ballTempMock = new Mock<IBall>();

            ballMock.SetupGet(b => b.Left).Returns(0);  // Ustawienie pozycji kulki 1
            ballMock.SetupGet(b => b.Top).Returns(0);
            ballMock.SetupGet(b => b.Diameter).Returns(10);
            ballMock.SetupGet(b => b.Mass).Returns(1);
            ballMock.SetupGet(b => b.SpeedX).Returns(2);
            ballMock.SetupGet(b => b.SpeedY).Returns(1);

            ballTempMock.SetupGet(b => b.Left).Returns(5);  // Ustawienie pozycji kulki 2 tak, aby siê zderza³y
            ballTempMock.SetupGet(b => b.Top).Returns(0);
            ballTempMock.SetupGet(b => b.Diameter).Returns(10);
            ballTempMock.SetupGet(b => b.Mass).Returns(1);
            ballTempMock.SetupGet(b => b.SpeedX).Returns(-2);
            ballTempMock.SetupGet(b => b.SpeedY).Returns(1);

            ballMock.SetupSet(b => b.SpeedX = It.IsAny<double>()).Verifiable();
            ballMock.SetupSet(b => b.SpeedY = It.IsAny<double>()).Verifiable();
            ballTempMock.SetupSet(b => b.SpeedX = It.IsAny<double>()).Verifiable();
            ballTempMock.SetupSet(b => b.SpeedY = It.IsAny<double>()).Verifiable();

            Mock<IDataAPI> dataAPIMock = new Mock<IDataAPI>();
            List<IBall> balls = new List<IBall>
            {
                ballMock.Object,
                ballTempMock.Object
            };
            dataAPIMock.Setup(api => api.GetBalls()).Returns(balls);

            LogicAPI collisionHandler = new LogicAPI(dataAPIMock.Object);

            collisionHandler.CheckBallCollision(ballTempMock.Object);

            double expectedFinalV1X = -2;
            double expectedFinalV1Y = 1;
            double expectedFinalV2X = 2;
            double expectedFinalV2Y = 1;
            double delta = 0.00001;

            ballMock.VerifySet(b => b.SpeedX = It.Is<double>(speed => speed <= -1 && speed >= -3), Times.AtLeastOnce());
            ballMock.VerifySet(b => b.SpeedY = It.Is<double>(speed => speed >= 0 && speed <= 2), Times.AtLeastOnce());
            ballTempMock.VerifySet(b => b.SpeedX = It.Is<double>(speed => speed >= 1 && speed <= 3), Times.AtLeastOnce());
            ballTempMock.VerifySet(b => b.SpeedY = It.Is<double>(speed => speed >= 0 && speed <= 2), Times.AtLeastOnce());
        }
    }
}