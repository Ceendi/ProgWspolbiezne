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

            Ball ball = new Ball(0, 0, 20, 1) { SpeedX = -5, SpeedY = -5 };

            logicAPI.CheckBoardCollision(ball);

            Assert.AreEqual(5, ball.SpeedX);
            Assert.AreEqual(5, ball.SpeedY);
        }
    }
}