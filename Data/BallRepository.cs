using System.Collections.Generic;

namespace Data
{
    public class BallRepository : IBallRepository
    {
        private readonly List<IBall>? _balls;

        public BallRepository()
        {
            _balls = new List<IBall>();
        }

        public void Add(IBall ball)
        {
            _balls.Add(ball);
        }

        public List<IBall> GetAll()
        {
            return _balls;
        }

        public void Remove(IBall ball)
        {
            _balls.Remove(ball);
        }

        public void RemoveAll()
        {
            _balls.Clear();
        }
    }
}
