using Data;

namespace DataTest
{
    public class BoardTest
    {
        IBoard board;
        int ballsCount = 5;
        double width = 100;
        double height = 100;

        [SetUp]
        public void Setup()
        {
            board = new Board(width, height);
        }

        [Test]
        public void GenerateBallsCount()
        {
            board.GenerateBalls(ballsCount);
            List<IBall> balls = board.GetBalls();

            Assert.That(balls.Count, Is.EqualTo(ballsCount));
        }

        [Test]
        public void GenerateBallsCorrectPositions()
        {
            board.GenerateBalls(ballsCount);
            List<IBall> balls = board.GetBalls();

            foreach (var ball in balls)
            {
                Assert.IsTrue(ball.Diameter >= 25 && ball.Diameter <= 50);
                Assert.IsTrue(ball.Top >= 0 && ball.Top <= height - ball.Diameter);
                Assert.IsTrue(ball.Left >= 0 && ball.Left <= width - ball.Diameter);
            }
        }

        [Test]
        public void RemoveAll()
        {
            board.GenerateBalls(ballsCount);

            board.RemoveAll();
            List<IBall> balls = board.GetBalls();

            Assert.That(balls.Count, Is.EqualTo(0));
        }
    }
}
