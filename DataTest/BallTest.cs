using Data;

namespace DataTest
{
    public class BallTest
    {
        IBall ball;

        [SetUp]
        public void Setup()
        {
            double Top = 10;
            double Left = 10;
            double Diameter = 20;
            int Id = 1;
            ball = new Ball(Top, Left, Diameter, Id);
        }

        [Test]
        public void MoveTest()
        {
            double oldTop = ball.Top;
            double oldLeft = ball.Left;
            double oldSpeedX = ball.SpeedX;
            double oldSpeedY = ball.SpeedY;
            ball.Move(null);
            Assert.That(ball.Left, Is.EqualTo(oldLeft + oldSpeedX));
            Assert.That(ball.Top, Is.EqualTo(oldTop + oldSpeedY));
        }

        [Test]
        public void NonZeroSpeedCreation()
        {
            double Top = 10;
            double Left = 10;
            double Diameter = 20;
            int Id = 1;
            IBall ball = new Ball(Top, Left, Diameter, Id);
            Assert.NotZero(ball.SpeedX);
            Assert.NotZero(ball.SpeedY);
        }
    }
}