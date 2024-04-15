using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Model
{
    public abstract class ModelAbstractApi : IObservable<IBallModel>
    {
        public static ModelAbstractApi CreateApi()
        {
            PresentationModel model = new PresentationModel();
            return model;
        }
        public abstract void Start();
        public abstract IDisposable Subscribe(IObserver<IBallModel> observer);
    }

    public interface IBallModel : INotifyPropertyChanged
    {
        double Top { get; }
        double Left { get; }
        double Diameter { get; }
    }

    public class BallChangeEventArgs : EventArgs
    {
        public IBallModel? Ball { get; internal set; }
    }
}