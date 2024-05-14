using Data;

namespace DataTest
{
    public class DataAPITest
    {
        double width = 800;
        double height = 600;
        int ballsCount = 5;
        IDataAPI dataAPI;

        [SetUp]
        public void Setup()
        {
            dataAPI = new DataAPI();
        }

        [Test]
        public void CreateSimulationCorrectCountWidthHeight()
        {
            dataAPI.CreateSimulation(width, height, ballsCount);
            List<IBall> balls = dataAPI.GetBalls();

            Assert.That(dataAPI.Board.Width, Is.EqualTo(width));
            Assert.That(dataAPI.Board.Height, Is.EqualTo(height));
            Assert.That(balls.Count, Is.EqualTo(ballsCount));
        }

        [Test]
        public void RemoveAll()
        {
            dataAPI.CreateSimulation(width, height, ballsCount);

            dataAPI.RemoveAllBalls();
            List<IBall> balls = dataAPI.GetBalls();

            Assert.That(balls.Count, Is.EqualTo(0));
        }
    }
}
