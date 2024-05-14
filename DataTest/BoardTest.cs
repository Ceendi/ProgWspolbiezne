using Data;

namespace DataTest
{
    public class BoardTest
    {
        int ballsCount = 5;
        double width = 800;
        double height = 600;

        [Test]
        public void GenerateBallsCount()
        {
            IBoard board = new Board(width, height);
            board.GenerateBalls(ballsCount);
            List<IBall> balls = board.GetBalls();

            Assert.That(balls.Count, Is.EqualTo(ballsCount));
        }

        [Test]
        public void GenerateBallsCorrectPositions()
        {
            IBoard board = new Board(width, height);
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
            IBoard board = new Board(width, height);

            board.GenerateBalls(ballsCount);

            board.RemoveAll();
            List<IBall> balls = board.GetBalls();

            Assert.That(balls.Count, Is.EqualTo(0));
        }
    }
}
