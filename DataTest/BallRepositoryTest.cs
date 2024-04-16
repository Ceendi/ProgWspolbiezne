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
            IBall ball = new Ball(4, 5, 6, 1);

            repository.Add(ball);
            Assert.Contains(ball, repository.GetAll());
        }

        [Test]
        public void RemoveBall()
        {
            IBall ball = new Ball(4, 5, 6, 1);

            repository.Add(ball);

            repository.Remove(ball);
            Assert.IsFalse(repository.GetAll().Contains(ball));
        }

        [Test]
        public void GetAll()
        {
            IBall ball1 = new Ball(4, 5, 6, 1);
            IBall ball2 = new Ball(6, 1, 8, 2);

            repository.Add(ball1);
            repository.Add(ball2);

            Assert.That(repository.GetAll().Count, Is.EqualTo(2));
            Assert.Contains(ball1, repository.GetAll());
            Assert.Contains(ball2, repository.GetAll());
        }

        [Test]
        public void RemoveAll()
        {
            IBall ball1 = new Ball(4, 5, 6, 1);
            IBall ball2 = new Ball(6, 1, 8, 2);

            repository.Add(ball1);
            repository.Add(ball2);

            repository.RemoveAll();

            Assert.That(repository.GetAll().Count, Is.EqualTo(0));
        }
    }
}
