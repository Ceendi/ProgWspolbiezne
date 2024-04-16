using Data;

namespace DataTest
{
    public class BallRepositoryTest
    {
        IBallRepository repository;

        [SetUp]
        public void SetUp()
        {
            repository = new BallRepository();
        }

        [Test]
        public void AddBall()
        {
            Ball ball = new(4, 5, 6, 1);

            repository.Add(ball);
            Assert.Contains(ball, repository.GetAll());
        }

        [Test]
        public void RemoveBall()
        {
            Ball ball = new(4, 5, 6, 1);

            repository.Add(ball);

            repository.Remove(ball);
            Assert.IsFalse(repository.GetAll().Contains(ball));
        }

        [Test]
        public void GetAll()
        {
            Ball ball1 = new(4, 5, 6, 1);
            Ball ball2 = new(6, 1, 8, 2);

            repository.Add(ball1);
            repository.Add(ball2);

            Assert.That(repository.GetAll().Count, Is.EqualTo(2));
            Assert.Contains(ball1, repository.GetAll());
            Assert.Contains(ball2, repository.GetAll());
        }

        [Test]
        public void RemoveAll()
        {
            Ball ball1 = new(4, 5, 6, 1);
            Ball ball2 = new(6, 1, 8, 2);

            repository.Add(ball1);
            repository.Add(ball2);

            repository.RemoveAll();

            Assert.That(repository.GetAll().Count, Is.EqualTo(0));
        }
    }
}
