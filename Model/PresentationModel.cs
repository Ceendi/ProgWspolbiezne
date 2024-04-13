using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;

namespace Model
{

    internal class PresentationModel : ModelAbstractApi
    {

        public event EventHandler<BallChangeEventArgs> BallChanged;

        private IObservable<EventPattern<BallChangeEventArgs>> eventObservable = null;

        public PresentationModel()
        {
            eventObservable = Observable.FromEventPattern<BallChangeEventArgs>(this, "BallChanged");
        }

        public override IDisposable Subscribe(IObserver<IBallModel> observer)
        {
            return eventObservable.Subscribe(x => observer.OnNext(x.EventArgs.Ball), ex => observer.OnError(ex), () => observer.OnCompleted());
        }

        public override void Start()
        {
            Random random = new Random();
            int ballNumber = random.Next(1, 10);

            for (int i = 0; i < ballNumber; i++)
            {
                BallModel newBall = new BallModel(random.Next(100, 400 - 100), random.Next(100, 400 - 100)) { Diameter = 20 };
                BallChanged?.Invoke(this, new BallChangeEventArgs() { Ball = newBall });
            }
        }
    }
}
