using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IBallRepository
    {
        public void Add(IBall ball);
        public void Remove(IBall ball);
        public void RemoveAll();
        public List<IBall> GetAll();
    }
}
